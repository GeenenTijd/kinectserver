
using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{

    public class SwipeDownSegmentHigh : IGestureSegment
    {
        public bool Update(Body body)
        {

            // right hand in front of right shoulder
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ElbowRight].Position.Z && body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.SpineShoulder].Position.Y)
            {
                // right hand below head height and hand higher than elbow
                if (body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.Head].Position.Y && body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.ElbowRight].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.ShoulderRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }

    public class SwipeDownSegmentMedium : IGestureSegment
    {
        public bool Update(Body body)
        {
            // right hand in front of right shoulder
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ElbowRight].Position.Z && body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.SpineShoulder].Position.Y)
            {
                // right hand below right elbow
                if (body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.ElbowRight].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.HipRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }

    public class SwipeDownSegmentLow : IGestureSegment
    {
        public bool Update(Body body)
        {
            // //Right hand in front of right Shoulder
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ElbowRight].Position.Z && body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.SpineShoulder].Position.Y)
            {
                // right hand below hip
                if (body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.HipRight].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.HipRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }

                return false;
            }

            return false;
        }
    }

    public class SwipeLeftSegmentRight : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;

            // right hand in front of right elbow
            // right hand below shoulder height
            // right hand above hip height
            // right hand right of right shoulder
            if (handRight.Z < body.Joints[JointType.ElbowRight].Position.Z
                && handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handRight.Y > body.Joints[JointType.SpineBase].Position.Y
                && handRight.X > body.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class SwipeLeftSegmentCenter : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;

            // right hand in front of right elbow
            // right hand below shoulder
            // right hand above hip height
            // right hand left of right shoulder
            // right hand right of left shoulder
            if (handRight.Z < body.Joints[JointType.ElbowRight].Position.Z
                && handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handRight.Y > body.Joints[JointType.SpineBase].Position.Y
                && handRight.X < body.Joints[JointType.ShoulderRight].Position.X
                && handRight.X > body.Joints[JointType.ShoulderLeft].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class SwipeLeftSegmentLeft : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;

            // right hand in front of right elbow
            // right hand below shoulder
            // right hand above hip height
            // right hand left of center hip
            if (handRight.Z < body.Joints[JointType.ElbowRight].Position.Z
                && handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handRight.Y > body.Joints[JointType.SpineBase].Position.Y
                && handRight.X < body.Joints[JointType.SpineBase].Position.X)
            {
                return true;
            }

            return false;
        }
    }

    public class SwipeRightSegmentLeft : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;

            // left hand in front of left elbow
            // left hand below shoulder height
            // left hand above hip height
            // left hand left of left shoulder
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z
                && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y
                && handLeft.X < body.Joints[JointType.ShoulderLeft].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class SwipeRightSegmentCenter : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;

            // left hand in front of left elbow
            // left hand below shoulder height
            // left hand above hip height
            // left hand right of left shoulder
            // left hand left of right shoulder
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z
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

    public class SwipeRightSegmentRight : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;

            // left hand in front of left elbow
            // left hand below shoulder height
            // left hand above hip height
            // left hand right of center hip
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z
                && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y
                && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y
                && handLeft.X > body.Joints[JointType.SpineBase].Position.X)
            {
                return true;
            }
            return false;
        }
    }

    public class SwipeUpSegmentLow : IGestureSegment
    {
        public bool Update(Body body)
        {

            // right hand in front of right elbow
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ElbowRight].Position.Z)
            {
                // right hand below shoulder height but above hip height
                if (body.Joints[JointType.HandRight].Position.Y < body.Joints[JointType.Head].Position.Y && body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.SpineBase].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.ShoulderRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }

    public class SwipeUpSegmentCenter : IGestureSegment
    {
        public bool Update(Body body)
        {
            // right hand in front of right shoulder
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ShoulderRight].Position.Z)
            {
                // right hand above right shoulder
                if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.ShoulderRight].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.ShoulderRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }

    public class SwipeUpSegmentUp : IGestureSegment
    {
        public bool Update(Body body)
        {
            // //Right hand in front of right shoulder
            if (body.Joints[JointType.HandRight].Position.Z < body.Joints[JointType.ShoulderRight].Position.Z)
            {
                // right hand above head
                if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.Head].Position.Y)
                {
                    // right hand right of right shoulder
                    if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.ShoulderRight].Position.X)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }
}
