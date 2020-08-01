using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Tower
    {

        #region Fields
        private int _ID;
        private string _TowerTitle;
        private string _TowerNum;
        private int _UnitNum;
        private int _Area;
        private int _FloorCount;
        private int _ParkingCount;
        #endregion Fields

        #region Properties

        public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
        public int ParkingCount
        {
            get { return _ParkingCount; }
            set { _ParkingCount = value; }
        }

        public int FloorCount
        {
            get { return _FloorCount; }
            set { _FloorCount = value; }
        }

        public int Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        public int UnitNum
        {
            get { return _UnitNum; }
            set { _UnitNum = value; }
        }

        public string TowerNum
        {
            get { return _TowerNum; }
            set { _TowerNum = value; }
        }



        public string TowerTitle
        {
            get { return _TowerTitle; }
            set { _TowerTitle = value; }
        }
        #endregion Properties
    }
}
