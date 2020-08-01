using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class BaseInfo
    {
        private int _BaseInfoID;
        private string _BaseInfoTitle;
        private string _BaseInfoDesc;

        public string BaseInfoDesc
        {
            get { return _BaseInfoDesc; }
            set { _BaseInfoDesc = value; }
        }

        public string BaseInfoTitle
        {
            get { return _BaseInfoTitle; }
            set { _BaseInfoTitle = value; }
        }

        public int BaseInfoID
        {
            get { return _BaseInfoID; }
            set { _BaseInfoID = value; }
        }
    }
}
