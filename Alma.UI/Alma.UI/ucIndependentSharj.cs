using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Alma.Common;
using Alma.DAL;

namespace Alma.UI
{
    public partial class ucIndependentSharj : UserControl
    {
      
        int IndependentID = 0;
        DAL.DAL dal = new Alma.DAL.DAL();
        IndependentSharj independentsharj = new IndependentSharj();
        List<IndependentSharj> independentsharjList = new List<IndependentSharj>();
        Independent Independent = new Independent();
        List<Independent> IndependentList = new List<Independent>();
        int id = 0;
        public ucIndependentSharj()
        {
            
            InitializeComponent();
        }

        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            independentsharjList = dal.LoadIndependentSharjList();
            gridIndependentSharj.DataSource = independentsharjList;
            gridIndependentSharj.RetrieveStructure();
            gridIndependentSharj.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();

            IndependentList = dal.LoadIndependentList();
            for (int i = 0; IndependentList.Count > i; i++)
            {
                comIndependent.Items.Add(IndependentList[i].Title);
            }
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridIndependentSharj.Tables[0].Columns)
            {
                if (c.Caption == "Independent ID")
                {
                    c.Caption = "شماره";
                }
                if (c.Caption == "Sharj")
                {
                    c.Caption = "شارژ";
                }
                if (c.Caption == "ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Desc")
                {
                    c.Caption = "توضیحات";
                    c.Width = 200;
                }
            }
        }

        private void Clear()
        {
            txtDesc.Text = "";
            txtSharj.Text = "";
        }

        private IndependentSharj LoadControls()
        {
            if (independentsharj == null)
            independentsharj = new IndependentSharj();
            Independent =dal.LoadIndependentWithTitle( comIndependent.Text);
            independentsharj.IndependentID = Convert.ToInt32(Independent.ID.ToString());
            independentsharj.Sharj = Convert.ToInt32(txtSharj.Text.ToString());
            independentsharj.Desc = txtDesc.Text;
            independentsharj.ID = id;
            return independentsharj;
        }
        private void FillControl(IndependentSharj independentsharj)
        {
            Independent = dal.LoadIndependent(independentsharj.ID);
            comIndependent.Text =Independent.Title.ToString();
            txtSharj.Text = independentsharj.Sharj.ToString();
            txtDesc.Text = independentsharj.Desc.ToString();
            id = independentsharj.ID;
        }

        private void ucIndependentSharj_Load(object sender, EventArgs e)
        {
            LoadUC();
            gridIndependentSharj.SelectionChanged += new EventHandler(gridIndependentSharj_SelectionChanged);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (independentsharj != null)
            {
                independentsharj = LoadControls();
                dal.EditIndependentSharj(independentsharj);
                LoadUC();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            independentsharj = new IndependentSharj();
            independentsharj = LoadControls();
            if (independentsharj.IndependentID != 0 && independentsharj.Sharj != 0 )
            {
                dal.InsertIndependentSharj(independentsharj);
                LoadUC();
                MessageBox.Show("ثبت شد");
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را پر نمائید");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا رکورد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (independentsharj != null)
                {
                    dal.DeletendependentSharj(independentsharj.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gridIndependentSharj_SelectionChanged(object sender, EventArgs e)
        {
            independentsharj = (IndependentSharj)gridIndependentSharj.BindingContext[gridIndependentSharj.DataSource].Current;
            FillControl(independentsharj);
        }
       
    }
}
