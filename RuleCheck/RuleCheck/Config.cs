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
        ");User Id=mosyagin;Password=31051994";
        public static string s_schemes = "info_schemes";
        public static string s_tables = "info_tables";
        public static string s_objects = "info_objects";
        public static string s_tableColumns = "info_table_columns";
        public static string s_session = "info_session";
        public static string s_cache = "info_cache";
        public static string s_storage_object_type = "object_type";
    }
}
