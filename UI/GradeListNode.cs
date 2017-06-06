using CoreGraphics;
using ShaftesApp.Net;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using ObjCRuntime;
using Foundation;
using System.Diagnostics;
using ShaftesApp.Views;

namespace ShaftesApp.UI
{
    class GradeListNode
        : UIView
    {

        public static List<GradeListNode> reports = new List<GradeListNode>();
        public static GradeListNode PoppedNode;

        public UITextView Title;
        public UITextView Percentages;
        public UITextView Assignments;

        private String _title;
        private String[] _percents;
        private String[] _assignments;
        private String[] _marks;
        private bool _popped = false;
        private Room room;
        private bool init = false;
        private int Y;
        private UITapGestureRecognizer _tap;
        private UIPanGestureRecognizer _pan;

        public GradeListNode(Room room, int x)
        {

            Y = x * 128;
            PoppedNode = this;

            this.room = room;
            _title = room.Name;
            _assignments = new String[room.Messages.Count];
            _marks = new String[room.Messages.Count];

            for (int i = 0; i < room.Messages.Count; i++)
            {
                _assignments[i] = room.Messages[i].Title;
                //replace X with mark from client
                _marks[i] = $"X/{room.Messages[i].Weight}";
            }

            if (!init)
                Initialize();

            reports.Add(this);
        }

        private void Initialize()
        {
            init = true;

            //y is relative to scrollview
            Frame = new CGRect(0, Y, C.X_MAX, 128);

            _tap = new UITapGestureRecognizer();
            _tap.NumberOfTapsRequired = 1;
            _tap.AddTarget(this, new Selector("TapGesture"));
            AddGestureRecognizer(_tap);

            _pan = new UIPanGestureRecognizer();
            _pan.MinimumNumberOfTouches = 1;
            _pan.CancelsTouchesInView = false;
            _pan.AddTarget(this, new Selector("PanGesture"));
            //AddGestureRecognizer(_pan);

            UserInteractionEnabled = true;
            //Layer.BorderColor = UIColor.Green.CGColor;
            //Layer.BorderWidth = 3;

            //y is relative to this uiview now
            Y = 0;

            Title = new UITextView();
            Title.Frame = new CGRect(0, Y, C.X_MAX, 32);
            Title.Text = _title;
            Title.TextAlignment = UITextAlignment.Center;
            Title.BackgroundColor = UIColor.Clear;
            Title.TextColor = UIColor.White;
            Title.Editable = false;
            Title.UserInteractionEnabled = false;

            //Assignments = new SRButton(0, Y + 32, C.X_MAX, 64, new Selector("DeadFunc"));
            Assignments = new UITextView();
            Assignments.Frame = new CGRect(0, Y + 32, C.X_MAX, 64);
            Assignments.ScrollEnabled = false;
            Assignments.BackgroundColor = UIColor.Clear;
            Assignments.Editable = false;
            Assignments.UserInteractionEnabled = false;

            //Assignments.View.TouchUpInside += (sender, e) =>
            //{
            //    PopAssignments();
            //};

            //Assignments.View.TouchUpOutside += (sender, e) =>
            //{
            //    UnPopAssignments();
            //};

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _assignments.Length; i++)
            {
                sb.AppendLine(_assignments[i] + "__________" + _marks[i]);
            }
            Assignments.Text = sb.ToString();
            Assignments.Layer.BorderWidth = 1;
            Assignments.Layer.BorderColor = UIColor.White.CGColor;

            Percentages = new UITextView();
            Percentages.Frame = new CGRect(0, Y + 96, C.X_MAX, 32);
            Percentages.Text = room.Weights;
            Percentages.BackgroundColor = UIColor.Clear;
            Percentages.TextAlignment = UITextAlignment.Center;
            Percentages.Editable = false;
            Percentages.UserInteractionEnabled = false;
        }

        public void AddToView(UIView v)
        {
            this.AddSubview(Title);
            this.AddSubview(Assignments);
            this.AddSubview(Percentages);
            v.AddSubview(this);
        }

        public void PopAssignments()
        {
            if (_popped)
            {
                UnPopAssignments();
                return;
            }

            if (PoppedNode != null)
                PoppedNode.UnPopAssignments();

            Assignments.Frame = new CGRect(0, Y, C.X_MAX, 128);
            PoppedNode = this;
            _popped = true;
        }

        public void UnPopAssignments()
        {
            if (!_popped)
                return;

            Assignments.Frame = new CGRect(0, Y + 32, C.X_MAX, 64);
            _popped = false;
        }

        [Export("TapGesture")]
        public void TapGesture()
        {
            PopAssignments();
        }

        [Export("PanGesture")]
        public void PanGesture()
        {
            Debug.WriteLine("pannnnnn amnnnnn");
            PoppedNode.UnPopAssignments();
        }
    }
}
