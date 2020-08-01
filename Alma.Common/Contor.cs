using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class Contor
  {
      #region Fields

      private int _ContorID;
      private int _ContorNum;
      private string _ContorValue;
      private string _Desc;

      #endregion Fields

      #region Properties

      public string ContorValue
      {
          get { return _ContorValue; }
          set { _ContorValue = value; }
      }

      public int ContorNum
      {
          get { return _ContorNum; }
          set { _ContorNum = value; }
      }
      public int ContorID
      {
          get { return _ContorID; }
          set { _ContorID = value; }
      }
      public string Desc
      {
          get { return _Desc; }
          set { _Desc = value; }
      }

      #endregion Properties
  }
}
