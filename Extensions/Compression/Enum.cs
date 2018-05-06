
namespace Extensions.Compression
{
    public enum ZipResults
    {
        Undefined = -1,
        Error = 0,
        // other custom errors results here
        Success = 50
        // other custom success results here
    }

    public enum ZipActions
    {
        Undefined = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }

    public class ZipResult
    {
        public System.IO.FileInfo ZipInfo { get; private set; }

        public System.DateTime ZipCreation { get { return ZipInfo.CreationTime; } }
        public System.DateTime ZipLastModify { get { return ZipInfo.LastWriteTime; } }
        public string ZipFullName { get { return ZipInfo.FullName; } }
        public string ZipName { get { return ZipInfo.Name; } }
        public string ZipPath { get { return ZipInfo.DirectoryName; } }

        public ZipResult(string zipPath)
        {
            ZipInfo = new System.IO.FileInfo(zipPath) ?? throw new System.IO.FileNotFoundException($"'{zipPath}' not found!");
        }

        public string[] GetContentFilesName()
        {
            return null;
        }

    }
}
