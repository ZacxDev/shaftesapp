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
            Access.vc.changeView(AppState.TUTOR);
        }

        [Export("ForumFunc")]
        void ForumFunc()
        {
            Access.vc.changeView(AppState.FORUMS);
        }

        [Export("GradesFunc")]
        void GradesFunc()
        {
            Access.vc.changeView(AppState.GRADES);
        }

        [Export("ProfileFunc")]
        void ProfileFunc()
        {
            Access.vc.changeView(AppState.PROFILE);
        }

        [Export("ProfileRoomsFunc")]
        void ProfileRoomsFunc()
        {
            ProfileView.ShowRooms(false);
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
            ProfileView.ShowRooms(true);
        }

        [Export("ShowRoom")]
        void ShowRoom()
        {
            Debug.WriteLine("ffffffmatey");
        }

        [Export("DeadFunc")]
        void DeadFunc()
        {
        }
    }
}
