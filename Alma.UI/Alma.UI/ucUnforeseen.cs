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
    public partial class ucUnforeseen : UserControl
    {
        Unforeseen unforeseen=new Unforeseen();
        List<Unforeseen> unforeseenList=new List<Unforeseen>();
        DAL.DAL dal = new Alma.DAL.DAL();
        int id = 0;
        public ucUnforeseen()
        {
            InitializeComponent();
        }

        private void ucUnforeseen_Load(object sender, EventArgs e)
        {
            gridUnforeseen.SelectionChanged+=new EventHandler(gridUnforeseen_SelectionChanged);
            btnCancel.Click+=new EventHandler(btnCancel_Click);
            btnClear.Click+=new EventHandler(btnClear_Click);
            btnEdit.Click+=new EventHandler(btnEdit_Click);
            btnOK.Click+=new EventHandler(btnOK_Click);
            LoadUC();
        }
         private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            unforeseenList = dal.LoadUnforeseenList();
            gridUnforeseen.DataSource = unforeseenList;
            gridUnforeseen.RetrieveStructure();
            gridUnforeseen.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridUnforeseen.Tables[0].Columns)
            {
                if (c.Caption == "Title")
                {
                    c.Caption = "عنوان";
                }
                if (c.Caption == "Sharj")
                {
                    c.Caption = "هزینه شارژ";
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
            textTitle.Text="";
        }

        private Unforeseen LoadControls()
        {
            if (unforeseen == null)
                unforeseen = new Unforeseen();
            unforeseen.Title = textTitle.Text.ToString();
            unforeseen.Sharj = Convert.ToInt32(txtSharj.Text.ToString());
            unforeseen.Desc = txtDesc.Text;
            unforeseen.ID = id;
            return unforeseen;
        }
        private void FillControl(Unforeseen unforeseen)
        {
           textTitle.Text=unforeseen.Title.ToString();
            txtSharj.Text = unforeseen.Sharj.ToString();
            txtDesc.Text = unforeseen.Desc.ToString();
            id = unforeseen.ID;
        }

        private void gridUnforeseen_SelectionChanged(object sender, EventArgs e)
        {
            unforeseen = (Unforeseen)gridUnforeseen.BindingContext[gridUnforeseen.DataSource].Current;
            FillControl(unforeseen);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (unforeseen != null)
            {
                unforeseen = LoadControls();
                dal.EditUnforeseen(unforeseen);
                LoadUC();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (unforeseen != null)
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا رکورد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    dal.DeleteUnforeseen(unforeseen.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            unforeseen = new Unforeseen();
            unforeseen = LoadControls();
            if (unforeseen.Sharj != 0 && unforeseen.Title != "" )
            {
                bool Test=dal.InsertUnforeseen(unforeseen);
                if (Test == false)
                    MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Test == true)
                {
                    LoadUC();
                    MessageBox.Show("ثبت شد");
                }
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را پر نمائید");
            }
        }
        }
    }

