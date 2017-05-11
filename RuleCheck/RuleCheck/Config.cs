using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck
{

    public static class Config
    {
        public static string s_connectionString = "Data Source=(DESCRIPTION=" +
        "(ADDRESS = (PROTOCOL=TCP)(HOST=192.168.218.128)(PORT=1521))" +
        "(CONNECT_DATA=" +
        "(SERVER=DEDICATED)" +
        "(SERVICE_NAME=orcl)" +
        ")" +
        ");User Id={0};Password={1}";
        public static string s_rule = "rule";
        public static string s_schemes = "info_schemes";
        public static string s_tables = "info_tables";
        public static string s_objects = "info_objects";
        public static string s_attributes = "info_attributes";
        public static string s_session = "info_session";
        public static string s_cache = "info_cache";
        public static string s_operation = "info_operation";
        public static string s_storage_operation = "operation";
        public static string s_storage_object_type = "object_type";
        public static string s_storage_object = "object";
        public static string s_storage_attribute_type = "attribute_type";
        public static string s_user_procedures = "user_procedures";
        public static string s_user_arguments = "user_arguments";
    }
}
