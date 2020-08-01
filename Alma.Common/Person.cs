using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
  public  class Person
    {
        #region Fields
        private int _PersonID;
        private string _Name;
        private string _Family;
        private string _FatherName;
        private string _RegisterCardNum;
        private string _NationalCode;
        private string _PicturePath;
        private bool _Sex;
        private string _DateEnter;
        private string _DateExit;
        private string _Telephon;
        private string _Mobile;
        #endregion Fields

        #region Properties

      public string Mobile
      {
          get { return _Mobile; }
          set { _Mobile = value; }
      }
       
      public string Telephon
      {
          get { return _Telephon; }
          set { _Telephon = value; }
      }
        public string DateExit
        {
            get { return _DateExit; }
            set { _DateExit = value; }
        }

        public string DateEnter
        {
            get { return _DateEnter; }
            set { _DateEnter = value; }
        }
        public bool Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        public string PicturePath
        {
            get { return _PicturePath; }
            set { _PicturePath = value; }
        }

        public string NationalCode
        {
            get { return _NationalCode; }
            set { _NationalCode = value; }
        }

        public string RegisterCardNum
        {
            get { return _RegisterCardNum; }
            set { _RegisterCardNum = value; }
        }

        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }

        public string Family
        {
            get { return _Family; }
            set { _Family = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        #endregion Properties
    }
}
