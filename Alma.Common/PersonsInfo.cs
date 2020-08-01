using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common

{
    public class PersonsInfo
    {
        #region Fields
        private long _PersonInfoID;
        private long _PersonID;
        private long _DetailInfoID;
        private string _PersonInfoValue;
        private string _PersonInfoDesc;
        #endregion Fields

        #region Properties

        public long PersonInfoID
        {
            get { return _PersonInfoID; }
            set { _PersonInfoID = value; }
        }

        public long PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        public string PersonInfoDesc
        {
            get { return _PersonInfoDesc; }
            set { _PersonInfoDesc = value; }
        }

        public string PersonInfoValue
        {
            get { return _PersonInfoValue; }
            set { _PersonInfoValue = value; }
        }

        public long DetailInfoID
        {
            get { return _DetailInfoID; }
            set { _DetailInfoID = value; }
        }



        public long ID1
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        public long InfoID1
        {
            get { return _PersonInfoID; }
            set { _PersonInfoID = value; }
        }
        #endregion Properties
    }
}
