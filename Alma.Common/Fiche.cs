using System;
using System.Collections.Generic;
using System.Text;

namespace Alma.Common
{
   public class Fiche
    {
        private int _FicheID;
        private string _Title;
        private int _Cost;
        private string _Desc;
        private string _FromDate;
        private string _UntillDate;
        private string _TypeContor;

        public string TypeContor
        {
            get { return _TypeContor; }
            set { _TypeContor = value; }
        }

        public string UntillDate
        {
            get { return _UntillDate; }
            set { _UntillDate = value; }
        }

        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        public int Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public int FicheID
        {
            get { return _FicheID; }
            set { _FicheID = value; }
        }
    }
}
