using System;
using Mono;
using ObjCRuntime;
using Foundation;
using ShaftesApp.Views;
using System.Diagnostics;

namespace ShaftesApp
{
    public class ButtonHandler
        : NSObject
    {
        //sidebar visable?
        public static bool BARS_OPEN;

        public ButtonHandler()
        {
        }

        [Export("BarsFunc")]
        void BarsFunc()
        {
            if (BARS_OPEN)
            {
                BARS_OPEN = false;
                C.MOX = 0;
            }
            else
            {
                BARS_OPEN = true;
                C.MOX = C.X_BAR_INSET;
            }

            Access.vc.changeView(Access.vc.state);
        }

        [Export("AnnounceFunc")]
        void AnnounceFunc()
        {
            Access.vc.changeView(AppState.ANNOUNCEMENTS);
        }

        [Export("TutorFunc")]
        void TutorFunc()
        {
            Console.WriteLine("change state to tutor");
        }

        [Export("ForumFunc")]
        void ForumFunc()
        {
            Console.WriteLine("change state to forum");
        }

        [Export("GradesFunc")]
        void GradesFunc()
        {
            Console.WriteLine("change state to grdsea");
        }

        [Export("ProfileFunc")]
        void ProfileFunc()
        {
            Access.vc.changeView(AppState.PROFILE);
        }

        [Export("ProfileRoomsFunc")]
        void ProfileRoomsFunc()
        {
            ProfileView.ShowRooms();
        }

        [Export("SettingsFunc")]
        void SettingsFunc()
        {
            Loader.ShowSettings();
        }

        [Export("RoomsBackToProfile")]
        void RoomsBackToProfile()
        {
            ProfileView.DismissRooms();
        }

        [Export("RoomBackToProfileRoomList")]
        void RoomBackToProfileRoomList()
        {
            ProfileView.ShowRooms();
        }

        [Export("ShowRoom")]
        void ShowRoom()
        {
            Debug.WriteLine("ffffffmatey");
        }
    }
}
