using BusinessAdvanceManagement.Core.Helpers.Connection;
using BusinessAdvanceManagement.Core.Result;
using BusinessAdvanceManagement.Core.Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Core.Helpers.CRUDHelper
{
    public class CRUDHelper
    {
        private readonly ConnectionHelper _connectionHelper;

        public CRUDHelper(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public GeneralReturnType<T> ExecuteNonQuery<T>(string query, object parameters, T data)
        {
            GeneralReturnType<T> result = new GeneralReturnType<T>();

            try
            {
                using (var connection = _connectionHelper.CreateConnection())
                {
                    var affectedRows = connection.Execute(query, parameters);

                    if (affectedRows > 0)
                    {
                        result.Datas = data;
                        result.Message = MagicStrings.addSuccess;
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.Datas = default(T);
                        result.Message = MagicStrings.addFailure;
                        result.StatusCode = 400;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Datas = default(T);
                result.Message = MagicStrings.addFailure + ex.Message;
                result.StatusCode = 400;
            }

            return result;
        }

        public GeneralReturnType<IEnumerable<T>> ExecuteQuery<T>(string query, object parameters)
        {
            GeneralReturnType<IEnumerable<T>> result = new GeneralReturnType<IEnumerable<T>>();

            try
            {
                using (var connection = _connectionHelper.CreateConnection())
                {
                    var data = connection.Query<T>(query, parameters);

                    if (data != null && data.Any())
                    {
                        result.Datas = data;
                        result.Message = MagicStrings.dataSuccess;
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.Datas = null;
                        result.Message = MagicStrings.dataFailure;
                        result.StatusCode = 404;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Datas = null;
                result.Message = MagicStrings.dataFailure + ex.Message;
                result.StatusCode = 500;
            }

            return result;
        }

        public GeneralReturnType<T> ExecuteStoreProcedure<T>(string procedureName, object parameters, T data)
        {
            GeneralReturnType<T> result = new GeneralReturnType<T>();
            try
            {
                using (var connection = _connectionHelper.CreateConnection())
                {
                    var affectedRows = connection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    if (affectedRows > 0)
                    {
                        result.Datas = data;
                        result.Message = MagicStrings.addSuccess;
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.Datas = default(T);
                        result.Message = MagicStrings.addFailure;
                        result.StatusCode = 400;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Datas = default(T);
                result.Message = MagicStrings.addFailure + ex.Message;
                result.StatusCode = 400;
            }

            return result;
        }
    }
}
