using System.Collections.Generic;
using GeenenKinect.Gestures;
using Microsoft.Kinect;

namespace GeenenKinect
{
    public enum GestureControllerMode
    {
        None,
        HorizontalSwipe,
        VerticalSwipe,
        Alert,
        Zoom,
        FlappyBird,
        FightingGame,
        JumpGame
    }

    public enum GestureType
    {
        None,
        JoinedHands,
        WaveRight,
        WaveLeft,
        Menu,
        SwipeLeft,
        SwipeRight,
        SwipeUp,
        SwipeDown,
        ZoomIn,
        ZoomOut,
        ClickLeftHand,
        ClickRightHand,
        Jump,
        Crouch,
        PunchLeft,
        PunchRight,
        KickLeft,
        KickRight
    }

    public class GestureController
    {
        private List<Gesture> gestureList = new List<Gesture>();
        private GestureControllerMode gestureMode = GestureControllerMode.None;

        public GestureControllerMode Mode { 
            get
            {
                return this.gestureMode;
            }
            set
            {
                if(this.gestureMode != value)
                {
                    this.gestureMode = value;
                    RemoveAllGestures();
                    AddGestures();
                }
            }
        }

        public GestureType Update(Body body)
        {
            GestureType type = GestureType.None;

            foreach(Gesture gesture in gestureList)
            {
                if(gesture.Update(body))
                {
                    type = gesture.gestureType;
                }
            }

            return type;
        }

        public void RemoveAllGestures()
        {
            gestureList.Clear();
        }

        private void AddGestures()
        {
            if (this.gestureMode == GestureControllerMode.HorizontalSwipe)
            {
                gestureList.Add(new Gesture(GestureType.SwipeLeft));
                gestureList.Add(new Gesture(GestureType.SwipeRight));
                gestureList.Add(new Gesture(GestureType.ClickLeftHand));
                gestureList.Add(new Gesture(GestureType.ClickRightHand));
            }
            else if (this.gestureMode == GestureControllerMode.VerticalSwipe)
            {
                gestureList.Add(new Gesture(GestureType.SwipeUp));
                gestureList.Add(new Gesture(GestureType.SwipeDown));
                gestureList.Add(new Gesture(GestureType.ClickLeftHand));
                gestureList.Add(new Gesture(GestureType.ClickRightHand));
            }
            else if (this.gestureMode == GestureControllerMode.Alert)
            {
                gestureList.Add(new Gesture(GestureType.ClickLeftHand));
                gestureList.Add(new Gesture(GestureType.ClickRightHand));
            }

            // TODO: Set All Modes

        }
    }
}
