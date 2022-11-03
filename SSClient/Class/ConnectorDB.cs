using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Class
{
    public static class ConnectorDB
    {
        #region "Fields"
        public static DB MySQLConn = new DB();
        public static ReadWriteFile appConf = new ReadWriteFile();

        public static string[] dataString = new string[4];
        public static string[] identifiedString = { "[MySQL]", "Server=", "Port=", "Uid=", "Pwd=" };
        public static string dbServer, dbPort, dbUid, dbPwd;

        private static string configDir =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ShipStab";
        #endregion

        #region "Constructor"
        #endregion

        #region "Properties"
        #endregion

        #region "Method"
        public static bool LoadConfig()
        {
            bool stat = appConf.LoadConfig(configDir, "db.ini", identifiedString, ref dataString);

            if (stat)
            {
                dbServer = dataString[0];
                dbPort = dataString[1];
                dbUid = dataString[2];
                dbPwd = dataString[3];
            }

            return stat;
        }

        public static bool SaveConfig()
        {
            bool stat = appConf.SaveConfig(configDir, "db.ini", identifiedString, ref dataString);

            if (!stat)
                MessageBox.Show(appConf.ErrorMessage, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return stat;
        }

        public static void SetConfig()
        {
            MySQLConn.DbHost = dbServer;
            MySQLConn.DbPort = dbPort;
            MySQLConn.DbUser = dbUid;
            MySQLConn.DbPassword = dbPwd;
        }

        public static void SetDefault()
        {
            dbServer = "localhost";
            dbPort = "3306";
            dbUid = "root";
            dbPwd = "admin123!";
        }
        #endregion
    }
}
