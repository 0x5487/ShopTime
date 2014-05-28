using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : class
    {
        private ShopTimeDbContext _context;
        private IDbSet<T> _entities;


        public EfRepository(ShopTimeDbContext context)
        {
            this._context = context;
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }


        public async Task<IResult>  InsertAsync(T entity)
        {
            IResult result = null;

            if (entity == null)
            {
                result = new ShopTimeResult() {Error = new Error() {CodeNumber = 500, Message = "entity can't be null or empty."}};
            }

            try
            {
                Entities.Add(entity);
                await _context.SaveChangesAsync();
                result = new ShopTimeResult();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage) + Environment.NewLine;


                result = new ShopTimeResult() {Error = new Error() {CodeNumber = 500, Message = msg}};
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                if (ex.InnerException != null)
                {
                    msg = ex.InnerException.Message;
                }

                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = msg } };
            }

            return result;
        }

        public async Task<IResult> UpdateAsync(T entity)
        {
            IResult result = null;

            if (entity == null)
            {
                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = "entity can't be null or empty." } };
            }

            try
            {
                this._context.SaveChanges();
                result = new ShopTimeResult();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage) + Environment.NewLine;


                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = msg } };
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = ex.Message } };
            }

            return result;
        }

        public async Task<IResult> UpdateAsync(IList<T> entities)
        {
            IResult result = null;

            if (entities.IsNullOrEmpty())
            {
                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = "entities can't be null or empty." } };
            }

            try
            {
                this._context.SaveChanges();
                result = new ShopTimeResult();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage) + Environment.NewLine;


                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = msg } };
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = ex.Message } };
            }

            return result;
        }

        public async Task<IResult> DeleteAsync(T entity)
        {
            //IResult result = null;

            //if (entity == null)
            //{
            //    result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = "entity can't be null or empty." } };
            //}


            //try
            //{
            //    this.Entities.Remove(entity);
            //    this._context.SaveChanges();
            //    result = new ShopTimeResult();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    var msg = string.Empty;

            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            msg +=
            //                string.Format("Property: {0} Error: {1}", validationError.PropertyName,
            //                    validationError.ErrorMessage) + Environment.NewLine;


            //    result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = msg } };
            //}
            //catch (Exception ex)
            //{
            //    result = new ShopTimeResult() { Error = new Error() { CodeNumber = 500, Message = ex.Message } };
            //}

            //return result;

            throw new NotImplementedException();
        }

        public  IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        protected IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
