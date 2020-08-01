using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class Person_Car
  {
        #region Fields
        private int _PersonID;
        private int _CarID;
        private string _Desc;
        #endregion Fields

        #region Properties
        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
      public string Desc
      {
          get { return _Desc; }
          set { _Desc = value; }
      }
        #endregion Properties
    }
}
