using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
using System.Diagnostics;

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

            Messages.Add(new RoomMessage("Assignment 1", "please complete the following tasks"));
            Messages.Add(new RoomMessage("Assignment 2", "Your task is to eat my socks!"));
            Messages.Add(new RoomMessage("Assignment 3", "Your job is to solve these equations"));

            Initialize();
            rooms.Add(this);
        }

        public void Initialize()
        {
            Background = new UIView();
            Background.Frame = new CGRect(0, Y, C.X_MAX, C.Y_MAX - 64);

            TitleView = new UITextView();
            TitleView.Frame = new CGRect(C.X_MID - 64, Y, 128, 64);
            TitleView.Font = Fonts.Settings_Title;
            TitleView.Text = Name;
            TitleView.BackgroundColor = UIColor.Clear;
            TitleView.TextColor = UIColor.White;

            DescView = new UITextView();
            DescView.Frame = new CGRect(C.X_MID - 192, Y + 40, 384, 64);
            DescView.Font = Fonts.Announcements_Text;
            DescView.Text = Desc;
            DescView.BackgroundColor = UIColor.Clear;
            DescView.TextColor = UIColor.White;

            StudentsView = new UITextView();
            StudentsView.Frame = new CGRect(C.X_MID + 64, Y, 128, 64);
            StudentsView.Font = Fonts.Announcements_Text;
            StudentsView.Text = $"Students: {StudentIds.Count}";
            StudentsView.BackgroundColor = UIColor.Clear;
            StudentsView.TextColor = UIColor.White;
            
            MessageScroll = new UIScrollView();
            MessageScroll.Frame = new CGRect(0, Y + 96, C.X_MAX, C.Y_MAX - 128);
            MessageScroll.DirectionalLockEnabled = true;
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

            nfloat ScrollHeight = 0f;
            for (int i = 0; i < Messages.Count; i++)
            {
                Messages[i].SetY((int)ScrollHeight);
                Messages[i].AddToView(MessageScroll);
                ScrollHeight += 256;
            }
            MessageScroll.ContentSize = new CGSize(C.X_MAX, ScrollHeight + 128);
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