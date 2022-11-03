using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSClient.Class
{
    public static class Utility
    {
        #region "Fields"
        #endregion

        #region "Constructor"
        #endregion

        #region "Properties"
        #endregion

        #region "Method"
        public static string GenerateUC()
        {
            Random rnd = new Random();
            string tmstr = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString();
            string tm5last = tmstr.Substring(tmstr.Length - 5, 5);
            return rnd.Next(100, 999).ToString() + "-" + tm5last + "-" + rnd.Next(10, 99).ToString();
        }
        #endregion
    }
}
