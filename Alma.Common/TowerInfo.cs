using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class TowerInfo
  {
      #region Fields
      private long _TowerInfoID;
        private int _InfoID;
        private string _TowerInfoValue;
        private string _TowerInfoDesc;
        #endregion Fields

        #region Properties
        public string TowerInfoDesc
        {
            get { return _TowerInfoDesc; }
            set { _TowerInfoDesc = value; }
        }

      public string TowerInfoValue
      {
          get { return _TowerInfoValue; }
          set { _TowerInfoValue = value; }
      }

        public int InfoID
        {
            get { return _InfoID; }
            set { _InfoID = value; }
        }

        public long TowerInfoID
        {
            get { return _TowerInfoID; }
            set { _TowerInfoID = value; }
        }
        #endregion Properties
    }
}
