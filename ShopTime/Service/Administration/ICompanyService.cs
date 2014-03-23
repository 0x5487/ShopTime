using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface ICompanyService
    {
        void CreateCompany(Company company);
        Company GetCompany(int companyId);
        void UpdateCompany(Company company);
    }
}
