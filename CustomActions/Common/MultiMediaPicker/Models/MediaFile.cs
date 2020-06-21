using System;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace CustomActions.Common.MultiMediaPicker.Helpers
{
    public enum MediaFileType
    {
        Image,
        Video
    }

    public class MediaFile
    {
        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public MediaFileType Type { get; set; }

        public byte[] ImagesBytes { get; set; }

        public ImageSource imageSource { get; set; }
        public string FileName
        {
            get
            {
                var array = Path.Split('/');
                return array[array.Length - 1];
            }
        }

        public Stream GetStream()
        {
            
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(Path);
            //  byte[] byteArray = Encoding.ASCII.GetBytes(Path);
            Stream stream = new MemoryStream(imageBytes);
            return stream;

        }

        public Stream GetStreamPath(string path)
        {

            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(path);
            //  byte[] byteArray = Encoding.ASCII.GetBytes(Path);
            Stream stream = new MemoryStream(imageBytes);
            return stream;

        }





    }
}
