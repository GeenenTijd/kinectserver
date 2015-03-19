using Microsoft.Kinect;

namespace GeenenKinect.Gestures
{
    class Gesture
    {
        readonly int MAX_FRAME_COUNT = 20;

        IGestureSegment[] _segments;
        int _currentSegment = 0;
        int _frameCount = 0;

        public GestureType gestureType { get; private set; }

        public Gesture(GestureType type)
        {
            this.gestureType = type;
            SetGestureSegments();
        }

        #region Methods

        public bool Update(Body body)
        {
            if(_segments[_currentSegment].Update(body))
            {
                if (_currentSegment + 1 < _segments.Length)
                {
                    ++_currentSegment;
                    _frameCount = 0;
                }
                else
                {
                    Reset();
                    return true;
                }
            }
            else if (_frameCount == MAX_FRAME_COUNT)
            {
                Reset();
            }
            else
            {
                ++_frameCount;
            }
            return false;
        }

        public void Reset()
        {
            _currentSegment = 0;
            _frameCount = 0;
        }

        private void SetGestureSegments()
        {
            if(this.gestureType == GestureType.SwipeLeft)
            {
                _segments = new IGestureSegment[3];
                _segments[0] = new SwipeLeftSegmentRight();
                _segments[1] = new SwipeLeftSegmentCenter();
                _segments[2] = new SwipeLeftSegmentLeft();
            }
            else if (this.gestureType == GestureType.SwipeRight)
            {
                _segments = new IGestureSegment[3];
                _segments[0] = new SwipeRightSegmentLeft();
                _segments[1] = new SwipeRightSegmentCenter();
                _segments[2] = new SwipeRightSegmentRight();
            }
            else if (this.gestureType == GestureType.ClickRightHand)
            {
                _segments = new IGestureSegment[3];
                _segments[0] = new ClickRightSegmentShort();
                _segments[1] = new ClickRightSegmentFar();
                _segments[2] = new ClickRightSegmentFar();
            }
            else if (this.gestureType == GestureType.ClickLeftHand)
            {
                _segments = new IGestureSegment[3];
                _segments[0] = new ClickLeftSegmentShort();
                _segments[1] = new ClickLeftSegmentFar();
                _segments[2] = new ClickLeftSegmentFar();
            }

            // TODO: set all segments

        }

        #endregion
    }
}