﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ShaftesApp.UI
{
    class UIToggle
        : UIView
    {

        private bool _init = false;

        private int X, Y, WIDTH, HEIGHT;

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

            Frame = new CGRect(X, Y, WIDTH, HEIGHT);

            TextView = new UITextView();
            TextView.Frame = new CGRect(0, 0, WIDTH, HEIGHT);
            TextView.Text = Display;
            TextView.BackgroundColor = UIColor.Clear;

            AddToView();
        }

        private void AddToView()
        {
            AddSubview(TextView);
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

            AddSubview(ImageView);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            ix++;

            if ((_imageMode && ix >= Images.Length - 1) || ix >= Values.Length - 1)
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