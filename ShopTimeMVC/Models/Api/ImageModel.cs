using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int Position { get; set; }

        public string FileName { get; set; }

        public string Attachment { get; set; }

        public LinkModel CustomFields { get; set; }

        public AuditInfo AuditInfo { get; set; }
    }
}