using System;
using System.Collections.Generic;
using Alchemy;
using Alchemy.Classes;
using Newtonsoft.Json;
using System.Net;
using GeenenKinect;

namespace KinectServer
{
    class Program
    {
        private static List<UserContext> clients = new List<UserContext>();
        private static KinectController kinectController = null;

        static void Main(string[] args)
        {
            kinectController = new KinectController();
            kinectController.KinectActionRecognized += OnActionRecognized;

            var aServer = new WebSocketServer(8181, IPAddress.Any)
            {
                OnReceive = OnReceive,
                OnConnected = OnConnect,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };

            aServer.Start();
            Console.WriteLine("Started Websocket Server.");

            Console.ReadLine();
            kinectController.Close();
            aServer.Stop();
        }

        private static void OnConnect(UserContext context)
        {
            clients.Add(context);
            Console.WriteLine("Client Connection From : " + context.ClientAddress);
        }

        private static void OnReceive(UserContext context)
        {
            var message = context.DataFrame.ToString();
            Console.WriteLine("Received : " + message + " From :" + context.ClientAddress);

            Dictionary<string, int> dict = JsonConvert.DeserializeObject<Dictionary<string, int>>(message);
            if(dict.ContainsKey("GestureMode"))
            {
                kinectController.Mode = KinectMode.Gesture;
                kinectController.SetChildMode(dict["GestureMode"]);
            }
            else if(dict.ContainsKey("MouseMode"))
            {
                kinectController.Mode = KinectMode.Mouse;
                kinectController.SetChildMode(dict["MouseMode"]);
            }
            else if(dict.ContainsKey("SteerMode"))
            {
                kinectController.Mode = KinectMode.Steer;
                kinectController.SetChildMode(dict["SteerMode"]);
            }
        }

        private static void OnDisconnect(UserContext context)
        {
            clients.Remove(context);
            Console.WriteLine("Client Disconnected : " + context.ClientAddress);
        }

        private static void OnActionRecognized(object sender, KinectEventArgs e)
        {
            Console.WriteLine("Send message to clients : " + e.message);
            foreach (UserContext context in clients)
            {
                context.Send(e.message);
            }
        }
    }
}
