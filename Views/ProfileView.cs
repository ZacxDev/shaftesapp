using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;
using ShaftesApp.UI;
using ShaftesApp.Net;
using System.Diagnostics;

namespace ShaftesApp.Views
{
    static class ProfileView
    {

        private static bool init = false;
        private static bool RoomsInit = false;
        private static List<Room> rooms = new List<Room>();

        private static int X = 0, Y = 72;

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
        public static RoomsScrollView RoomsScrollView;

        static ProfileView()
        {

            if (!init)
                Initialize();
            //AddToView();
        }

        public static void Initialize()
        {
            if (init)
                return;

            init = true;

            rooms = ViewController.Client.Rooms;

            Avatar = new UIImageView();
            Avatar.Frame = new CGRect(X + 4, Y, 64, 64);
            Avatar.BackgroundColor = UIColor.Clear;
            Avatar.Image = ViewController.Client.Image;
            Avatar.ContentMode = UIViewContentMode.ScaleAspectFit;

            AvatarFrame = new UIImageView();
            AvatarFrame.Frame = new CGRect(X, Y - 10, C.X_MAX - 16, 74);
            AvatarFrame.BackgroundColor = UIColor.Clear;
            AvatarFrame.Image = UIImage.FromBundle("avatar_frame");

            Username = new UITextView();
            Username.Frame = new CGRect(C.X_MID - 64, Y - 16, 128, 32);
            Username.Text = ViewController.Client.Username;
            Username.TextAlignment = UITextAlignment.Center;
            Username.BackgroundColor = UIColor.Clear;
            Username.TextColor = UIColor.White;
            Username.Font = Fonts.Settings_Title;

            Bio = new UITextView();
            Bio.Frame = new CGRect(C.X_MID - 96, Y + 8, 208, 56);
            Bio.Text = ViewController.Client.Bio;
            Bio.TextAlignment = UITextAlignment.Center;
            Bio.BackgroundColor = UIColor.Clear;
            Bio.TextColor = UIColor.White;
            Bio.Font = UIFont.SystemFontOfSize(8);

            Rooms = new SRButton(C.X_MID - 96, Y + 32, 128, 32, new Selector("ProfileRoomsFunc"));
            Rooms.SetText($"Classrooms: {ViewController.Client.Rooms.Count}");

            Grade = new UITextView();
            Grade.Frame = new CGRect(C.X_MID, Y + 32, 128, 32);
            Grade.Text = $"Grade: {ViewController.Client.Grade}";
            Grade.TextAlignment = UITextAlignment.Center;
            Grade.BackgroundColor = UIColor.Clear;
            Grade.TextColor = UIColor.White;
            Grade.Font = UIFont.SystemFontOfSize(12);
        }

        public static void AddToView()
        {
            RefreshView();

            Access.vc.View.AddSubview(Avatar);
            Access.vc.View.AddSubview(AvatarFrame);
            Access.vc.View.AddSubview(Username);
            Access.vc.View.AddSubview(Bio);
            Rooms.Render(Access.vc.View);
            Rooms.RenderText(Access.vc.View);
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
            RoomsTitle.Editable = false;

            Back = new SRButton(0, 0, 32, 32, new Selector("RoomsBackToProfile"), "button_back");

            RoomsScrollView = new RoomsScrollView(rooms.Count);

            for (int i = 0; i < rooms.Count; i++)
            {
                new RoomListNode(rooms[i].Name, i).AddToSuperView(RoomsScrollView);
            }

        }

        private static void RefreshView()
        {
            Rooms.SetText($"Classrooms: {ViewController.Client.Rooms.Count}");
            RoomsScrollView = new RoomsScrollView(rooms.Count);

            for (int i = 0; i < rooms.Count; i++)
            {
                new RoomListNode(rooms[i].Name, i).AddToSuperView(RoomsScrollView);
            }
        }

        public static void ShowRooms(bool fromRoom)
        {
            if (!RoomsInit)
                InitRooms();
            if (!fromRoom)
                DissmissView();

            ViewController.LoaderInstance.clearSubviews();
            ViewController.LoaderInstance.ShowBackground();
            ViewController.LoaderInstance.ShowHeader();
            ViewController.LoaderInstance.ShowTaskbar();
            //readding to view so that you can see it fade
            AddToView();

            Access.vc.View.AddSubview(RoomsScrollView);
            Access.vc.View.AddSubview(RoomsTitle);
            Back.Render(Access.vc.View);

            

            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseIn, () =>
            {
                RoomsScrollView.Frame = new CGRect(0, 64, Access.vc.ViewWidth, Access.vc.ViewHeight - 96);
                RoomsTitle.Frame = new CGRect(C.X_MID - 64, 32, 128, 32);
            }, () => { }
                );

        }

        public static void DismissRooms()
        {

            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseOut, () =>
            {
                RoomsScrollView.Frame = new CGRect(Access.vc.ViewWidth * 2, 64, Access.vc.ViewWidth, rooms.Count * 64);
                RoomsTitle.Frame = new CGRect(Access.vc.ViewWidth + C.X_MID - 64, 32, 128, 32);
            }, () => { }
                );

            Back.Remove();
            RoomsTitle.RemoveFromSuperview();
            RoomsScrollView.RemoveFromSuperview();

            new Loader(AppState.PROFILE);
            ViewController.ViewDismiss.DismissProfileView(0.0);
            ViewController.ViewDismiss.PresentProfileView();
        }

        public static void DissmissView()
        {
            ViewController.ViewDismiss.DismissProfileView(0.5);
        }
    }
}