using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Extensions.Compression
{
    public class ZipEventArgs : EventArgs
    {
        public ZipResults Result { get; private set; }
        public ZipActions Action { get; private set; }
        public FileInfo Info { get; private set; }

        public ZipEventArgs(string zipPath, ZipResults result, ZipActions action)
        {
            Info = new FileInfo(zipPath) ?? throw new FileNotFoundException($"'{zipPath}' not found.");
            Result = result;
            Action = action;
        }
    }
}
