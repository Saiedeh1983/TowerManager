using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Alma.DAL
{
    public class CnnManager
    {
        OleDbConnection cn;
        private static CnnManager instance;
       
        private CnnManager()
        {
            AppSettingsReader r = new AppSettingsReader();
            
           //cn = new OleDbConnection(r.GetValue("CnnString", typeof(string)).ToString());
        }
        public static CnnManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CnnManager();
                return instance;
            }
        }
        public OleDbConnection GetConnection()
        {
            cn = new OleDbConnection(ConfigurationManager.AppSettings["CnString"]);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            return cn;
        }
        public void FreeConnection()
        {
            cn = new OleDbConnection(ConfigurationManager.AppSettings["CnString"]);
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
    }
}

