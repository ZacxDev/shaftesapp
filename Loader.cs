using System;
using UIKit;
using CoreGraphics;
using MonoTouch;
using Foundation;
using ObjCRuntime;
using ShaftesApp.Views;
using ShaftesApp.Net;
using System.Diagnostics;

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
        public static Room Room;

        private bool _initViews = false;

        //header
        bool HeaderInit = false;
        UIImageView logo;
        UIView logoBack;
        SRButton settings;
        SRButton bars;

        //taskbar
        bool TaskbarInit = false;
        UIView footer;
        UIView seperator;
        SRButton announce;
        SRButton tutor;
        SRButton forum;
        SRButton grades;
        SRButton profile;

        public Loader(AppState astate)
        {
            ViewController.LoaderInstance = this;
            SETTINGS_OPEN = false;
            CurrentState = astate;
            vc = Access.vc;
            ProfileView.Initialize();
            clearSubviews();

            RenderView(astate);

        }

        public void RenderView(AppState astate)
        {
            if (!_initViews)
                InitViews();

            //background
            ShowBackground();

            //header
            ShowHeader();

            //add things based on appstate
            if (astate == AppState.ANNOUNCEMENTS)
            {

                AnnouncementsView.AddToView();

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
            else if (astate == AppState.ROOM)
            {
                new RoomView(Room);
            }
            else if (astate == AppState.GRADES)
            {
                GradesView.AddToView();
            }

            ShowTaskbar();

        }

        private void render(UIView v)
        {
            vc.View.AddSubview(v);
        }

        public void clearSubviews()
        {
            for (int i = 0; i < vc.View.Subviews.Length; i++)
            {
                vc.View.Subviews[i].RemoveFromSuperview();
            }
        }

        public void ShowBackground()
        {
            //main backgroud fill rect
            render(Access.newRect(C.MOX, C.MOY, vc.ViewWidth, vc.ViewHeight, UIColor.DarkGray));
        }

        private void InitHeader()
        {
            settings = new SRButton(C.X_MAX - 74, 12, 32, 32, new Selector("SettingsFunc"), "button_settings");
            bars = new SRButton(C.MOX, C.MOY + 16, 32, 32, new Selector("BarsFunc"), "button_bars");
            logo = new UIImageView(UIImage.FromBundle("main_logo"));
            logoBack = Access.newRect(0, 0, vc.ViewWidth, 48, UIColor.Black);

            HeaderInit = true;
        }

        public void ShowHeader()
        {
            if (!HeaderInit)
                InitHeader();

            //logo background
            render(logoBack);

            //shaftes logo
            logo.Frame = new CGRect(C.X_MID - 64, 0, 128, 48);
            render(logo);

            //settings button
            settings.Render(vc.View);

            //bars
            bars.Render(vc.View);
        }

        private void InitTaskbar()
        {
            //render bottom bar
            footer = Access.newRect(0, C.Y_MAX - 40, C.X_MAX, 40, UIColor.DarkGray);

            //little seperator line above icons
            seperator = Access.newRect(0, C.Y_MAX - 40, C.X_MAX, 2, UIColor.Gray);
            
            //announcements button 
            announce = new SRButton(C.X_MID - 176, C.Y_MAX - 36, 32, 32, new Selector("AnnounceFunc"), "button_announcements");

            //tutor button
            tutor = new SRButton(C.X_MID - 104, C.Y_MAX - 36, 32, 32, new Selector("TutorFunc"), "button_tutor");

            //forum button
            forum = new SRButton(C.X_MID - 32, C.Y_MAX - 36, 32, 32, new Selector("ForumFunc"), "button_forum");

            //grades button
            grades = new SRButton(C.X_MID + 40, C.Y_MAX - 36, 32, 32, new Selector("GradesFunc"), "button_grades");

            //profile button
            profile = new SRButton(C.X_MID + 112, C.Y_MAX - 36, 32, 32, new Selector("ProfileFunc"), "button_profile");

            TaskbarInit = true;
        }

        public void ShowTaskbar()
        {

            if (!TaskbarInit)
                InitTaskbar();

            //render bottom bar
            render(footer);

            //little seperator line above icons
            render(seperator);

            //announcements button 
            announce.Render(vc.View);

            //tutor button
            tutor.Render(vc.View);

            //forum button
            forum.Render(vc.View);

            //grades button
            grades.Render(vc.View);

            //profile button
            profile.Render(vc.View);
        }

        private void InitViews()
        {
            _initViews = true;
            ProfileView.Initialize();
            ProfileView.InitRooms();
            GradesView.Initialize();
        }

        public static void ShowSettings()
        {
            new SettingsView();
            SETTINGS_OPEN = true;
        }

    }
}