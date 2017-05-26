using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ShaftesApp.Views;
using CoreGraphics;
using ObjCRuntime;
using System.Diagnostics;

namespace ShaftesApp.View
{
    public class ViewDismiss
        : NSObject
    {
        public void DismissProfileView(double i)
        {
            UIView.Animate(i, 0, UIViewAnimationOptions.CurveLinear, () =>
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

        public void PresentProfileView()
        {
            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseIn, () =>
            {
                ProfileView.Avatar.Alpha = 1;
                ProfileView.AvatarFrame.Alpha = 1;
                ProfileView.Bio.Alpha = 1;
                ProfileView.Grade.Alpha = 1;
                ProfileView.Rooms.TextView.Alpha = 1;
                ProfileView.Username.Alpha = 1;
            }, () => { }
                );
        }
    }
}