using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CustomActions.Common
{
    public interface IFileSystem
    {
        string GetFilePath(string filename);
        Task<Stream> OpenFileStream(string filename);
    }
}