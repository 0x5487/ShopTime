using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Helper
{
    public class UrlToTags
    {
        private string _resourceId;

        public bool IsValid { get; private set; }

        public string ResourceId { get; set; }

        public IList<string> Tags { get; private set; }

        public UrlToTags(string resourceId)
        {
            Tags = new List<string>();
            _resourceId = resourceId;
            Start();
        }



        private void Start()
        {
            var newResourceId = _resourceId.Trim().ToLower();
            
            var pos = newResourceId.IndexOf(" ");
            if (pos > 0)
            {
                IsValid = false;
                return;
            }

            var list = newResourceId.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
           
            foreach (var s in list)
            {
                Tags.Add(s.Replace("\\", "").Replace("//", ""));
            }

            ResourceId = Tags[0];
            Tags.RemoveAt(0);

            IsValid = true;
        }
    }
}
