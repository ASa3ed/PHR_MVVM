using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Models
{
    public class UploadFile
    {
        public UploadFile(string name, string filepath, StreamContent content)
        {
            Name = name;
            FilePath = filepath;
            Content = content;
        }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public StreamContent Content { get; set; }

    }
}
