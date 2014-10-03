using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ar.com.telecom.eva.CoreServices.Data
{
    internal class DbConnectionWrapper : IDisposable
    {
        private readonly DbConnection connection;
        private readonly bool disposeInnerConnection;

        public DbConnectionWrapper(DbConnection connection, bool disposeInnerConnection)
        {
            this.connection = connection;
            this.disposeInnerConnection = disposeInnerConnection;
        }

        /// <summary>
        ///		Gets the actual connection.
        /// </summary>
        public DbConnection Connection
        {
            get { return connection; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (disposeInnerConnection)
                connection.Dispose();
        }

        #endregion
    }
}
