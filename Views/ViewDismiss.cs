using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ShaftesApp.Views;
using CoreGraphics;
using ObjCRuntime;

namespace ShaftesApp.View
{
    public class ViewDismiss
        : NSObject
    {

        private NSThread ProfileFadeThread;

        public void DismissProfileView()
        {
            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseIn, () =>
            {
                ProfileView.Avatar.Alpha = 0;
                ProfileView.AvatarFrame.Alpha = 0;
                ProfileView.Bio.Alpha = 0;
                ProfileView.Grade.Alpha = 0;
                ProfileView.Rooms.TextView.Alpha = 0;
                ProfileView.Username.Alpha = 0;
            }, () => { }
                );
        }
    }
}