﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.Common
{
    public class DapperConnection
    {
        public static string? connectionString;
        public static bool isDevlopment;
        public readonly object Employees;

        public static bool ValidateConnection()
        {
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    dbConnection.Open();
                    dbConnection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //ErrorLogger.Error("Error Into query=>ValidateConnection \r\n", ex.ToString(), "", "", "", true);
                Console.WriteLine("Error connecting to MySQL: " + ex.Message);
                return false;
            }
        }

        public static void ErrorLogEntry(string ErrorDetails, string ControllerName, string ActionName, string DBOrWebsite, string UserDetails)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("ErrorDetails", ErrorDetails);
            dictionary.Add("ControllerName", ControllerName);
            dictionary.Add("ActionName", ActionName);
            dictionary.Add("DBOrWebsite", DBOrWebsite);
            dictionary.Add("UserDetails", UserDetails);

            ExecuteWithoutResultStatic("InsertErrorMaster", CommandType.StoredProcedure, dictionary);
        }
        public async Task<IEnumerable<T>> GetAsyncListResult<T>(string query, CommandType commandType, Dictionary<string, object> dictionary, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {
                            dbConnection.Open();

                            IEnumerable<T> entities = await dbConnection.QueryAsync<T>(query, new DynamicParameters(dictionary), dbTransaction, 0, commandType);

                            dbConnection.Close();

                            return entities;
                        }
                    }
                    else
                    {
                        dbConnection.Open();

                        IEnumerable<T> entities = await dbConnection.QueryAsync<T>(query, new DynamicParameters(dictionary), null, 0, commandType);

                        dbConnection.Close();

                        return entities;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into query=>" + query + " \r\n CommandType=" + commandType.ToString(), ex.ToString(), "", "", "", true);
                return null;
            }
        }
        public async Task<IEnumerable<T>> GetAsyncListResult<T>(string query, CommandType commandType, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {

                            dbConnection.Open();


                            IEnumerable<T> entities = await dbConnection.QueryAsync<T>(query, null, dbTransaction, 0, commandType);

                            dbConnection.Close();

                            return entities;
                        }
                    }
                    else
                    {

                        dbConnection.Open();

                        IEnumerable<T> entities = await dbConnection.QueryAsync<T>(query, null, null, 0, commandType);

                        dbConnection.Close();

                        return entities;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into query=>" + query + " \r\n CommandType=" + commandType.ToString(), ex.ToString(), "", "", "", true);
                return null;
            }
        }

        public IEnumerable<T> GetListResult<T>(string query, CommandType commandType, Dictionary<string, object> dictionary, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {
                            dbConnection.Open();

                            IEnumerable<T> entities = dbConnection.Query<T>(query, new DynamicParameters(dictionary), dbTransaction, true, 0, commandType);

                            dbConnection.Close();

                            return entities;
                        }
                    }
                    else
                    {
                        dbConnection.Open();

                        IEnumerable<T> entities = dbConnection.Query<T>(query, new DynamicParameters(dictionary), null, true, 0, commandType);

                        dbConnection.Close();

                        return entities;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into query=>" + query + " \r\n CommandType=" + commandType.ToString(), ex.ToString(), "", "", "", true);
                return null;
            }
        }

        public IEnumerable<T> GetListResult<T>(string query, CommandType commandType, IDbTransaction dbTransaction = null)
        {
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {

                            dbConnection.Open();

                            IEnumerable<T> entities = dbConnection.Query<T>(query, null, null, true, 0, commandType);

                            dbConnection.Close();

                            return entities;
                        }
                    }
                    else
                    {

                        dbConnection.Open();

                        IEnumerable<T> entities = dbConnection.Query<T>(query, null, null, true, 0, commandType);

                        dbConnection.Close();

                        return entities;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into query=>" + query + " \r\n CommandType=" + commandType.ToString(), ex.ToString(), "", "", "", true);
                return null;
            }
        }

        public static bool ExecuteWithoutResultStatic(string storeProcedurename, CommandType commandType, Dictionary<string, object> dictionary)
        {
            bool result = true;
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    dbConnection.Open();
                    dbConnection.Execute(storeProcedurename, dictionary, null, 0, commandType);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into " + storeProcedurename, ex.ToString(), "", "", "", true);
                return false;
            }
            return result;
        }

        public bool ExecuteWithoutResult(string storeProcedurename, CommandType commandType, Dictionary<string, object> dictionary, IDbTransaction dbTransaction = null)
        {
            bool result = true;
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {
                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {
                            dbConnection.Open();
                            dbConnection.Execute(storeProcedurename, dictionary, null, 0, commandType);
                            dbConnection.Close();
                        }
                    }
                    else
                    {
                        dbConnection.Open();
                        dbConnection.Execute(storeProcedurename, dictionary, null, 0, commandType);
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into " + storeProcedurename, ex.ToString(), "", "", "", true);
                return false;
            }
            return result;
        }

        public bool ExecuteWithoutResult(string storeProcedurename, CommandType commandType, IDbTransaction dbTransaction = null)
        {
            bool result = true;
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {

                    if (dbTransaction != null)
                    {
                        using (dbTransaction)
                        {
                            dbConnection.Open();
                            dbConnection.Execute(storeProcedurename, null, null, 0, commandType);
                            dbConnection.Close();
                        }
                    }
                    else
                    {
                        dbConnection.Open();
                        dbConnection.Execute(storeProcedurename, null, null, 0, commandType);
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Error("Error Into " + storeProcedurename, ex.ToString(), "", "", "", true);
                return false;
            }
            return result;
        }


        public DataTable GetDataTable(string query, CommandType commandType, out string strError, Dictionary<string, object> dictionary = null)
        {
            var ds = new DataTable();
            strError = "";
            try
            {
                using (IDbConnection dbConnection = new MySqlConnection(connectionString))
                {

                    using (var reader = dbConnection.ExecuteReader(query))
                    {
                        // get DataSet from result
                        ds.Load(reader);

                        return ds;

                    }

                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
                ErrorLogger.Error("Error Into query=>" + query + " \r\n CommandType=" + commandType.ToString(), ex.ToString(), "", "", "", true);
                return null;
            }
        }

        public Task<T> GetAsyncResult<T>(string v, CommandType storedProcedure, Dictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }

        public object GetListResult<T>(string v, CommandType storedProcedure, object value)
        {
            throw new NotImplementedException();
        }
    }
}
