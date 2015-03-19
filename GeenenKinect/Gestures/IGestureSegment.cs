using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    public static class GestureGlobals
    {
        public static float s_ShoulderYPos = 0.0f;
    }

    public interface IGestureSegment
    {
        bool Update(Body body);
    }
}