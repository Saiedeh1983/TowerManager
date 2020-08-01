using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Floor
   {
       #region Fields
       private int _ID;
       private int _FloorNum;
       private int _UnitCount;
       private string _Area;
       private bool _Half;
       private string _Desc;
       private string _FloorTitle;

       
       #endregion Fields

       #region Properties

       public string FloorTitle
       {
           get { return _FloorTitle; }
           set { _FloorTitle = value; }
       }
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

       public bool Half
       {
           get { return _Half; }
           set { _Half = value; }
       }

       public string Area
       {
           get { return _Area; }
           set { _Area = value; }
       }

       public int UnitCount
       {
           get { return _UnitCount; }
           set { _UnitCount = value; }
       }

       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       #endregion Properties


   }
}
