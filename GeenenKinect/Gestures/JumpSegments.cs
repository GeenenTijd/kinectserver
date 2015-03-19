
using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    public class JumpSegmenUp : IGestureSegment
    {
        public bool Update(Body body)
        {
            if(body.Joints[JointType.SpineShoulder].Position.Y > GestureGlobals.s_ShoulderYPos + 0.1)
            {
                return true;
            }
            return false;
        }
    }

    public class JumpSegmenDown : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.Joints[JointType.SpineShoulder].Position.Y < GestureGlobals.s_ShoulderYPos + 0.1)
            {
                return true;
            }
            return false;
        }
    }

    public class CrouchSegmenUp : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.Joints[JointType.SpineShoulder].Position.Y > GestureGlobals.s_ShoulderYPos - 0.1)
            {
                return true;
            }
            return false;
        }
    }
    public class CrouchSegmenDown : IGestureSegment
    {
        public bool Update(Body body)
        {
            if (body.Joints[JointType.SpineShoulder].Position.Y < GestureGlobals.s_ShoulderYPos - 0.15)
            {
                return true;
            }
            return false;
        }
    }
}
