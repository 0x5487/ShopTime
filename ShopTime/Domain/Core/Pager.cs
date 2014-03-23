using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.Components.Castle.Facilities.FactorySupport;

namespace JasonSoft.ShopTime.Domain
{
    public class Pager
    {
        private int? _limit = null;
        private int? _page = null;
        private int _defaultPageSize = 50;

        public int Take { get; set; }

        public int Skip { get; set; }

        private void Convert()
        {
            //take
            if (_limit.HasValue)
            {
                Take = _limit.Value;
            }
            else
            {
                Take = _defaultPageSize;
            }

            //skip
            if (_page.HasValue)
            {
                Skip = _defaultPageSize*_page.Value;
            }
        }

        public Pager(int? limit, int? page)
        {
            this._limit = limit;
            this._page = page;
            Convert();
        }




    }
}
