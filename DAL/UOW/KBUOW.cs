using DAL.Base;
using System;
using KnolwdgeBase.Infrastructure;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace DAL.UOW
{
    public class KBUOW<TContext>: IUnitOfWork 
        where TContext : IContext, new()
    {        
        private readonly IContext _context;

        public KBUOW()
        {
            _context = new TContext();
        }

        public KBUOW(IContext context)
        {
            _context = context;
        }
        public int Save()
        {
            int result = -1;

            try
            {
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Level.Exception, "KBUOW", ex.ToString());
                //HandleException(ex);
            }
            return result;
        }

        public IContext Context
        {
            get { return (TContext)_context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private void HandleException(Exception ex)
        {
            //if (ex is SqlException)
            //{
            //    //SqlException sqlEx = (SqlException)ex;
            //    //if (sqlEx.Number == 515)  //Cannot insert the value NULL
            //    //    throw new AppException(AppException.DAL_MANDATORYFIELDMISSING,
            //    //        Resources.MandatoryField,
            //    //        AppException.SeverityType.Info,
            //    //        ex);
            //    //else if (sqlEx.Number == -2)   // Timeout expired.
            //    //    throw new AppException(AppException.DAL_SERVERTIMEOUT,
            //    //        Resources.DBTimeout,
            //    //        AppException.SeverityType.Info,
            //    //        ex);
            //    //else if (sqlEx.Number == 1205)   // Transaction was deadlocked
            //    //    throw new AppException(AppException.DAL_DEADLOCK,
            //    //        Resources.DBDeadlock,
            //    //        AppException.SeverityType.Info,
            //    //        ex);
            //    //else if (sqlEx.Number == 547 && (sqlEx.Message.ToUpper().IndexOf("FK_MATERIALLOG_TO_MATERIAL") > -1)) // conflicted with COLUMN REFERENCE constraint
            //    //    throw new AppException(AppException.DAL_RECORDUSED,
            //    //        Resources.MaterialUsedInMaterialLog,
            //    //        AppException.SeverityType.Info,
            //    //        ex);
            //    //else if (sqlEx.Number == 547 && (sqlEx.Message.ToUpper().IndexOf("FK_MATERIALINGROUP_TO_MATERIAL") > -1)) // conflicted with COLUMN REFERENCE constraint
            //    //    throw new AppException(AppException.DAL_RECORDUSED,
            //    //        Resources.MaterialUsedInMaterialInGroup,
            //    //        AppException.SeverityType.Info,
            //    //        ex);
            //    else
            //    {
            //        bool rethrow = ExceptionPolicy.HandleException(ex, "DAL Policy");
            //        if (rethrow)
            //            throw ex;
            //    }
            //}
            
            bool rethrow = ExceptionPolicy.HandleException(ex, "DAL Policy");
            if (rethrow)
                throw ex;
            
        }
    }    
}
