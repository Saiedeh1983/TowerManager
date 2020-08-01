using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Alma.DAL;
using Alma.Common;

namespace Alma.UI
{
    public partial class ucPassord : UserControl
    {
        PassWord password = new PassWord();
        public ucPassord()
        {
            InitializeComponent();
        }
        private void FillControl(PassWord password)
        {
            //txtNewUserName.Text = password.txtNewUserName;
            //txtNewPassword.Text = password.txtNewPassword;
            //txtPerDesc.text= password.txtPerDesc;
            //FloorCount.Value = tower.FloorCount;
            //txtPassword.Value = tower.UnitNum;
            //id = tower.ID;
        }

        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            PassWord password = new PassWord();
            List<PassWord> passwordList = new List<PassWord>();
            //passwordList = dal.LoadpasswordList();
           
        }

        private void Clear()
        {
           //txtPerUserName.Text = string.Empty;
           //txtPerPassword.Text = string.Empty;
           txtPreDesc.Text = string.Empty;
           txtNewUserName.Text = string.Empty;
           txtNewPassword.Text = string.Empty;
           txtNewDesc.Text = string.Empty;
        }

        private PassWord LoadControls()
        {
            if (password == null)
                password = new PassWord();
         //   password.txtPerUserName = txtPerUserName.Text;
         //   password.txtPerPassword = txtPerPassword.Text;
         //pa
           
            
            
         //   tower.ID = id;
            return password;
        }
        private void ucPassord_Load(object sender, EventArgs e)
        {
            //btnCancel.Click+=new EventHandler(btnCancel_Click);
            //btnClear.Click+=new EventHandler(btnClear_Click);
            //btnEdit.Click+=new EventHandler(btnEdit_Click);
            //btnOK.Click+=new EventHandler(btnOK_Click);
        }
    }
}
