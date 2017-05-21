using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ShaftesApp.Net
{
    public class Client
    {

        public String Password = "123asdf";
        public String Username = "TestUser";
        public String Bio = "This is a test bio, I enjoy school, sports, and nazi ideals.";
        public String id;
        public int Grade = 10;
        public List<int> RoomIds = new List<int>();
        public UIImage Image;

        public Client()
        {
            DownloadClient();
        }

        private void DownloadClient()
        {
            Image = UIImage.FromBundle("default_avatar");
            // read json, download image
        }

    }
}