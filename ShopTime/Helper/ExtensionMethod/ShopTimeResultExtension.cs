using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime
{
    public static class ShopTimeResultExtension
    {
        #region Success
        public static IResult Success(this IResult source, Action action)
        {
            if (source != null && source.Error == null)
            {
                action.Invoke();
            }

            return source;
        }

        public static IResult<T> Success<T>(this IResult<T> source, Action<T> action)
        {
            if (source != null && source.Error == null)
            {
                action.Invoke(source.ResultValue);
            }

            return source;
        }

        public static Task<IResult> Success(this Task<IResult> source, Action action)
        {
            if (source != null && source.Result != null && source.Result.Error == null)
            {
                action.Invoke();
            }

            return source;
        }


        public static Task<IResult<T>> Success<T>(this Task<IResult<T>> source, Action<T> action)
        {
            if (source != null && source.Result != null && source.Result.Error == null)
            {
                action.Invoke(source.Result.ResultValue);
            }

            return source;
        }

        #endregion

        #region Error
        public static IResult Error(this IResult source, Action<Error> action)
        {
            if (source != null && source.Error != null)
            {
                action.Invoke(source.Error);
            }

            return source;
        }

        public static Task<IResult> Error(this Task<IResult> source, Action<Error> action)
        {
            if (source != null && source.Result != null && source.Result.Error != null)
            {
                action.Invoke(source.Result.Error);
            }

            
            return source;
        }


        public static IResult<T> Error<T>(this IResult<T> source, Action<Error> action)
        {
            if (source != null && source.Error != null)
            {
                action.Invoke(source.Error);
            }

            return source;
        }

        public static Task<IResult<T>> Error<T>(this Task<IResult<T>> source, Action<Error> action)
        {
            if (source != null && source.Result != null && source.Result.Error != null)
            {
                action.Invoke(source.Result.Error);
            }

            return source;
        }
        #endregion

        #region Complete

        public static Task<IResult> Complete(this Task<IResult> task, Action<Error> action)
        {
            if (task != null && task.Result != null)
            {
                action.Invoke(task.Result.Error);
            }

            return task;
        }


        public static Task<IResult<T>> Complete<T>(this Task<IResult<T>> task, Action<T, Error> action)  
        {
            if (task != null && task.Result != null)
            {
                action.Invoke(task.Result.ResultValue, task.Result.Error);
            }

            return task;
        }

        #endregion
    }
}
