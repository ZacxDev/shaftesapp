using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;

namespace ShaftesApp.Net
{
    public class Room
    {

        public static List<Room> rooms = new List<Room>();
        public static int Y = 64;

        public List<int> StudentIds = new List<int>();
        public List<RoomMessage> Messages = new List<RoomMessage>();
        public int ID;
        public String Name = "TestRoom";
        public String Desc = "This is a test description. In this is Class you will learn all about knowledge, knowledge, and knowledge.";
        public int Key = 1234;

        public UIView Background;
        public UITextView TitleView;
        public UITextView DescView;
        public UITextView StudentsView;
        public SRButton Back;
        public UIScrollView MessageScroll;

        public Room(String name)
        {
            Name = name;
            Initialize();
            rooms.Add(this);
        }

        public void Initialize()
        {
            Background = new UIView();
            Background.Frame = new CGRect(0, Y, C.X_MAX, C.Y_MAX - 64);

            TitleView = new UITextView();
            TitleView.Frame = new CGRect(C.X_MID - 32, Y, 64, 32);
            TitleView.Font = Fonts.Settings_Title;
            TitleView.Text = Name;

            DescView = new UITextView();
            DescView.Frame = new CGRect(C.X_MID - 128, Y + 40, 256, 32);
            DescView.Font = Fonts.Announcements_Text;
            DescView.Text = Desc;

            StudentsView = new UITextView();
            StudentsView.Frame = new CGRect(C.X_MID + 64, Y, 128, 32);
            StudentsView.Font = Fonts.Announcements_Text;
            StudentsView.Text = Desc;

            nfloat ScrollHeight = 0f;
            for (int i = 0; i < Messages.Count; i++)
            {
                ScrollHeight += Messages[i].Background.Frame.Height;
            }

            MessageScroll = new UIScrollView();
            MessageScroll.Frame = new CGRect(0, Y + 48, C.X_MAX, C.Y_MAX - 32);
            MessageScroll.DirectionalLockEnabled = true;
            MessageScroll.ContentSize = new CGSize(C.X_MAX, ScrollHeight);
            MessageScroll.ScrollEnabled = true;
            MessageScroll.Bounces = true;
            MessageScroll.AlwaysBounceVertical = true;

            Back = new SRButton(0, 0, 32, 32, new Selector("RoomBackToProfileRoomList"), "button_back");
        }

        public void AddToView(UIView v)
        {
            v.AddSubview(Background);
            v.AddSubview(TitleView);
            v.AddSubview(DescView);
            v.AddSubview(StudentsView);
            Back.Render();
            v.AddSubview(MessageScroll);
        }

        public static Room GetRoom(String name)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Name == name)
                    return rooms[i];
            }
            return null;
        }


    }
}