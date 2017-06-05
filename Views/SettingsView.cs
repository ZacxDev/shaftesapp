using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.UI;
using ObjCRuntime;

namespace ShaftesApp.Views
{
    class SettingsView
    {

        public static CGRect Bounds;

        private bool init = false;

        private UIView Background;
        private UITextView Title;
        private UIToggle TypeView;
        private UIButton JoinClass;
        private UIToggle CanWork;
        private UIButton AvatarView;
        private UITextView Username;
        private UITextView Bio;

        private int X, Y;

        public SettingsView()
        {

            if (!init)
                Initialize();
            new PrimeView();
            AddToView();
        }

        public void Initialize()
        {

            if (init)
                return;

            init = true;

            X = C.X_MID - 128;
            Y = 64;

            Background = new UIView();
            Background.Frame = new CGRect(X, Y, 256, C.Y_MAX - 128);
            Background.BackgroundColor = UIColor.Gray;

            Bounds = Background.Frame;

            AvatarView = new UIButton();
            AvatarView.Frame = new CGRect(X, Y + 16, 64, 64);
            AvatarView.SetImage(ViewController.Client.Image, UIControlState.Normal);
            AvatarView.AddTarget(ViewController.BtnHandler, new Selector("SelectAvatar"), UIControlEvent.TouchUpInside);
            AvatarView.ContentMode = UIViewContentMode.ScaleAspectFit;

            Title = new UITextView();
            Title.Frame = new CGRect(X, Y, 256, 64);
            Title.BackgroundColor = UIColor.Gray;
            Title.Text = "Settings";
            Title.Font = Fonts.Settings_Title;

            TypeView = new UIToggle("Option1", "Option2");
            TypeView.SetImages(new UIImage[] { UIImage.FromBundle("settings_0"), UIImage.FromBundle("settings_1") });
            TypeView.SetFrame(new CGRect(X + 16, C.Y_MAX - 256, 240, 128));

            JoinClass = new UIButton();
            JoinClass.Frame = new CGRect(X + 16, C.Y_MAX - 394, 240, 128);
            JoinClass.SetImage(UIImage.FromBundle("button_joinclass"), UIControlState.Normal);
            JoinClass.ContentMode = UIViewContentMode.ScaleAspectFit;
            JoinClass.AddTarget(ViewController.BtnHandler, new Selector("JoinClass"), UIControlEvent.TouchUpInside);

            Username = new UITextView();
            Username.Text = ViewController.Client.Username;
            Username.Frame = new CGRect(X + 74, Y + 16, 128, 32);
            Username.BackgroundColor = UIColor.Clear;
            Username.Font = Fonts.Medium;

            Bio = new UITextView();
            Bio.Text = ViewController.Client.Bio;
            Bio.Frame = new CGRect(X + 74, Y + 16, 128, 32);
            Bio.BackgroundColor = UIColor.Clear;
            Bio.Font = Fonts.Announcements_Text;
            Bio.TextAlignment = UITextAlignment.Center;

        }

        private void AddToView()
        {
            Access.vc.View.AddSubview(Background);
            Access.vc.View.AddSubview(Title);
            Access.vc.View.AddSubview(TypeView);
            Access.vc.View.AddSubview(AvatarView);
            Access.vc.View.AddSubview(JoinClass);
            Access.vc.View.AddSubview(Username);
            Access.vc.View.AddSubview(Bio);
        }

    }
}