using System;
using Mono;
using Foundation;
using UIKit;
using ShaftesApp.Net;

namespace ShaftesApp
{
    public enum AppState
    { ANNOUNCEMENTS, TUTOR, FORUMS, PROFILE }

    public partial class ViewController : UIViewController
    {
        public static Loader LoaderInstance;
        public static ButtonHandler BtnHandler;
        private static Access _Access;
        public static Client Client;

        public AppState state;
        public int ViewHeight, ViewWidth;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Client = new Client();
            // Perform any additional setup after loading the view, typically from a nib
            Console.WriteLine("ffff");
            ViewWidth = (int)View.Bounds.Width * 2;
            ViewHeight = (int)View.Bounds.Height * 2;

            new C(this);
            _Access = new Access(this);
            BtnHandler = new ButtonHandler();
            LoaderInstance = new Loader(state);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void changeView(AppState s)
        {
            state = s;
            LoaderInstance = new Loader(state);
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

    }
}