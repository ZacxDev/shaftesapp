using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ShaftesApp.Net;

namespace ShaftesApp.Views
{
    class RoomView
    {
        public static int Y;

        public Room Room;

        public RoomView(Room room)
        {
            Room = room;
            //Initialize();
            AddToView(Access.vc.View);
        }

        private void Initialize()
        {
            
        }

        private void AddToView(UIView v)
        {
            Room.AddToView(v);
        }

    }
}