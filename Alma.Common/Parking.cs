using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Parking
   {
       #region Fields

       private long _ID;
       private string _ParkCode;
       private int _ParkSize;
       private string _ParkDesc;

       #endregion Fields

       #region Properties

       public long ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       public string ParkDesc
       {
           get { return _ParkDesc; }
           set { _ParkDesc = value; }
       }


       public string ParkCode
       {
           get { return _ParkCode; }
           set { _ParkCode = value; }
       }
       public int ParkSize
       {
           get { return _ParkSize; }
           set { _ParkSize = value; }
       }

       #endregion Properties
   }
}
