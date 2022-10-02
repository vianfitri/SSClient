using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SSClient.Class
{
    public class DB
    {
        #region "Field"
        private MySqlDataAdapter oMySqlAdapter;
        private MySqlConnection oMySqlConn;
        private MySqlCommand oMySqlCmd;
        private MySqlDataReader oMySqlReader;

        private string sHost;
        private string sPort;
        private string sUser;
        private string sPassword;
        private string sConn;

        private string sErrorMessage;

        #endregion

        #region "Properties"

        public string ErrorMessage
        {
            get { return sErrorMessage; }
        }

        public string ConnectionString
        {
            get { return sConn; }
            set { sConn = value; }
        }

        public string DbHost
        {
            get { return sHost; }
            set { sHost = value; }
        }

        public string DbPort
        {
            get { return sPort;  }
            set { sPort = value; }
        }

        public string DbUser
        {
            get { return sUser; }
            set { sUser = value; }
        }

        public string DbPassword
        {
            get { return sPassword; }
            set { sPassword = value; }
        }

        #endregion

        #region "Constructor"

        public DB()
        {
            sHost = "";
            sPort = "";
            sUser = "";
            sPassword = "";
            sConn = "";
            sErrorMessage = "";
        }

        public DB(string Hostname, string Port, string Username, string Password)
        {
            sHost = Hostname;
            sPort = Port;
            sUser = Username;
            sPassword = Password;
            sConn = "";
            sErrorMessage = "";


            if (string.IsNullOrEmpty(sPort.Trim()))
                sPort = "3306";
            sConn = "Server=" + sHost + "; Port=" + sPort + "; Uid=" + sUser + "; Pwd=" + sPassword + ";";
        }
        #endregion

        #region "Functions"

        #region "Data Collections"

        #region "DataSet / DataTable"
        public bool GetTableData(string Query, ref DataSet oDataSet)
        {
            bool stat = true;

            oDataSet.Clear();
            sErrorMessage = "";

            openConnection(true, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlCmd.ExecuteNonQuery();
                oMySqlAdapter.SelectCommand = oMySqlCmd;
                oMySqlAdapter.Fill(oDataSet);

            }
            catch (Exception ex)
            {
                oDataSet = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(true);

            return stat;
        }

        public bool GetTableData(string Query, ref DataTable oDataTable)
        {
            bool stat = true;

            oDataTable.Clear();
            sErrorMessage = "";

            openConnection(true, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlCmd.ExecuteNonQuery();
                oMySqlAdapter.SelectCommand = oMySqlCmd;
                oMySqlAdapter.Fill(oDataTable);

            }
            catch (Exception ex)
            {
                oDataTable = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(true);

            return stat;
        }

        #endregion

        #region "Multiple data in array"

        public bool GetAllDatabases(ref string[] DatabaseNameList)
        {
            return GetColumnData("SHOW DATABASES", 0, ref DatabaseNameList);
        }

        public bool GetAllTables(string DatabaseName, ref string[] TableNameList)
        {
            return GetColumnData("SHOW TABLES FROM " + DatabaseName, 0, ref TableNameList);
        }

        public bool GetColumnData(string Query, int FieldPos, ref double[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetDouble(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();
            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref double[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetDouble(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref int[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetInt32(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();
            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref int[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetInt32(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref object[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetValue(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();
            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref string[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetString(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();
            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref string[] ListColData)
        {
            bool stat = true;
            int idx = 0;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData[idx] = oMySqlReader.GetString(FieldPos);
                        idx++;
                    }
                }

                oMySqlReader.Close();
            }

            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        #endregion

        #region "Multiple data in List"

        public bool GetAllDatabases(ref List<string> DatabaseNameList)
        {
            DatabaseNameList.Clear();

            return GetColumnData("SHOW DATABASES", 0, ref DatabaseNameList);
        }

        public bool GetAllTables(string DatabaseName, ref List<string> TableNameList)
        {
            TableNameList.Clear();

            return GetColumnData("SHOW TABLES FROM " + DatabaseName, 0, ref TableNameList);
        }

        public bool GetColumnData(string Query, int FieldPos, ref List<double> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetDouble(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref List<double> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetDouble(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref List<int> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetInt32(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref List<int> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetInt32(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref List<object> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetValue(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, int FieldPos, ref List<string> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetString(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetColumnData(string Query, string FieldPos, ref List<string> ListColData)
        {
            bool stat = true;

            ListColData.Clear();
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        ListColData.Add(oMySqlReader.GetString(FieldPos));
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                ListColData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        #endregion

        #region "Single data"

        public bool GetData(string Query, int FieldPos, ref double aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetDouble(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = 0;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, string FieldPos, ref double aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetDouble(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = 0;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, int FieldPos, ref int aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetInt32(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = 0;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, string FieldPos, ref int aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetInt32(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = 0;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, int FieldPos, ref object aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetValue(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = null;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, int FieldPos, ref string aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetString(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = "";
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetData(string Query, string FieldPos, ref string aData)
        {
            bool stat = true;

            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    oMySqlReader.Read();
                    aData = oMySqlReader.GetString(FieldPos);
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                aData = "";
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }

        public bool GetTotalRow(string Query, ref int TotalRow)
        {
            bool stat = true;

            TotalRow = 0;
            sErrorMessage = "";

            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlReader = oMySqlCmd.ExecuteReader();

                if (oMySqlReader.HasRows)
                {
                    while (oMySqlReader.Read())
                    {
                        TotalRow += 1;
                    }
                }

                oMySqlReader.Close();

            }
            catch (Exception ex)
            {
                TotalRow = 0;
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);

            return stat;
        }
        #endregion

        #endregion

        #region "General"
        private string SetConnectionString()
        {
            if (string.IsNullOrEmpty(sConn)) return sConn = "Server=" + sHost + "; Port=" + sPort + "; Uid=" + sUser + "; Pwd=" + sPassword + ";";
            else return sConn;
        }

        private void closeConnection(bool useAdapter)
        {
            if (useAdapter)
                oMySqlAdapter.Dispose();

            oMySqlCmd.Dispose();
            oMySqlConn.Close();
        }
        
        private void openConnection(bool useAdapter, string Query)
        {
            SetConnectionString();

            if (useAdapter)
                oMySqlAdapter = new MySqlDataAdapter();

            oMySqlConn = new MySqlConnection(sConn);
            oMySqlCmd = new MySqlCommand(Query, oMySqlConn);
        }

        public bool GetDBStatus()
        {
            bool stat = true;

            SetConnectionString();
            sErrorMessage = string.Empty;
            oMySqlConn = new MySqlConnection(sConn);

            try { 
                oMySqlConn.Open(); 
            }
            catch(Exception ex)
            {
                sErrorMessage = ex.Message;
                stat = false;
            }

            oMySqlConn.Close();
            oMySqlConn.Dispose();
            return stat;
        }

        public bool SetCommand(string Query)
        {
            bool stat = true;

            sErrorMessage = "";
            openConnection(false, Query);

            try
            {
                oMySqlConn.Open();
                oMySqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sErrorMessage = ex.Message;
                stat = false;
            }

            closeConnection(false);
            return stat;
        }

        #endregion

        #region "IUD"
        public bool InsertData(string dbName, string tblName, string[] fieldName, string[] dataField) 
        {
            string field_name = string.Empty, insert_data = string.Empty;

            for (int i = 0; i < fieldName.Length - 1; i++)
                field_name = field_name + fieldName[i] + ",";

            for (int i = 0; i < dataField.Length - 1; i++)
                insert_data = insert_data + dataField[i] + ",";

            field_name = field_name + fieldName[fieldName.Length - 1];
            insert_data = insert_data + dataField[dataField.Length - 1];

            string sq = "INSERT INTO " + dbName + "." + tblName + " (" + field_name + ") VALUES(" + insert_data + ")";

            return SetCommand(sq);  
        }

        public bool UpdateData(string dbName, string tblName, string[] fieldName, string[] dataField, string[] clauseField) 
        {
            string clause_data = string.Empty, update_data = string.Empty;

            for (int i = 0; i < dataField.Length - 1; i++)
                update_data = update_data + "a." + fieldName[i] + "=" + dataField[i] + ",";

            for (int i = 0; i < clauseField.Length - 1; i++)
                clause_data = clause_data + "a." + clauseField[i] + ",";

            update_data = update_data + "a." + fieldName[fieldName.Length - 1] + "=" + dataField[dataField.Length - 1];
            clause_data = clause_data + "a." + clauseField[clauseField.Length - 1];

            string sq = "UPDATE " + dbName + "." + tblName + " a SET " + update_data + " WHERE " + clause_data;
            return SetCommand(sq); 
        }

        public bool DeleteData(string dbName, string tblName, string[] clauseField) 
        {
            string clause_data = string.Empty;

            for (int i = 0; i < clauseField.Length - 1; i++)
                clause_data = clause_data + dbName + "." + tblName + "." + clauseField[i] + ", ";

            clause_data = clause_data + dbName + "." + tblName + "." + clauseField[clauseField.Length - 1];
            string sq = "DELETE FROM " + dbName + "." + tblName + " WHERE " + clause_data;
            return SetCommand(sq); 
        }

        #endregion

        #endregion
    }




}
