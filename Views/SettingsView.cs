using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.UI;
using ObjCRuntime;
using System.Diagnostics;

namespace ShaftesApp.Views
{
    class SettingsView
        : UIView
    {


        private bool init = false;

        //main views
        private UITextView Title;
        private UIView Header;
        private UIToggle TypeView;
        private UIButton JoinClassView;
        private UIToggle CanWork;
        private UIButton AvatarView;
        private UITextView Username;
        private UITextView Bio;
        private UIButton Cancel;

        private int X, Y;

        //join class views
        private UITextView Title1;
        private UITextField CodeView;

        //confirm class views
        private UITextView Title2;
        private UITextView RoomName;
        private UIImageView RoomPic;
        private UIView Foreground;
        private UIButton JoinButton;

        public SettingsView()
        {

            if (!init)
                Initialize();
            new PrimeView();
            RenderMain();
        }

        public void Initialize()
        {

            if (init)
                return;

            init = true;

            X = C.X_MID - 128;
            Y = 64;

            Frame = new CGRect(X, Y, 256, C.Y_MAX - 128);
            BackgroundColor = UIColor.Gray;
            Layer.BorderWidth = 3;
            Layer.BorderColor = UIColor.White.CGColor;

            AvatarView = new UIButton();
            AvatarView.Frame = new CGRect(8, 32, 64, 64);
            AvatarView.SetImage(ViewController.Client.Image, UIControlState.Normal);
            AvatarView.AddTarget(ViewController.BtnHandler, new Selector("SelectAvatar"), UIControlEvent.TouchUpInside);
            AvatarView.ContentMode = UIViewContentMode.ScaleAspectFit;

            Title = new UITextView();
            Title.Frame = new CGRect(64, 4, 128, 64);
            Title.BackgroundColor = UIColor.Clear;
            Title.Text = "Settings";
            Title.Font = Fonts.Settings_Title;
            Title.TextAlignment = UITextAlignment.Center;

            Header = new UIView();
            Header.BackgroundColor = UIColor.Red;
            Header.Frame = new CGRect(0, 0, Frame.Width, 32);

            TypeView = new UIToggle("Option1", "Option2");
            TypeView.Frame = new CGRect(0, Frame.Width - 138, 240, 128);
            TypeView.Initialize();
            TypeView.SetImages(new UIImage[] { UIImage.FromBundle("settings_0"), UIImage.FromBundle("settings_1") });

            JoinClassView = new UIButton();
            JoinClassView.Frame = new CGRect(0, Frame.Height - 266, 240, 128);
            JoinClassView.SetImage(UIImage.FromBundle("button_joinclass"), UIControlState.Normal);
            JoinClassView.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            JoinClassView.AddTarget(this, new Selector("JoinClass"), UIControlEvent.TouchUpInside);
            
            Username = new UITextView();
            Username.Text = ViewController.Client.Username;
            Username.Frame = new CGRect(80, 24, 128, 32);
            Username.BackgroundColor = UIColor.Clear;
            Username.Font = Fonts.Medium;

            Bio = new UITextView();
            Bio.Text = ViewController.Client.Bio;
            Bio.Frame = new CGRect(48, 48, 192, 64);
            Bio.BackgroundColor = UIColor.Clear;
            Bio.Font = Fonts.Small;
            Bio.TextAlignment = UITextAlignment.Center;

            Cancel = new UIButton();
            Cancel.Frame = new CGRect(Frame.Width - 32, 0, 32, 32);
            Cancel.SetImage(UIImage.FromBundle("button_cancel"), UIControlState.Normal);
            Cancel.ContentMode = UIViewContentMode.ScaleAspectFit;

        }

        private void RenderMain()
        {
            AddSubview(Header);
            AddSubview(Title);
            AddSubview(TypeView);
            AddSubview(AvatarView);
            AddSubview(JoinClassView);
            AddSubview(Username);
            AddSubview(Bio);
            AddSubview(Cancel);

            Access.vc.View.AddSubview(this);
        }

        private void InitializeJoinClass()
        {
            Title1 = new UITextView();
            Title1.Text = "Enter Class Code";
            Title1.Frame = new CGRect(0, 0, Frame.Width, 48);
            Title1.Font = Fonts.Settings_Title;
            Title1.BackgroundColor = UIColor.Clear;
            Title1.TextAlignment = UITextAlignment.Center;
            Title1.Editable = false;
            Title1.UserInteractionEnabled = false;

            CodeView = new UITextField();
            CodeView.Frame = new CGRect(0, Frame.Height / 2, 256, 64);
            CodeView.Font = Fonts.Settings_Title;
            CodeView.KeyboardType = UIKeyboardType.NumberPad;
        }

        private void RenderJoinClass()
        {
            AddSubview(Title1);
            AddSubview(CodeView);
        }

        private void ClearSubviews()
        {
            for (int i = 0; i < Subviews.Length; i++)
            {
                Subviews[i].RemoveFromSuperview();
            }
        }

        [Export("JoinClass")]
        public void JoinClass()
        {
            ClearSubviews();

            X = C.X_MID - 192;
            Y = C.Y_MID - 128;

            Frame = new CGRect(X, Y, 384, 256);
            InitializeJoinClass();
            RenderJoinClass();
        }

    }
}