using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Unit
    {
        #region Fields
        private int _ID;
        private int _UnitCode;
        private int _UnitArea;
        private int _UnitPersonsNum;
        private int _UnitFloor;
        private string _Type;
        private string _Desc;
        private string _UnitNumber;
        private int _UnitRooms;
        #endregion Fields

        #region Properties

       public string UnitNumber
       {
           get { return _UnitNumber; }
           set { _UnitNumber = value; }
       }
       public int UnitRooms
       {
           get { return _UnitRooms; }
           set { _UnitRooms = value; }
       }

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
      
       public string Type
       {
           get { return _Type; }
           set { _Type = value; }
       }
        public int UnitFloor
        {
            get { return _UnitFloor; }
            set { _UnitFloor = value; }
        }

        public int UnitPersonsNum
        {
            get { return _UnitPersonsNum; }
            set { _UnitPersonsNum = value; }
        }

        public int UnitArea
        {
            get { return _UnitArea; }
            set { _UnitArea = value; }
        }

        public int UnitCode
        {
            get { return _UnitCode; }
            set { _UnitCode = value; }
        }
        #endregion Properties
    }
}
