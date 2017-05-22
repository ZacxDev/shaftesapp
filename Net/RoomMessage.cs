using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace ShaftesApp.Net
{
    public class RoomMessage
    {

        public int Y;
        public String Title;
        public String Body;
        public bool Assignment = false;

        public UIView Background;
        private UITextView TitleView;
        private UITextView BodyView;
        private UITextView GradeView;
        private UITextView RubrikView;

        public RoomMessage(String title, String body, int y)
        {
            Y = y;
            Title = title;
            Body = body;

            Initialize();
        }

        private void Initialize()
        {
            Background = new UIView();
            Background.Frame = new CGRect(0, Y, Access.vc.ViewWidth, 0);

            TitleView = new UITextView();
            TitleView.Frame = new CGRect(C.X_MID - 32, Y, 64, 16);
            TitleView.Font = Fonts.Settings_Title;

            BodyView = new UITextView();
            BodyView.Font = Fonts.Announcements_Text;
            BodyView.Text = Body;
            BodyView.Frame = new CGRect(0, Y + 16, Access.vc.ViewWidth, 0);

            GradeView = new UITextView();
            GradeView.Font = Fonts.Announcements_Text;
            GradeView.Text = "/35";
            GradeView.Frame = new CGRect(C.X_MAX - 32, Y + 16, 16, 16);

            RubrikView = new UITextView();
            RubrikView.Text = "Looks /5\n Looks /10\n Looks /20";
            RubrikView.Font = Fonts.Announcements_Text;
            RubrikView.Frame = new CGRect(0, Y + 16, Access.vc.ViewWidth, 0);
            RubrikView.Layer.BorderColor = UIColor.White.CGColor;
            RubrikView.Layer.BorderWidth = 2;

        }

        public void AddToView(UIView v)
        {

            v.AddSubview(Background);
            v.AddSubview(TitleView);
            v.AddSubview(GradeView);
            v.AddSubview(BodyView);
            v.AddSubview(RubrikView);

            CGRect fr = BodyView.Frame;
            fr.Size = new CGSize(fr.Width, BodyView.ContentSize.Height);
            BodyView.Frame = fr;
            Background.Frame = fr;
            RubrikView.Frame = new CGRect(0, Y + fr.Size.Height * 0.8, Access.vc.ViewWidth, fr.Size.Height * 0.2);

        }

    }
}
