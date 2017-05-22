using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ShaftesApp.UI
{
    class RoomListNode
    {

        public UIView Background;
        public UITextView Title;
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
        }

        public void AddToSuperView(UIView v)
        {
            v.Add(Background);
            v.Add(Title);
        }

    }
}