using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Independent
    {
        #region Fields

        private int _ID;
        private string _Type;
        private string _Title;
        private int _Count;
        private int _Area;
        private int _FloorNum;
        private string _Desc;

        #endregion Fields

        #region Properties

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int FloorNum
        {
            get { return _FloorNum; }
            set { _FloorNum = value; }
        }

        public int Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        #endregion Properties
    }
}
