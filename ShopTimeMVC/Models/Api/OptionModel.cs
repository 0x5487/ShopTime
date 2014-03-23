using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class OptionModel
    {
        public int Id { get; set; }

        public int OptionListId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public DisplayType DisplayType { get; set; }

        public LinkModel Values { get; set; }
    }

    public enum DisplayType
    {
        DropDownList = 1,
        Radio = 2,


    }

    public class OptionValueModel
    {
        public int Id { get; set; }

        public int OptionId { get; set; }

        public int Position { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }        

    }
}