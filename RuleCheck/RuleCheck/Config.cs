using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static string s_connectionString = "Data Source={0};User Id={1};Password={2}";
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
        public static string s_user_role_privs = "user_role_privs";
        public static string role_admins = "MOSYAGIN_ADMINS";
        public static string role_users = "MOSYAGIN_USERS";
        public static int maxCountRow = 100;

        private static string s_pathDirectorySave;
        private static string s_pathSave;
        private static string s_fileConfig = "user.xml";

        public static string PathDirectorySave
        {
            get
            {
                if (string.IsNullOrEmpty(s_pathDirectorySave))
                {
                    s_pathDirectorySave = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                    , Path.GetFileNameWithoutExtension(Application.ExecutablePath));
                }
                return s_pathDirectorySave;
            }
        }

        public static string PathSave
        {
            get
            {
                if (string.IsNullOrEmpty(s_pathSave))
                {
                    s_pathSave = Path.Combine(PathDirectorySave, s_fileConfig);
                }
                return s_pathSave;
            }
        }

        public static Dictionary<int, string> s_messageException = new Dictionary<int, string>()
        {
            { 1017, "Неверное имя пользователя или пароль" }
        };
    }
}
