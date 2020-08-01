using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
    public class UnitInfo
    {
        #region Fields
        private int _UnitInfoID;
        private int _InfoID;
        private string _UnitInfoValue;
        private string _UnitInfoDesc;
        #endregion Fields

        #region Properties
        public int UnitInfoID
        {
            get { return _UnitInfoID; }
            set { _UnitInfoID = value; }
        }
        public int InfoID
        {
            get { return _InfoID; }
            set { _InfoID = value; }
        }
        public string UnitInfoValue
        {
            get { return _UnitInfoValue; }
            set { _UnitInfoValue = value; }
        }
        public string UnitInfoDesc
        {
            get { return _UnitInfoDesc; }
            set { _UnitInfoDesc = value; }
        }
        #endregion Properties
    }
}
