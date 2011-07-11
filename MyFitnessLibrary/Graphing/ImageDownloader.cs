using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoogleChartSharp;
using System.Net;

namespace MyFitnessLibrary.Graphing
{
    class ImageDownloader
    {

        public Image DownloadedImage { get; private set; }

        public ImageDownloader(Uri Path)
        {
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Path);
            request.Timeout = 30000;
            using (WebResponse response = request.GetResponse())
            {
                DownloadedImage = Image.FromStream(response.GetResponseStream());
            }

        }
    }
}
