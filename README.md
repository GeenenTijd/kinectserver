# DEPRECATED

It doesn't work well to constantly update your server when a game you create needs a new feature. https://github.com/GlennGeenen/kinectbody just returns your body information so that you can do your gestures in javascript.

# kinectserver

C# websocket server for Kinect2 on port 8181

# Kinect Modes

0 = None

1 = Idle

2 = GestureMode - Sends back recognized gestures

3 = MouseMode - Kinect controls your mouse

4 = SteerMode - Returns steering angle

# Gesture Modes

0 = None

1 = HorizontalSwipe (SwipeLeft, SwipeRight)

2 = VerticalSwipe (SwipeUp, SwipeDown)

3 = Alert (ClickLeft, ClickRight)

4 = Zoom

5 = FlappyBird (Flap, ClickRight)

6 = FightingGame (PunchLeft, PunchRight, KickLeft, KickRight, Jump and Crouch)

7 = JumpGame (Jump, ClickRight)

# Kinect Recognized Actions

JoinedHands, WaveRight, WaveLeft, Menu, SwipeLeft, SwipeRight, SwipeUp, SwipeDown, ZoomIn, ZoomOut, ClickLeftHand, ClickRightHand, Jump, Crouch, PunchLeft, PunchRight, KickLeft, KickRight

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
