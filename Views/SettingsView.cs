using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ShaftesApp.Views
{
    class SettingsView
    {

        public static CGRect Bounds;

        private bool init = false;

        private UIView Background;
        private UITextView Title;

        public SettingsView()
        {

            if (!init)
                Initialize();
            new PrimeView();
            AddToView();
        }

        public void Initialize()
        {
            Background = new UIView();
            Background.Frame = new CGRect(C.X_MID - 128, 64, 256, 512);
            Background.BackgroundColor = UIColor.Gray;

            Bounds = Background.Frame;

            Title = new UITextView();
            Title.Frame = new CGRect(C.X_MID - 32, 74, 128, 64);
            Title.BackgroundColor = UIColor.Gray;
            Title.Text = "Settings";
            Title.Font = Fonts.Settings_Title;
        }

        private void AddToView()
        {
            Access.vc.View.AddSubview(Background);
            Access.vc.View.AddSubview(Title);
        }

    }
}