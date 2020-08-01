using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class IndependentSharj
   {
       #region Fields

       private int _ID;
        private int _IndependentID;
        private int _Sharj;
        private string _Desc;

        #endregion Fields

        #region Proerties

        public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int Sharj
        {
            get { return _Sharj; }
            set { _Sharj = value; }
        }

        public int IndependentID
        {
            get { return _IndependentID; }
            set { _IndependentID = value; }
        }
        #endregion Proerties
    }
}
