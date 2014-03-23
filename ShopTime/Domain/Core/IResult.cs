using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public interface IResult
    {
        string Message { get; set; }

        int CodeNumber { get; set; }

        Error Error { get; set; }

    }


    public interface IResult<T> : IResult
    {

        T ResultValue { get; set; }
    }


}
