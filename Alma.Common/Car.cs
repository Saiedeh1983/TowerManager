using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
    public class Car
    {
        #region Field
        
        private int _ID;
        private string _Code;
        private string _Color;
        private string _Model;
        private int _Owner;
        private string _Desc;

        #endregion Field


        #region Properties

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }


        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        #endregion Properties
    }
}
