using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
using ShaftesApp.UI;

namespace ShaftesApp.Views
{
    static class ProfileView
    {

        private static bool init = false;
        private static bool RoomsInit = false;
        private static List<String> rooms = new List<String>();

        //profile
        public static UIImageView Avatar;
        public static UIImageView AvatarFrame;
        public static UITextView Username;
        public static UITextView Bio;
        public static SRButton Rooms;
        public static UITextView Grade;

        //rooms view
        public static SRButton Back;
        public static UITextView RoomsTitle;
        public static UIScrollView RoomsViewScroll;

        static ProfileView()
        {

            rooms.Add("TestRoom0");
            rooms.Add("TestRoom1");
            rooms.Add("TestRoom2");
            rooms.Add("TestRoom3");
            rooms.Add("TestRoom4");
            rooms.Add("TestRoom5");
            rooms.Add("TestRoom6");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");
            rooms.Add("TestRoom7");

            if (!init)
                Initialize();
            //AddToView();
        }

        private static void Initialize()
        {

            init = true;

            Avatar = new UIImageView();
            Avatar.Frame = new CGRect(4, 48, 64, 64);
            Avatar.BackgroundColor = UIColor.Clear;
            Avatar.Image = ViewController.Client.Image;

            AvatarFrame = new UIImageView();
            AvatarFrame.Frame = new CGRect(0, 38, C.X_MAX - 24, 74);
            AvatarFrame.BackgroundColor = UIColor.Clear;
            AvatarFrame.Image = UIImage.FromBundle("avatar_frame");

            Username = new UITextView();
            Username.Frame = new CGRect(C.X_MID - 64, 32, 128, 32);
            Username.Text = ViewController.Client.Username;
            Username.TextAlignment = UITextAlignment.Center;
            Username.BackgroundColor = UIColor.Clear;
            Username.TextColor = UIColor.White;
            Username.Font = Fonts.Settings_Title;

            Bio = new UITextView();
            Bio.Frame = new CGRect(C.X_MID - 104, 56, 208, 56);
            Bio.Text = ViewController.Client.Bio;
            Bio.TextAlignment = UITextAlignment.Center;
            Bio.BackgroundColor = UIColor.Clear;
            Bio.TextColor = UIColor.White;
            Bio.Font = UIFont.SystemFontOfSize(8);

            Rooms = new SRButton(C.X_MID - 112, 84, 128, 32, new Selector("ProfileRoomsFunc"));
            Rooms.SetText($"Classrooms: {ViewController.Client.RoomIds.Count}");

            Grade = new UITextView();
            Grade.Frame = new CGRect(C.X_MID, 84, 128, 32);
            Grade.Text = $"Grade: {ViewController.Client.Grade}";
            Grade.TextAlignment = UITextAlignment.Center;
            Grade.BackgroundColor = UIColor.Clear;
            Grade.TextColor = UIColor.White;
            Grade.Font = UIFont.SystemFontOfSize(12);
        }

        public static void AddToView()
        {
            Access.vc.View.AddSubview(Avatar);
            Access.vc.View.AddSubview(AvatarFrame);
            Access.vc.View.AddSubview(Username);
            Access.vc.View.AddSubview(Bio);
            Rooms.Render();
            Rooms.RenderText();
            Access.vc.View.AddSubview(Grade);
        }

        public static void InitRooms()
        {

            RoomsInit = true;

            RoomsTitle = new UITextView();
            RoomsTitle.Text = "Classrooms";
            RoomsTitle.Frame = new CGRect(Access.vc.ViewWidth + C.X_MID - 64, 32, 128, 32);
            RoomsTitle.Font = Fonts.Settings_Title;
            RoomsTitle.BackgroundColor = UIColor.Clear;

            Back = new SRButton(0, 0, 32, 32, new Selector("RoomsBackToProfile"), "button_back");

            RoomsViewScroll = new UIScrollView();
            RoomsViewScroll.BackgroundColor = UIColor.DarkGray;
            RoomsViewScroll.Frame = new CGRect(Access.vc.ViewWidth * 2, 64, Access.vc.ViewWidth, Access.vc.ViewHeight - 96);
            RoomsViewScroll.DirectionalLockEnabled = true;
            //RoomsViewScroll.ContentOffset = new CGPoint(0, rooms.Count * 64);
            RoomsViewScroll.ContentSize = new CGSize(Access.vc.ViewWidth, rooms.Count * 104 + 64);
            RoomsViewScroll.ScrollEnabled = true;
            RoomsViewScroll.Bounces = true;
            RoomsViewScroll.AlwaysBounceVertical = true;

        }

        public static void ShowRooms()
        {
            if (!RoomsInit)
                InitRooms();

            DissmissView();
            Access.vc.View.AddSubview(RoomsViewScroll);
            Access.vc.View.AddSubview(RoomsTitle);
            Back.Render();

            for (int i = 0; i < rooms.Count; i++)
            {
                new RoomListNode(rooms[i], i).AddToSuperView(RoomsViewScroll);
            }

            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseIn, () =>
            {
                RoomsViewScroll.Frame = new CGRect(0, 64, Access.vc.ViewWidth, Access.vc.ViewHeight - 96);
                RoomsTitle.Frame = new CGRect(C.X_MID - 64, 32, 128, 32);
            }, () => { }
                );

        }

        public static void DismissRooms()
        {

            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseOut, () =>
            {
                RoomsViewScroll.Frame = new CGRect(Access.vc.ViewWidth * 2, 64, Access.vc.ViewWidth, rooms.Count * 64);
                RoomsTitle.Frame = new CGRect(Access.vc.ViewWidth + C.X_MID - 64, 32, 128, 32);
            }, () => { }
                );

            Back.Remove();
            RoomsTitle.RemoveFromSuperview();
            RoomsViewScroll.RemoveFromSuperview();

            ViewController.ViewDismiss.PresentProfileView();
        }

        public static void DissmissView()
        {
            ViewController.ViewDismiss.DismissProfileView();
        }
    }
}