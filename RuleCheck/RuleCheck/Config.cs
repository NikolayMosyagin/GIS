using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck
{

    public static class Config
    {
         /*public static string s_connectionString = "Data Source = (DESCRIPTION = " +
         "(ADDRESS = (PROTOCOL = TCP)(HOST = ANDREY-ORA11R2)(PORT = 1521))" +
         "(CONNECT_DATA = " +
         "(SERVER = DEDICATED)" +
         "(SERVICE_NAME = orcl)" +
         ")" +
         ");User Id = {0};Password = {1};";*/
        public static string s_connectionString = "Data Source=ORCL;User Id={0};Password={1}";
        public static string s_attribute_type = "attribute_type";
        public static string s_log = "cache_log";
        public static string s_rule = "rule";
        public static string s_rule_operation = "rule_operation";
        public static string s_schemes = "owner";
        public static string s_tables = "info_tables"; // нету
        public static string s_object = "cache_object";
        public static string s_attributes = "info_attributes"; // нету
        public static string s_session = "cache_session";
        public static string s_attribute = "cache_attribute";
        public static string s_operation = "operation";
        public static string s_object_type = "object_type";
        public static string s_storage_object = ""; // нету
        public static string s_storage_attribute_type = "attribute_type"; // нету
        public static string s_user_procedures = "user_procedures";
        public static string s_user_arguments = "user_arguments";
    }
}
