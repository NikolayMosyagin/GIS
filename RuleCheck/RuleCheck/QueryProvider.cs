using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace RuleCheck
{
    public static class QueryProvider
    {
        public static OracleConnection s_connection
        {
            get
            {
                OpenConnection();
                return _s_connection;
            }
        }

        public static string s_cns;
        private static OracleConnection _s_connection;
        public static int s_ErrorNumber = 0;

        public static void CloseConnection()
        {
            if (_s_connection != null)
            {
                _s_connection.Dispose();
                _s_connection.Close();
            }
        }

        public static void OpenConnection()
        {
            if (_s_connection == null || _s_connection.State == System.Data.ConnectionState.Closed
                || _s_connection.State == System.Data.ConnectionState.Broken)
            {
                _s_connection = new OracleConnection(s_cns);
                try
                {
                    _s_connection.Open();
                    s_ErrorNumber = -1;
                }
                catch (OracleException e)
                {
                    s_ErrorNumber = e.Number;
                }

            }
        }

        public static DataTable Execute(string commandText, OracleParameter[] parameters, System.Data.CommandType type = System.Data.CommandType.Text)
        {
            var result = new DataTable();
            using (var command = new OracleCommand(commandText, s_connection))
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; ++i)
                    {
                        command.Parameters.Add(parameters[i]);
                    }
                }
                command.CommandType = type;
                using (var reader = command.ExecuteReader())
                {
                    for (int i = 0; i < command.Parameters.Count; ++i)
                    {
                        if (command.Parameters[i].Direction == System.Data.ParameterDirection.Output ||
                            command.Parameters[i].Direction == System.Data.ParameterDirection.ReturnValue)
                        {
                            result.parametersOut.Add(command.Parameters[i].Value);
                        }
                    }
                    while (reader.Read())
                    {
                        object[] rows = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; ++i)
                        {
                            if (i >= result.columnName.Count)
                            {
                                result.columnName.Add(reader.GetName(i));
                            }
                            rows[i] = reader.GetValue(i);
                        }
                        result.values.Add(rows);
                    }
                    reader.Close();
                }
            }
            return result;
        }
    }


    public class DataTable
    {
        public List<object[]> values;
        public List<string> columnName;
        public List<object> parametersOut;
        public DataTable()
        {
            values = new List<object[]>();
            columnName = new List<string>();
            parametersOut = new List<object>();
        }
    }
}
