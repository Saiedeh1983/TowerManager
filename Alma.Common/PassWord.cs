using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class PassWord
   {
       #region Fields

       private int _ID;
       private string _UserName;
       private int _Password;
       private string _Desc;
       private string _SequrityStr;

       #endregion Fields

       #region Properties

       public string SequrityStr
       {
           get { return _SequrityStr; }
           set { _SequrityStr = value; }
       }
       
       public string Desc
       {
           get { return _Desc; }
           set { _Desc = value; }
       }

       public int Password
       {
           get { return _Password; }
           set { _Password = value; }
       }

       public string UserName
       {
           get { return _UserName; }
           set { _UserName = value; }
       }

       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       #endregion Properties
   }
}
