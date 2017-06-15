using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ShaftesApp.Net
{
    public enum ClientType
    { STUDENT, TUTOR, TEACHER, ADMIN }

    public class Client
    {

        public String Password = "123asdf";
        public String Username;
        public String Bio;
        public int ID;
        public int Grade = 10;
        public List<Room> Rooms = new List<Room>();
        public UIImage Image;

        public ClientType Type;
        public bool CanWork;

        public Client()
        {
            DownloadClient();
        }

        private void DownloadClient()
        {
            Image = UIImage.FromBundle("cheese_avatar");

            for (int i = 0; i < 9; i++)
            {
                Rooms.Add(new Room($"Classroom{i}"));
            }

            Username = GetUsername();
            Bio = GetBio();
            ID = GetID();
            Type = GetClientType();
            CanWork = GetCanWork();

            // read json, download image
        }

        private ClientType GetClientType()
        {
            return ClientType.ADMIN;
        }

        private bool GetCanWork()
        {
            return true;
        }

        private String GetUsername()
        {
            return "Cheesus Christ";
        }

        private String GetBio()
        {
            return "I bless thee with a selection of savoury cheese.";
        }

        private int GetID()
        {
            return 0;
        }

        public void JoinRoom(Room room)
        {
            Rooms.Add(room);
        }

    }
}