using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;
using Microsoft.Owin.FileSystems;


namespace JasonSoft.ShopTime.Service
{
    public interface IStorageService: IFileSystem
    {
        Task<IResult> SaveFile(string subPath, IFileInfo fileInfo);
    }
}
