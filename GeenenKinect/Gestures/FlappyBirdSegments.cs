
using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    public class FlappyBirdSegmenUp : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            CameraSpacePoint shoulderLeft = body.Joints[JointType.ShoulderLeft].Position;
            CameraSpacePoint shoulderRight = body.Joints[JointType.ShoulderRight].Position;

            // left hand 20cm left of left shoulder
            // left hand above left shoulder
            // right hand 20cm right of right shoulder
            // right hand above right shoulder
            if(handLeft.X < shoulderLeft.X - 0.2
                && handLeft.Y > shoulderLeft.Y
                && handRight.X > shoulderRight.X + 0.2
                && handRight.Y > shoulderRight.Y)
            {
                return true;
            }
            return false;
        }
    }

    public class FlappyBirdSegmenDown : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            CameraSpacePoint shoulderLeft = body.Joints[JointType.ShoulderLeft].Position;
            CameraSpacePoint shoulderRight = body.Joints[JointType.ShoulderRight].Position;

            // left hand 20cm left of left shoulder
            // left hand 15cm under left shoulder
            // right hand 20cm right of right shoulder
            // right hand 15cm under right shoulder
            if (handLeft.X < shoulderLeft.X - 0.2
                && handLeft.Y < shoulderLeft.Y - 15
                && handRight.X > shoulderRight.X + 0.2
                && handRight.Y < shoulderRight.Y - 15)
            {
                return true;
            }
            return false;
        }
    }
}
