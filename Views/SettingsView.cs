using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.UI;

namespace ShaftesApp.Views
{
    class SettingsView
    {

        public static CGRect Bounds;

        private bool init = false;

        private UIView Background;
        private UITextView Title;
        private UIToggle TypeView;
        private UIToggle CanWork;

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

            Title = new UITextView();
            Title.Frame = new CGRect(X, Y, 256, 64);
            Title.BackgroundColor = UIColor.Gray;
            Title.Text = "Settings";
            Title.Font = Fonts.Settings_Title;

            TypeView = new UIToggle("Option1", "Option2");
            TypeView.SetImages(new UIImage[] { UIImage.FromBundle("settings_0"), UIImage.FromBundle("settings_1") });
            TypeView.SetFrame(new CGRect(X + 16, C.Y_MAX - 256, 240, 128));
        }

        private void AddToView()
        {
            Access.vc.View.AddSubview(Background);
            Access.vc.View.AddSubview(Title);
            Access.vc.View.AddSubview(TypeView);
        }

    }
}