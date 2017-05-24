using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.Net;
using ObjCRuntime;
using System.Diagnostics;

namespace ShaftesApp.UI
{
    class RoomListNode
        : NSObject
    {

        public UIView Background;
        public UITextView Title;
        public UIButton Button;
        public Room Room;
        private int Y;

        public RoomListNode(String name, int i)
        {
            //63 so that lines dont look weird
            Y = i * 63;

            Background = new UIView();
            Background.Frame = new CGRect(0, Y, Access.vc.ViewWidth, 64);
            Background.Layer.BorderWidth = 1;
            Background.Layer.BorderColor = UIColor.White.CGColor;
            Background.BackgroundColor = UIColor.Clear;
            Background.UserInteractionEnabled = false;

            Title = new UITextView();
            Title.Text = name;
            Title.BackgroundColor = UIColor.Clear;
            Title.Frame = new CGRect(0, Y + 16, Access.vc.ViewWidth / 2, 32);
            Title.UserInteractionEnabled = false;

            Button = new UIButton();
            Button.Frame = Background.Frame;
            //Button.AddTarget(this, new Selector("ShowRoom"), UIControlEvent.TouchUpInside);
            //Button.AddTarget(ViewController.BtnHandler, new Selector("ShowRoom"), UIControlEvent.TouchUpInside);
            Button.TouchUpInside += (sender, e) => 
            {
                ShowRoom();
            };
            Button.Layer.BorderColor = UIColor.Green.CGColor;
            Button.Layer.BorderWidth = 2;

            Room = Room.GetRoom(name);
        }

        public void AddToSuperView(UIView v)
        {
            v.AddSubview(Background);
            v.AddSubview(Title);
            v.AddSubview(Button);
        }

        [Export("ShowRoom")]
        void ShowRoom()
        {
            Loader.Room = Room;
            new Loader(AppState.ROOM);
        }

    }
}