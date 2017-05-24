using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using CoreGraphics;

namespace ShaftesApp.Views
{
    class RoomsScrollView
        : UIScrollView
    {

        public RoomsScrollView(int i)
        {
            //this = new UIScrollView();
            this.BackgroundColor = UIColor.DarkGray;
            this.Frame = new CGRect(Access.vc.ViewWidth * 2, 64, Access.vc.ViewWidth, Access.vc.ViewHeight - 96);
            this.DirectionalLockEnabled = true;
            //this.ContentOffset = new CGPoint(0, rooms.Count * 64);
            this.ContentSize = new CGSize(Access.vc.ViewWidth, i * 96 + 64);
            this.ScrollEnabled = true;
            this.Bounces = true;
            this.AlwaysBounceVertical = true;
            this.CanCancelContentTouches = true;
            //this.DelaysContentTouches = true;
        }


        public override bool TouchesShouldCancelInContentView(UIView view)
        {
            if (view is UIButton)
                return true;

            return base.TouchesShouldCancelInContentView(view);
        }

    }
}
