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
    static class AnnouncementsView
    {

        private static bool init = false;
        private static List<String> announcements = new List<String>();

        public static UITextView Title;
        public static UITextView Display;

        static AnnouncementsView()
        {
          if (!init)
           Initialize();
        }

        private static void Initialize()
        {

            Title = new UITextView();
            Title.Frame = new CGRect(C.X_MID - 92, 48, 184, 64);
            Title.BackgroundColor = UIColor.Clear;
            Title.Text = "Announcements";
            Title.Font = Fonts.Settings_Title;
            Title.Editable = false;

            Display = new UITextView();
            Display.Frame = new CGRect(0, 88, C.X_MAX, C.Y_MAX);
            Display.BackgroundColor = UIColor.Clear;
            Display.TextColor = UIColor.White;
            Display.Text = "This is an example Announcment\n TODO:\n - Make Announcment object so we have complete control of the overall sexiness.\n - Bold title\n - recieve announcments as json from DB";
            Display.Font = Fonts.Announcements_Text;
            Display.UserInteractionEnabled = false;
            Display.Editable = false;
        }

        public static void AddToView()
        {
            Access.vc.View.AddSubview(Title);
            Access.vc.View.AddSubview(Display);
        }
    }
}