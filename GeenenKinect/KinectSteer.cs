using System;
using Microsoft.Kinect;

namespace GeenenKinect
{
    public enum SteerMode
    {
        None,
        Wheel,
        Fly
    }

    public class KinectSteer
    {
        private double lastAngle = 0;

        public SteerMode Mode { get; set; }

        public KinectSteer()
        {
            this.Mode = SteerMode.None;
        }

        public double Update(Body body)
        {
            if(Mode == SteerMode.Fly)
            {
                CameraSpacePoint leftHand = body.Joints[JointType.HandLeft].Position;
                CameraSpacePoint rightHand = body.Joints[JointType.HandRight].Position;

                double deltaX = rightHand.X - leftHand.X;
                double deltaY = rightHand.Y - leftHand.Y;

                // Get angle between 0 and 180
                double steerX = Math.Atan2(deltaX, deltaY) * 180 / Math.PI;

                // Filter inacurate angle
                if (steerX < 45 && rightHand.Y < leftHand.Y
                    || steerX > 135 && leftHand.Y < rightHand.Y)
                {
                    steerX = 180 - steerX;
                }
                lastAngle = steerX - 90;
            }
            else if(Mode == SteerMode.Wheel)
            {
                CameraSpacePoint leftHand = body.Joints[JointType.HandLeft].Position;
                CameraSpacePoint rightHand = body.Joints[JointType.HandRight].Position;
                CameraSpacePoint mid = body.Joints[JointType.SpineBase].Position;

                if (mid.Z > rightHand.Z && mid.Z > leftHand.Z
                    && rightHand.X - leftHand.X < 0.5f
                    && rightHand.Y > mid.Y && leftHand.Y > mid.Y)
                {

                    double deltaX = rightHand.X - leftHand.X;
                    double deltaY = rightHand.Y - leftHand.Y;

                    // Get angle between 0 and 180
                    double steerX = Math.Atan2(deltaX, deltaY) * 180 / Math.PI;

                    // Filter inacurate angle
                    if (steerX < 45 && rightHand.Y < leftHand.Y
                        || steerX > 135 && leftHand.Y < rightHand.Y)
                    {
                        steerX = 180 - steerX;
                    }
                    lastAngle = steerX - 90;
                }
            }
            return lastAngle;
        }

    }
}
