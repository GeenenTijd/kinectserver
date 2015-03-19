using System;
using System.Runtime.InteropServices;
using Microsoft.Kinect;

namespace GeenenKinect
{
    public enum MouseMode
    {
        None,
        AlwaysClick,
        ManualClick
    }


    public class KinectMouse
    {

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        private int widthValue = 1920;
        private int heightValue = 1080;

        private int lastX = 0;
        private int lastY = 0;

        public MouseMode Mode { get; set; }

        public void Update(Body body)
        {
            CameraSpacePoint leftHand = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint rightHand = body.Joints[JointType.HandRight].Position;

            if (rightHand.Z < leftHand.Z - 0.1)
            {
                CameraSpacePoint shoulderRight = body.Joints[JointType.ShoulderRight].Position;

                float x = rightHand.X - shoulderRight.X;
                float y = rightHand.Y - shoulderRight.Y;
                simulateMouse(x, y, body.HandRightState == HandState.Closed);
            }
            else if (leftHand.Z < rightHand.Z - 0.1)
            {
                CameraSpacePoint shoulderLeft = body.Joints[JointType.ShoulderLeft].Position;

                float x = leftHand.X - shoulderLeft.X;
                float y = leftHand.Y - shoulderLeft.Y;
                simulateMouse(x, y, body.HandLeftState == HandState.Closed);
            }
        }

        private void simulateMouse(float x, float y, bool closed)
        {
            float sensivity = 3.5f;

            x = Math.Min(Math.Max(x * sensivity, -1.0f), 1.0f);
            y = Math.Min(Math.Max(y * sensivity, -1.0f), 1.0f) * -1;

            int mouseX = (int)(((x * widthValue) + widthValue) * 0.5f);
            int mouseY = (int)(((y * heightValue) + heightValue) * 0.5f);

            if (mouseX - lastX > 3 || mouseX - lastX < -3)
            {
                lastX = mouseX;
            }

            if (mouseY - lastY > 3 || mouseY - lastY < -3)
            {
                lastY = mouseY;
            }

            SetCursorPos(lastX, lastY);

            if (Mode == MouseMode.ManualClick)
            {
                if (closed)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, lastX, lastY, 0, 0);
                }
                else
                {
                    mouse_event(MOUSEEVENTF_LEFTUP, lastX, lastY, 0, 0);
                }
            }
            else
            {
                if (closed)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, lastX, lastY, 0, 0);
                }
            }
        }
    }
}
