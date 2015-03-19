using System;
using Microsoft.Kinect;

namespace GeenenKinect
{

    public enum KinectMode
    {
        None,
        Idle,
        Gesture,
        Mouse,
        Steer
    }

    public class KinectEventArgs: EventArgs
    {
        public string message { get; private set; }

        public KinectEventArgs(string message)
        {
            this.message = message;
        }
    }

    public class KinectController
    {
        private KinectSensor kinectSensor = null;
        private CoordinateMapper coordinateMapper = null;
        private BodyFrameReader reader = null;
        private Body[] bodies = null;

        private GestureController gestureController = null;
        private KinectMouse kinectMouse = null;
        private KinectSteer kinectSteer = null;
        private KinectMode kinectMode = KinectMode.None;

        public KinectMode Mode { 
            get
            {
                return this.kinectMode;
            }
            set
            {
                if(this.kinectMode != value)
                {
                    this.kinectMode = value;

                    if(this.kinectMode == KinectMode.Gesture && this.gestureController == null)
                    {
                        this.gestureController = new GestureController();
                    }
                    else if(this.kinectMode == KinectMode.Mouse && this.kinectMouse == null)
                    {
                        this.kinectMouse = new KinectMouse();
                    } 
                    else if(this.kinectMode == KinectMode.Steer && this.kinectSteer == null)
                    {
                        this.kinectSteer = new KinectSteer();
                    }
                }
            }
        }

        public event EventHandler<KinectEventArgs> KinectActionRecognized;

        public KinectController()
        {
            this.kinectMode = KinectMode.None;
            this.kinectSensor = KinectSensor.GetDefault();

            if (this.kinectSensor != null)
            {
                // get the coordinate mapper
                this.coordinateMapper = this.kinectSensor.CoordinateMapper;

                // open the sensor
                this.kinectSensor.Open();

                this.bodies = new Body[this.kinectSensor.BodyFrameSource.BodyCount];

                // open the reader for the body frames
                this.reader = this.kinectSensor.BodyFrameSource.OpenReader();
                this.reader.FrameArrived += this.Reader_FrameArrived;
            }
        }

        public void SetChildMode(int mode)
        {
            if (this.kinectMode == KinectMode.Gesture)
            {
                this.gestureController.Mode = (GestureControllerMode)mode;
            }
            else if (this.kinectMode == KinectMode.Mouse)
            {
                this.kinectMouse.Mode = (MouseMode)mode;
            }
            else if (this.kinectMode == KinectMode.Steer)
            {
                this.kinectSteer.Mode = (SteerMode)mode;
            }
        }

        public void Close()
        {
            if (this.reader != null)
            {
                this.reader.Dispose();
                this.reader = null;
            }

            /*
            if (this.bodies != null)
            {
                foreach (Body body in this.bodies)
                {
                    if (body != null)
                    {
                        body.Close();
                    }
                }
            }
             * */

            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }
        }

        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            if(this.kinectMode == KinectMode.None)
            {
                return;
            }

            BodyFrameReference frameReference = e.FrameReference;
            try
            {
                BodyFrame frame = frameReference.AcquireFrame();
                if (frame != null)
                {
                    // BodyFrame is IDisposable
                    using (frame)
                    {
                        frame.GetAndRefreshBodyData(this.bodies);

                        Body closestBody = null;
                        float distance = 9999;

                        foreach (Body body in this.bodies)
                        {
                            if (body.IsTracked)
                            {
                                CameraSpacePoint pos = body.Joints[JointType.SpineShoulder].Position;
                                if (pos.Z < 2.5 && (pos.X > -0.5 && pos.X < 0.5) && pos.Z < distance)
                                {
                                    distance = pos.Z;
                                    closestBody = body;
                                }
                            }
                        }

                        if(closestBody != null)
                        {
                            updateKinect(closestBody);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignore if the frame is no longer available
            }
        }

        private void updateKinect(Body body)
        {
            if(this.kinectMode == KinectMode.Mouse)
            {
                this.kinectMouse.Update(body);
            }
            else if(this.kinectMode == KinectMode.Gesture)
            {
                GestureType gestureType = this.gestureController.Update(body);
                if(gestureType != GestureType.None)
                {
                    KinectActionRecognized(this, new KinectEventArgs("{\"Gesture\":\"" + gestureType + "\"}"));
                }
            } 
            else if(this.kinectMode == KinectMode.Steer)
            {
                double angle = this.kinectSteer.Update(body);
                KinectActionRecognized(this, new KinectEventArgs("{\"SteerAngle\":" + angle + "}"));
            }
        }

    }
}
