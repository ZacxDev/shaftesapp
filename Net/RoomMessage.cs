using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UIKit;

namespace ShaftesApp.Net
{
    public class RoomMessage
    {

        public int Y = 0;
        public String Title;
        public int Weight;
        public String Body;
        public bool Assignment = false;

        public UIView Background;
        private UITextView TitleView;
        private UITextView BodyView;
        private UITextView GradeView;
        private UITextView RubrikView;

        public RoomMessage(String title, String body, int weight)
        {
            Title = title;
            Body = body;
            Weight = weight;
            Initialize();
        }

        private void Initialize()
        {
            Background = new UIView();
            
            Background.Frame = new CGRect(0, Y, Access.vc.ViewWidth, 256);
            Background.Layer.BorderColor = UIColor.White.CGColor;
            Background.Layer.BorderWidth = 3;
            
            TitleView = new UITextView();
            TitleView.Text = Title;
            TitleView.Frame = new CGRect(0, Y, C.X_MAX, 32);
            TitleView.Center = new CGPoint(C.X_MID, Y);
            TitleView.Font = Fonts.Settings_Title;
            TitleView.BackgroundColor = UIColor.Clear;
            TitleView.TextColor = UIColor.White;
            
            BodyView = new UITextView();
            BodyView.Font = Fonts.Announcements_Text;
            BodyView.Text = Body;
            BodyView.Frame = new CGRect(8, Y + 32, Access.vc.ViewWidth - 8, 138);
            BodyView.ScrollEnabled = true;
            BodyView.ContentSize = new CGSize(0, BodyView.ContentSize.Height);
            BodyView.BackgroundColor = UIColor.Clear;
            BodyView.TextColor = UIColor.White;
            
            GradeView = new UITextView();
            GradeView.Font = Fonts.Announcements_Text;
            GradeView.Text = "/35";
            GradeView.Frame = new CGRect(C.X_MAX - 32, Y + 16, 32, 32);
            GradeView.BackgroundColor = UIColor.Clear;
            GradeView.TextColor = UIColor.White;
            
            RubrikView = new UITextView();
            RubrikView.Text = "Rubrik: \nLooks /5 \nLooks /10 \nLooks /20";
            RubrikView.Font = Fonts.Announcements_Text;
            RubrikView.Frame = new CGRect(0, Y + 160, Access.vc.ViewWidth, 96);
            RubrikView.Layer.BorderColor = UIColor.White.CGColor;
            RubrikView.Layer.BorderWidth = 2;
            RubrikView.BackgroundColor = UIColor.Clear;
            RubrikView.TextColor = UIColor.Red;
        }

        public void AddToView(UIView v)
        {

            v.AddSubview(Background);
            v.AddSubview(BodyView);
            v.AddSubview(TitleView);
            v.AddSubview(GradeView);
            v.AddSubview(RubrikView);
            //CGRect fr = BodyView.Frame;
            //fr.Size = new CGSize(fr.Width, BodyView.ContentSize.Height);
            //BodyView.Frame = fr;
            //Background.Frame = fr;
            //RubrikView.Frame = new CGRect(0, Y + fr.Size.Height * 0.8, Access.vc.ViewWidth, fr.Size.Height * 0.2);
        }

        public void SetY(int i)
        {
            Y = i;
            RubrikView.Frame = new CGRect(0, Y + 160, Access.vc.ViewWidth, 96);
            GradeView.Frame = new CGRect(C.X_MAX - 32, Y + 16, 32, 32);
            BodyView.Frame = new CGRect(8, Y + 32, Access.vc.ViewWidth - 8, 138);
            TitleView.Frame = new CGRect(0, Y, C.X_MAX, 32);
            Background.Frame = new CGRect(0, Y, Access.vc.ViewWidth, 256);
        }

    }
}
