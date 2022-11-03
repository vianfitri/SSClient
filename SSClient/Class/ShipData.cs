using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSClient.Class
{
    public class ShipData
    {
        #region "Fields"
        string name = string.Empty;
        float loa = 0;
        float lpp = 0;
        float breadth = 0;
        float depth = 0;
        float draft = 0;
        #endregion

        #region "Constructor"
        public ShipData()
        {
        }
        #endregion

        #region "Properties"
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float LOA
        {
            get { return loa; }
            set { loa = value; }
        }

        public float LPP
        {
            get { return lpp; }
            set { lpp = value; }
        }

        public float Breadth
        {
            get { return breadth; }
            set { breadth = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public float Draft
        {
            get { return draft; }
            set { draft = value; }
        }
        #endregion
    }
}
