using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ShaftesApp.Views
{
    class AnnouncementsView
    {

        public static CGRect Bounds;

        private bool init = false;
        private List<String> announcements = new List<String>();

        private UITextView Title;
        private UITextView Display;

        public AnnouncementsView()
        {

            if (!init)
                Initialize();
            AddToView();
        }

        private void Initialize()
        {

            Title = new UITextView();
            Title.Frame = new CGRect(C.X_MID - 64, 0, 128, 64);
            Title.BackgroundColor = UIColor.Clear;
            Title.Text = "Announcements";
            Title.Font = Fonts.Settings_Title;

            Display = new UITextView();
            Display.Frame = new CGRect(0, 64, C.X_MAX, C.Y_MAX);
            Display.BackgroundColor = UIColor.Clear;
            Display.TextColor = UIColor.White;
            Display.Text = "This is an example Announcment\n TODO:\n - Make Announcment object so we have complete control of the overall sexiness.\n - Bold title\n - recieve announcments as json from DB";
            Display.Font = Fonts.Announcements_Text;
        }

        private void AddToView()
        {
            Access.vc.View.AddSubview(Title);
            Access.vc.View.AddSubview(Display);
        }

    }
}