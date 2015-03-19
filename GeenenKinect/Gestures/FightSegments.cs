
using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    public class PunchLeftSegmentShort : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.HandLeftState != HandState.Closed)
            {
                return false;
            }

            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;

            // left hand in front of left elbow
            // left hand below shoulder height
            // left hand above hip height
            // left hand right of left shoulder
            // left hand left of right shoulder
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z
                && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handLeft.Y > body.Joints[JointType.SpineShoulder].Position.Y - 0.2
                && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y
                && handLeft.X > body.Joints[JointType.ShoulderLeft].Position.X
                && handLeft.X < body.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class PunchLeftSegmentLong : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.HandLeftState != HandState.Closed)
            {
                return false;
            }

            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;

            // left hand in front of left elbow
            // left hand 25cm in front of left shoulder
            // left hand below shoulder height
            // left hand above hip height
            // left hand right of left shoulder
            // left hand left of right shoulder
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z
                && handLeft.Z < body.Joints[JointType.ShoulderLeft].Position.Z - 0.25
                && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y
                && handLeft.X > body.Joints[JointType.ShoulderLeft].Position.X
                && handLeft.X < body.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class PunchRightSegmentShort : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.HandRightState != HandState.Closed)
            {
                return false;
            }

            CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;

            // right hand in front of right elbow
            // right hand below shoulder height
            // right hand above hip height
            // right hand right of left shoulder
            // right hand left of right shoulder
            if (handRight.Z < body.Joints[JointType.ElbowRight].Position.Z
                && handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handRight.Y > body.Joints[JointType.SpineShoulder].Position.Y - 0.2
                && handRight.Y > body.Joints[JointType.SpineBase].Position.Y
                && handRight.X > body.Joints[JointType.ShoulderLeft].Position.X
                && handRight.X < body.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class PunchRightSegmentLong : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.HandRightState != HandState.Closed)
            {
                return false;
            }

            CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;

            // right hand in front of right elbow
            // right hand 25cm in front of right shoulder
            // right hand below shoulder height
            // right hand above hip height
            // right hand right of left shoulder
            // right hand left of right shoulder
            if (handRight.Z < body.Joints[JointType.ElbowRight].Position.Z
                && handRight.Z < body.Joints[JointType.ShoulderRight].Position.Z - 0.25
                && handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handRight.Y > body.Joints[JointType.SpineBase].Position.Y
                && handRight.X > body.Joints[JointType.ShoulderLeft].Position.X
                && handRight.X < body.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }
}
