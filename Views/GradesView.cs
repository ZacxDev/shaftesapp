using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ShaftesApp.UI;
using ShaftesApp.Net;
using System.Diagnostics;

namespace ShaftesApp.Views
{
    static class GradesView
    {

        static UITextView Title;
        public static GradeScrollView GradeScroll;
        private static bool _init = false;

        static GradesView()
        {
            if (!_init)
                Initialize();
        }

        public static void Initialize()
        {

            if (_init)
                return;

            _init = true;
            for (int i = 0; i < ViewController.Client.Rooms.Count; i++)
            {
                new GradeListNode(ViewController.Client.Rooms[i], i);
            }

            Title = new UITextView();
            Title.Frame = new CGRect(0, 64, C.X_MAX, 32);
            Title.Text = "Grades";
            Title.BackgroundColor = UIColor.Clear;
            Title.TextAlignment = UITextAlignment.Center;
            Title.Font = Fonts.Settings_Title;
            
            GradeScroll = new GradeScrollView();
            
            
            for (int i = 0; i < GradeListNode.reports.Count; i++)
            {
                GradeListNode.reports[i].AddToView(GradeScroll);
            }
        }

        public static void AddToView()
        {
            Access.vc.View.AddSubview(Title);
            Access.vc.View.AddSubview(GradeScroll);
        }

    }
}