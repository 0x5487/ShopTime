using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ShopTimeResult : IResult
    {
        public string Message { get; set; }
        public int CodeNumber { get; set; }

        public Error Error { get; set; }

    }


    public class ShopTimeResult<T> : IResult<T>
    {
        public string Message { get; set; }
        public int CodeNumber { get; set; }

        public Error Error { get; set; }
        public T ResultValue { get; set; }

        public ShopTimeResult()
        {

        }

        public ShopTimeResult(T resultValue)
        {
            this.ResultValue = resultValue;
        }


    }

    public enum ResultStatus
    {
        Success,
        PartialSuccess,
        Failure
    }
}
