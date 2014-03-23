using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class CustomFieldModel
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public AuditInfo AuditInfo { get; set; }
    }
}