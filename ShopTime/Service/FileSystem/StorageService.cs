using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;
using Microsoft.Owin.FileSystems;

namespace JasonSoft.ShopTime.Service
{
    public class StorageService : PhysicalFileSystem, IStorageService
    {

        public Task<IResult> SaveFile(string subPath, IFileInfo fileInfo) 
        {
            throw new NotImplementedException();
        } 


        public StorageService(string root) : base(root)
        {

        }
    }
}
