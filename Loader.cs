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

            //logo background
            UIView logoBack = Access.newRect(0, 0, vc.ViewWidth, 32, UIColor.Black);
            render(logoBack);

            //shaftes logo
            UIImageView logo = new UIImageView(UIImage.FromBundle("main_logo"));
            logo.Frame = new CGRect(C.X_MID - 64, 0, 128, 32);
            render(logo);

            //bars button
            SRButton bars = new SRButton(C.MOX, C.MOY + 16, 32, 32, new Selector("BarsFunc"), "button_bars");
            bars.Render();

            //little seperator line above icons
            UIView seperator = Access.newRect(0, C.Y_MAX - 60, C.X_MAX, 2, UIColor.Gray);
            render(seperator);

            //setting button
            SRButton settings = new SRButton(C.X_MAX - 74, 0, 32, 32, new Selector("SettingsFunc"), "button_settings");
            settings.Render();

            //add things based on appstate
            if (astate == AppState.ANNOUNCEMENTS)
            {

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
            else if (astate == AppState.PROFILE)
            {
                ProfileView.AddToView();
            }
            //render bottom bar

            //announcements button 
            SRButton announce = new SRButton(C.X_MID - 176, C.Y_MAX - 56, 64, 64, new Selector("AnnounceFunc"), "button_announcements");
            announce.Render();

            //tutor button
            SRButton tutor = new SRButton(C.X_MID - 104, C.Y_MAX - 56, 64, 64, new Selector("TutorFunc"), "button_tutor");
            tutor.Render();

            //forum button
            SRButton forum = new SRButton(C.X_MID - 32, C.Y_MAX - 56, 64, 64, new Selector("ForumFunc"), "button_forum");
            forum.Render();

            //grades button
            SRButton grades = new SRButton(C.X_MID + 40, C.Y_MAX - 56, 64, 64, new Selector("GradesFunc"), "button_grades");
            grades.Render();

            //profile button
            SRButton profile = new SRButton(C.X_MID + 112, C.Y_MAX - 56, 64, 64, new Selector("ProfileFunc"), "button_profile");
            profile.Render();

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