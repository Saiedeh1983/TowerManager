using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class Unit_Car
  {
      #region Fields
      private int _UnitID;
        private int _CarID;
        private string _Desc;
        #endregion Fields

        #region Properties
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }

        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        #endregion Properties
    }
}
