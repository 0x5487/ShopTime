using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class OptionListModel
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public LinkModel Options { get; set; }

    }


    public class ListItemModel
    {
        public int Id { get; set; }

        public int OptionListId { get; set; }

        public int OptionId { get; set; }

        public int IsRequired { get; set; }

        public int Position { get; set; }

        public OptionModel Options { get; set; }

        public OptionValueModel Values { get; set; }


    }
}