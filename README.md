# kinectserver

C# websocket server for Kinect2 on port 8181

# Kinect Modes

0 = KinectMode_Mouse (Close hand is mouse down + mouse up)

1 = KinectMode_Wheel (Steering wheel returns angle)

2 = KinectMode_Vertical (SwipeUp, SwipeDown)

3 = KinectMode_Horizontal(SwipeLeft, SwipeRight)

4 = KinectMode_Alert (ClickLeft, ClickRight)

5 = KinectMode_Category (SwipeLeft, SwipeRight and Press)

6 = KinectMode_Detail (SwipeLeft, SwipeRight and Close)

7 = KinectMode_FlappyBird (Flap, ClickRight)

8 = KinectMode_FightingGame (PunchLeft, PunchRight, KickLeft, KickRight, Jump and Crouch)

9 = KinectMode_JumpGame (Jump, ClickRight)

10 = KinectMode_Fly (Fly)

11 = KinectMode_MouseManual (close hand is mouse down)

12 = KinectMode_Debug (All)

# Kinect Actions

0 = GestureType_None

1 = GestureType_Flap

2 = GestureType_SwipeLeft

3 = GestureType_SwipeRight

4 = GestureType_SwipeDownLeft

5 = GestureType_SwipeUpLeft

6 = GestureType_SwipeDownRight

7 = GestureType_SwipeUpRight

8 = GestureType_ZoomIn

9 = GestureType_ZoomOut

10 = GestureType_LeftClick

11 = GestureType_RightClick

12 = GestureType_PunchLeft

13 = GestureType_PunchRight

14 = GestureType_KickLeft

15 = GestureType_KickRight

16 = GestureType_Jump

17 = GestureType_Crouch

18 = GestureType_Hello

19 = GestureType_Idle

20 = GestureType_Wheel

21 = GestureType_Fly

22 = GestureType_Close

# Javascript Connect

```javascript
var websocket = new WebSocket('ws://localhost:8181');
websocket.onopen = function () {
	game.websocket.send('{GestureMode:3}');
};
websocket.onmessage = function (evt) {
	if (evt.data) {
		var action = JSON.parse(evt.data);
		console.log(action.Gesture);
	}
};
```
