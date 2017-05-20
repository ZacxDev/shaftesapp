using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ObjCRuntime;

namespace ShaftesApp.Views
{
    static class ProfileView
    {


        private static bool init = false;
        private static List<String> announcements = new List<String>();

        private static UIImageView Avatar;
        private static UIImageView AvatarFrame;
        private static UITextView Username;
        private static UITextView Bio;
        private static SRButton Rooms;
        private static UITextView Grade;

        static ProfileView()
        {

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
            AvatarFrame.Frame = new CGRect(0, 38, C.X_MAX - 32, 74);
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
            Bio.Frame = new CGRect(C.X_MID - 128, 56, 256, 56);
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

    }
}