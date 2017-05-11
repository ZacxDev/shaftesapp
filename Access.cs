using System;
using UIKit;
using CoreGraphics;
namespace ShaftesApp
{
    public class Access
    {
        public static ViewController vc;
        public Access(ViewController vc)
        {
            Access.vc = vc;
        }

        public static UITextView newTextView(int x, int y, int width, int height, String text, UIColor c) {

            var v = new UITextView();
            v.Frame = new CGRect(x, y, width, height);
            //v.TextColor = c;
            v.Text = text;

            return v;
        }

        public static UIButton newButtonView(int x, int y, int width, int height, String text = "button.png") {

            var v = new UIButton();
            v.Frame = new CGRect(x, y, width, height);
            v.SetTitle(text, UIControlState.Normal);
            v.SetImage(UIImage.FromBundle(text), UIControlState.Normal);

            return v;
        }

        public static UIView newRect(int x, int y, int width, int height, UIColor c) {
            UIView v = new UIView();
            v.Frame = new CGRect(x, y, width, height);
            v.BackgroundColor = c;
            Console.WriteLine(v.Frame.GetMinY());
            return v;
        }
    }
}