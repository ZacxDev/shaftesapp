using System;
using UIKit;
using CoreGraphics;
using MonoTouch;
using Foundation;
using ObjCRuntime;
using ShaftesApp.Views;

namespace ShaftesApp
{
    //THIS CLASS DOES NOTHING, FEEL FREE TO MESS WITH IT
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

            //if tap is outside setting window thingy, reload current view without settings window (effectivly closing it)
            if (Loader.SETTINGS_OPEN)
                new Loader(Loader.CurrentState);

        }

    }

    public class Loader
    {
        private ViewController vc;

        public static bool SETTINGS_OPEN = false;
        public static AppState CurrentState;

        public Loader(AppState astate)
        {
            SETTINGS_OPEN = false;
            CurrentState = astate;
            vc = Access.vc;
            clearSubviews();

            //main backgroud fill rect
            render(Access.newRect(C.MOX, C.MOY, vc.ViewWidth, vc.ViewHeight, UIColor.DarkGray));

            //shaftes logo
            UIImageView logo = new UIImageView(UIImage.FromBundle("main_logo"));
            logo.Frame = new CGRect(0, 0, 256, 64);
            //render(logo);

            //bars button
            SRButton bars = new SRButton(C.MOX, C.MOY + 16, 32, 32, new Selector("BarsFunc"), "button_bars");
            bars.Render();

            //little seperator line above icons
            UIView seperator = Access.newRect(0, C.Y_MAX - 69, C.X_MAX, 2, UIColor.Gray);
            render(seperator);

            //announcements button (each btn seperated by 72px)
            SRButton announce = new SRButton(C.X_MID - 178, C.Y_MAX - 64, 48, 48, new Selector("AnnounceFunc"), "button_announcements");
            announce.Render();

            //tutor button
            SRButton tutor = new SRButton(C.X_MID - 106, C.Y_MAX - 64, 48, 48, new Selector("TutorFunc"), "button_tutor");
            tutor.Render();

            //forum button
            SRButton forum = new SRButton(C.X_MID - 24, C.Y_MAX - 64, 48, 48, new Selector("ForumFunc"), "button_forum");
            forum.Render();

            //grades button
            SRButton grades = new SRButton(C.X_MID + 48, C.Y_MAX - 64, 48, 48, new Selector("GradesFunc"), "button_grades");
            grades.Render();

            //profile button
            SRButton profile = new SRButton(C.X_MID + 120, C.Y_MAX - 64, 48, 48, new Selector("ProfileFunc"), "button_profile");
            profile.Render();

            //setting button
            SRButton settings = new SRButton(C.X_MAX - 74, 16, 32, 32, new Selector("SettingsFunc"), "button_settings");
            settings.Render();

            //add things based on appstate
            if (astate == AppState.ANNOUNCEMENTS)
            {

                //ugly title box <- make pretty pls
                //render(Access.newTextView(C.MOX + 50, C.MOY + 50, 256, 32, "ShaftesApp", UIColor.White));

                new AnnouncementsView();

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
            else if (astate == AppState.TUTOR)
            {

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

        public static void ShowSettings()
        {
            new SettingsView();
            SETTINGS_OPEN = true;
        }

    }
}