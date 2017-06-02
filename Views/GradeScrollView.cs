using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.UI;
using System.Diagnostics;
using ObjCRuntime;

namespace ShaftesApp.Views
{
    class GradeScrollView
        : UIScrollView
    {

        UITapGestureRecognizer tap = new UITapGestureRecognizer();

        public GradeScrollView()
        {
            //close popped assignments on drag
            this.DraggingStarted += (s, e) =>
            {
                GradeListNode.PoppedNode.UnPopAssignments();
            };

            tap.NumberOfTouchesRequired = 1;
            tap.CancelsTouchesInView = false;
            tap.Enabled = true;
            tap.AddTarget(this, new Selector("Tap"));
            AddGestureRecognizer(tap);

            Frame = new CGRect(0, 96, C.X_MAX, C.Y_MAX - 96);
            DirectionalLockEnabled = true;
            ScrollEnabled = true;
            Bounces = true;
            AlwaysBounceVertical = true;
            ContentSize = new CGSize(C.X_MAX, GradeListNode.reports.Count * 128 + 32);
        }

        [Export("Tap")]
        public void Tap()
        {
            //dont delete me pls things will break (unrecognized selector on tap addtarget)
        }

    }
}