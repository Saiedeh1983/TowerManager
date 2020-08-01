using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class CarInfo
  {
      #region Fields

      private int _CarInfoID;
      private int _InfoID;
      private string _CarInfoValue;
      private string _CarInfoDesc;

      #endregion Fields

      #region Properties


      public string CarInfoDesc
{
  get { return _CarInfoDesc; }
  set { _CarInfoDesc = value; }
}public string CarInfoValue
{
  get { return _CarInfoValue; }
  set { _CarInfoValue = value; }
}
      public int InfoID
{
    get { return _InfoID; }
    set { _InfoID = value; }
}public int CarInfoID
{
  get { return _CarInfoID; }
  set { _CarInfoID = value; }
}
    #endregion Properties
}
}
