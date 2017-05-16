using System;
using UIKit;
using CoreGraphics;
using MonoTouch;
using Foundation;
using ObjCRuntime;
namespace ShaftesApp
{
    //THIS CLASS DOES NOTHING, FEEL FREE TO MESS WITH IT
    //what if it does something and you're just ignoring it #allcodeisuseful
    public class PrimeView : UIView
    {

        public static PrimeView CurrentPrime;

        int X, Y, Width, Height;

        public PrimeView()
            : this(0, 0, Access.vc.ViewWidth, Access.vc.ViewHeight)
        {
        }

        public PrimeView(int x, int y, int width, int height)
            : base()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Frame = new CGRect(X, Y, Width, Height);
            CurrentPrime = this;
            Access.vc.View.AddSubview(this);
        }

        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            Console.WriteLine("n");
            UITouch t = touches.AnyObject as UITouch;
            CGPoint tap = t.LocationInView(this);

            // check loaded buttons
            //for (int i = 0; i < SRButton.buttons.Count; i++)
            //{
            //    SRButton b = SRButton.buttons[i];

            //    if (b.bounds.Contains(tap))
            //    {
            //        //Access.vc.ButtonFunction(b);
            //        PerformSelector(new Selector("playfunc:"), new NSString("ddd"), 0);
            //        break;
            //    }

            //}
        }

    }

    public class Loader
    {
        private ViewController vc;

        public Loader(AppState astate)
        {
            vc = Access.vc;
            clearSubviews();

            //main backgroud fill rect
            render(Access.newRect(C.MOX, C.MOY, vc.ViewWidth, vc.ViewHeight, UIColor.DarkGray));

            //shaftes logo
            UIImageView logo = new UIImageView(UIImage.FromBundle("main_logo"));
            logo.Frame = new CGRect(0, 0, 256, 64);
            render(logo);

            //bars button
            SRButton bars = new SRButton(C.MOX, C.MOY + 16, 32, 32, new Selector("BarsFunc"), "button_bars");
            bars.Render();

            //announcements button
            SRButton announce = new SRButton(0, C.Y_MAX - 64, 64, 64, new Selector("AnnounceFunc"), "button_announcements");
            announce.Render();

            //tutor button
            SRButton tutor = new SRButton(96, C.Y_MAX - 64, 64, 64, new Selector("TutorFunc"), "button_tutor");
            tutor.Render();

            //add things based on appstate
            if (astate == AppState.MAIN)
            {
                
                //ugly title box <- make pretty pls
                //render(Access.newTextView(C.MOX + 50, C.MOY + 50, 256, 32, "ShaftesApp", UIColor.White));


                //render sidebar thingy
                if (ButtonHandler.BARS_OPEN)
				{
                    //sidebar background fill rect, XBARINSET = space to main background
                    render(Access.newRect(0, 0, C.X_BAR_INSET, vc.ViewHeight, UIColor.White));

                    //add sidebar buttons for things, options mby

                    //little seperator for constant button and groups
                    render(Access.newRect(0, 96, C.X_BAR_INSET, 3, UIColor.Gray));

				}

            }
            //var pv = new PrimeView();
        }

        private void render(UIView v)
        {
            vc.View.AddSubview(v);
        }

        private void clearSubviews()
        {
            for (int i = 0; i < vc.View.Subviews.Length; i++)
            {
                vc.View.Subviews[i].RemoveFromSuperview();
            }
        }

		

    }
}