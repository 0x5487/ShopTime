using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.FileSystems;

namespace JasonSoft.ShopTime.Domain
{
    public class VirutalFile: IFileInfo
    {
        private DateTime _lastModified;
        private Stream _stream;
        private string _physicalPath, _name;

        public long Length 
        {
            get
            {
                return _stream.Length;
            }
        }

        public string PhysicalPath 
        {
            get
            {
                return _physicalPath;
            }
        }

        public string Name 
        {
            get
            {
                return _name;
                
            }
        }

        public DateTime LastModified 
        {
            get
            {
                return _lastModified;
            }
        }

        public bool IsDirectory 
        {
            get
            {
                return false;
            }
        }



        public Stream CreateReadStream()
        {
            return _stream;
        }

        public VirutalFile(string name, string base64String)
        {
            _name = name;

            // Convert Base64 String to byte[]
            byte[] bytes = Convert.FromBase64String(base64String);
            _stream = new MemoryStream(bytes);

            _lastModified = DateTime.UtcNow;
        }

        public VirutalFile(FileInfo fileInfo)
        {

        }
    }
}
