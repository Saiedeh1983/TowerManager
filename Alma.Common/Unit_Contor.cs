using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Unit_Contor
   {
       #region Fields
       private int _UnitID;
        private int _ContorID;
        private string _Desc;
       #endregion Fields

        #region Properties
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int ContorID
        {
            get { return _ContorID; }
            set { _ContorID = value; }
        }

        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        #endregion Properties
    }
}
