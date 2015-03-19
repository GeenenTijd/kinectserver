
using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    public class JoinedHandsSegment : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            // Right and Left Hand in front of elbows
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z 
                && handRight.Z < body.Joints[JointType.ElbowRight].Position.Z)
            {
                // Hands between shoulder and hip
                if (handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handRight.Y > body.Joints[JointType.SpineBase].Position.Y &&
                    handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y)
                {
                    // Hands between shoulders
                    if (handRight.X < body.Joints[JointType.ShoulderRight].Position.X 
                        && handRight.X > body.Joints[JointType.ShoulderLeft].Position.X &&
                        handLeft.X > body.Joints[JointType.ShoulderLeft].Position.X 
                        && handLeft.X < body.Joints[JointType.ShoulderRight].Position.X)
                    {
                        // Hands very close
                        if (handRight.X - handLeft.X < 0.1)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
    }

    public class ZoomSegmentSmall : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            // Right and Left Hand in front of elbows
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z 
                && handRight.Z < body.Joints[JointType.ElbowRight].Position.Z)
            {
                // Hands between shoulder and hip
                if (handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handRight.Y > body.Joints[JointType.SpineBase].Position.Y 
                    && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y)
                {
                    // Hands between shoulders
                    if (handRight.X < body.Joints[JointType.ShoulderRight].Position.X 
                        && handRight.X > body.Joints[JointType.ShoulderLeft].Position.X 
                        && handLeft.X > body.Joints[JointType.ShoulderLeft].Position.X 
                        && handLeft.X < body.Joints[JointType.ShoulderRight].Position.X)
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

    public class ZoomSegmentMedium : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            // Right and Left Hand in front of elbows
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z 
                && handRight.Z < body.Joints[JointType.ElbowRight].Position.Z)
            {
                // Hands between shoulder and hip
                if (handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handRight.Y > body.Joints[JointType.SpineBase].Position.Y 
                    && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y)
                {
                    // Hands outside shoulders
                    if (handRight.X > body.Joints[JointType.ShoulderRight].Position.X 
                        && handLeft.X < body.Joints[JointType.ShoulderLeft].Position.X)
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

    public class ZoomSegmentLarge : IGestureSegment
    {
        public bool Update(Body body)
        {
            CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint handRight = body.Joints[JointType.HandLeft].Position;

            // Right and Left Hand in front of elbows
            if (handLeft.Z < body.Joints[JointType.ElbowLeft].Position.Z 
                && handRight.Z < body.Joints[JointType.ElbowRight].Position.Z)
            {
                // Hands between shoulder and hip
                if (handRight.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handRight.Y > body.Joints[JointType.SpineBase].Position.Y 
                    && handLeft.Y < body.Joints[JointType.SpineShoulder].Position.Y 
                    && handLeft.Y > body.Joints[JointType.SpineBase].Position.Y)
                {
                    // Hands outside shoulder
                    if (handRight.X > body.Joints[JointType.ShoulderRight].Position.X 
                        && handLeft.X < body.Joints[JointType.ShoulderLeft].Position.X)
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
