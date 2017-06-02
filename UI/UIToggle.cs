using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using System.Diagnostics;

namespace ShaftesApp.UI
{
    class UIToggle
        : UIView
    {

        private bool _init = false;

        private int X, Y, WIDTH = 256, HEIGHT = 128;

        private String[] Values;
        public String Display;
        public int ix = 0;

        private UITextView TextView;
        private UIImageView ImageView;
        private bool locked = false;
        private bool _imageMode = false;
        private UIImage[] Images;
        private UIImage Image;


        public UIToggle(String a, String b)
        {
            Values = new String[] { a, b };
            Initialize();
        }

        private void Initialize()
        {
            if (_init)
                return;
            _init = true;

            UserInteractionEnabled = true;
            Frame = new CGRect(X, Y, WIDTH, HEIGHT);

            TextView = new UITextView();
            TextView.Frame = new CGRect(0, 0, WIDTH, HEIGHT);
            TextView.Text = Display;
            TextView.BackgroundColor = UIColor.Clear;
            TextView.Editable = false;
            TextView.UserInteractionEnabled = false;

            AddToView();
        }

        private void AddToView()
        {
            AddSubview(TextView);
        }

        public void SetFrame(CGRect r)
        {
            Frame = r;
            X = (int) r.X;
            Y = (int) r.Y;
            WIDTH = (int) r.Width;
            HEIGHT = (int) r.Height;
        }

        public void SetImages(UIImage[] imgs)
        {
            _imageMode = true;
            Images = imgs;

            Image = Images[0];
            ImageView = new UIImageView();
            ImageView.Image = Image;
            ImageView.Frame = new CGRect(0, 0, WIDTH, HEIGHT);
            ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            ImageView.UserInteractionEnabled = false;

            AddSubview(ImageView);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            ix++;

            if ((_imageMode && ix >= Images.Length ) || ix >= Values.Length)
            {
                ix = 0;
            }

            if (_imageMode)
            {
                Image = Images[ix];
                ImageView.Image = Image;
            }
            else
            {
                Display = Values[ix];
                TextView.Text = Display;
            }
        }

    }
}