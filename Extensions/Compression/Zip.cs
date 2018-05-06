using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Compression
{
    public class Zip : IDisposable
    {

        #region EXCEPTION
        private Exception exception;
        /// <summary>
        /// The Exception occured
        /// </summary>
        public Exception GetException { get { return exception; } }
        #endregion

        #region PUBLIC METHODS
        #region from strings
        public async Task<ZipResult> CreateFromStringAsync(string content, string zipfilename, string contentfilename, string outputpath = null)
        {
            exception = null;
            
            try
            {
                if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
                    throw new ArgumentException("Text cannot be null or empty", nameof(content));

                if (string.IsNullOrEmpty(zipfilename) || string.IsNullOrWhiteSpace(zipfilename))
                    zipfilename = $"{DateTime.Now.ToString("yyyyMMdd_hhmmssffff")}.zip";
                zipfilename = _CheckExtension(zipfilename);

                if (string.IsNullOrEmpty(contentfilename) || string.IsNullOrWhiteSpace(contentfilename))
                    zipfilename = $"{DateTime.Now.ToString("yyyyMMdd_hhmmssffff")}_content.txt";

                if (string.IsNullOrEmpty(outputpath) || string.IsNullOrWhiteSpace(outputpath))
                    outputpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (!Directory.Exists(outputpath))
                    Directory.CreateDirectory(outputpath);

                using (var stream = File.Create(Path.Combine(outputpath, zipfilename)))
                using (var archive = new ZipArchive(stream, ZipArchiveMode.Update))
                {
                    var entry = archive.CreateEntry(contentfilename);
                    using (var sr = new StreamWriter(entry.Open()))
                        await sr.WriteAsync(content);
                }
                return new ZipResult(Path.Combine(outputpath, zipfilename));
            }
            catch (ArgumentException e)
            {
                exception = new Exception(e.Message, e);
                return null;
            }
            catch (Exception e)
            {
                exception = e;
                return null;
            }
        }

        public async Task<List<ZipResult>> CreateFromStringsAsync(IEnumerable<string> contents, string zipfilename, IEnumerable<string> contentfilesname = null, string outputpath = null)
        {
            exception = null;

            try
            {
                var resCollection = new List<ZipResult>();

                foreach (var content in contents)
                {
                    if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
                        continue;
                }

                return null;
            }
            catch (ArgumentException e)
            {
                exception = new Exception(e.Message, e);
                return null;
            }
            catch (Exception e)
            {
                exception = e;
                return null;
            }
        }
        #endregion

        #region from file
        public async Task<ZipResult> CreateFromFileAsync(string filepath, string zipfilename = null, string outputpath = null)
        {
            exception = null;

            try
            {
                if (string.IsNullOrEmpty(filepath) || string.IsNullOrWhiteSpace(filepath))
                    throw new ArgumentException("Text cannot be null or empty", nameof(filepath));
                else if (!File.Exists(filepath))
                    throw new FileNotFoundException($"'{filepath}' not found!.");

                if (string.IsNullOrWhiteSpace(zipfilename))
                    zipfilename = $"{Path.GetFileNameWithoutExtension(filepath)}.zip";
                zipfilename = _CheckExtension(zipfilename);

                if (string.IsNullOrWhiteSpace(outputpath))
                    outputpath = Path.GetDirectoryName(filepath);

                using (var stream = File.Create(Path.Combine(outputpath, zipfilename)))
                using (var archive = new ZipArchive(stream, ZipArchiveMode.Update))
                {
                    var entry = archive.CreateEntry(filepath);
                    using (var sw = new StreamWriter(entry.Open()))
                        await sw.WriteAsync(File.ReadAllText(filepath));
                }

                return new ZipResult(Path.Combine(outputpath, zipfilename));
            }
            catch (ArgumentException e)
            {
                exception = new Exception(e.Message, e);
                return null;
            }
            catch (FileNotFoundException e)
            {
                exception = new Exception(e.Message, e);
                return null;
            }
            catch (Exception e)
            {
                exception = e;
                return null;
            }
        }
        #endregion
        #endregion



        #region EVENTS
        public delegate void CompressionCompleteHandler(object sender, ZipEventArgs args);
        public event CompressionCompleteHandler CompressionComplete;
        protected virtual void OnCompressionComplete(ZipEventArgs args)
        {
            CompressionComplete?.Invoke(this, args);
        }
        #endregion


        #region PRIVATE METHODS
        string _CheckExtension(string filename)
        {
            if (Path.GetExtension(filename).ToLower() == ".zip")
                return filename;
            else
                return $"{filename}.zip";
        }
        #endregion

        #region IDisposable Interface Implementation
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) handle.Dispose();
            disposed = true;
        }

        #endregion
    }
}
