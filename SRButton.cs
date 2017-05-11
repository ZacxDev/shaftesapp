using System;
using System.Collections.Generic;
using MonoTouch;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;
namespace ShaftesApp
{
    public class SRButton
    {
        public static List<SRButton> buttons = new List<SRButton>();

        int X, Y, Width, Height;
        public CGRect bounds;

        public UIButton View;
        public Selector Select;
        UIImage Image;

        AppState state;

        public SRButton(int x, int y, int width, int height, Selector select, String path = "button")
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            //init here becuz wont move
            bounds = new CGRect(x, y, width, height);

            Select = select;
            View = new UIButton();
            View.Frame = bounds;
            Image = UIImage.FromBundle(path);
            View.SetImage(Image, UIControlState.Normal);
            View.AddTarget(ViewController.BtnHandler, Select, UIControlEvent.TouchUpInside);
            buttons.Add(this);
        }

        public void Render()
        {
            Access.vc.View.AddSubview(View);
        }

    }
}