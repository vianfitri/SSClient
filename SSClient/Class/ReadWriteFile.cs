using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSClient.Class
{
    class ReadWriteFile
    {
        #region "Fields"
        private string errMessage;

        #endregion

        #region "Properties"
        public string ErrorMessage 
        {
            get { return errMessage; }
            set { errMessage = value; }
        }
        #endregion

        #region "Constructor"
        #endregion

        #region "Methods"
        public bool LoadConfig(string dirName, string filename, string[] identifierString, ref string[] dataSting)
        {
            StreamReader sr = null;
            
            try
            {
                // Start read file
                string str_buff = string.Empty;

                sr = new StreamReader(dirName + "\\" + filename);
                str_buff = sr.ReadToEnd();

                // Close file
                if (sr != null)
                    sr.Close();

                if(string.IsNullOrEmpty(str_buff))
                {
                    errMessage = "File is empty.";
                    return false;
                }

                // Get configuration
                string[] str_part = str_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < str_part.Length; i++)
                {
                    if(str_part[i].Contains(identifierString[0]))
                    {
                        for(int j=1; j<identifierString.Length; j++)
                        {
                            if(str_part[i+j].Contains(identifierString[i+j]))
                            {
                                dataSting[j - 1] = str_part[i + j].Replace(identifierString[i + j], "").Trim();
                            }
                        }
                        break;
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                errMessage = "Content file is not match / corrupt";
                return false;
            }
            catch(Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }

            return true;
        }

        public bool SaveConfig(string dirName, string filename, string[] identifierString, ref string[] dataString)
        {
            try
            {
                // Check directory
                if (!new DirectoryInfo(dirName).Exists)
                    Directory.CreateDirectory(dirName);

                // Create file
                StreamWriter sw = new StreamWriter(dirName + "\\" + filename);

                sw.WriteLine(identifierString[0]);

                for (int i = 1; i < identifierString.Length; i++)
                    sw.WriteLine(identifierString[i] + dataString[i - 1]);

                sw.Close();
                sw = null;
            }
            catch(Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }

            return true;
        }
        #endregion

    }
}
