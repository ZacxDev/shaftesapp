using System;
using Mono;
using Foundation;
using UIKit;
using ShaftesApp.Net;
using ShaftesApp.View;
using System.Diagnostics;

namespace ShaftesApp
{
    public enum AppState
    { ANNOUNCEMENTS, TUTOR, FORUMS, PROFILE, GRADES, ROOM }

    public partial class ViewController : UIViewController
    {
        public static Loader LoaderInstance;
        public static ButtonHandler BtnHandler;
        public static ViewDismiss ViewDismiss;
        private static Access _Access;
        public static Client Client;
        private UIImagePickerController ImagePicker;

        public AppState state;
        public int ViewHeight, ViewWidth;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib
            //Console.WriteLine("ffff");
            ViewWidth = (int)View.Bounds.Width * 2;
            ViewHeight = (int)View.Bounds.Height * 2;

            new C(this);
            _Access = new Access(this);

            Client = new Client();
            BtnHandler = new ButtonHandler();
            ViewDismiss = new ViewDismiss();
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
            LoaderInstance.RenderView(s);
            //LoaderInstance = new Loader(state);
        }

        public void SelectImage()
        {
            ImagePicker = new UIImagePickerController();
            //ImagePicker.Delegate = this;
            ImagePicker.AllowsEditing = true;
            ImagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            ImagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            ImagePicker.Canceled += (sender, e) =>
            {
                ImagePicker.DismissViewController(true, null);
            };

            PresentViewController(ImagePicker, true, null);   
        }

        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {

            UIImage i = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            Client.Image = i;
            ImagePicker.DismissViewController(true, null);
            new Loader(state);
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

    }
}