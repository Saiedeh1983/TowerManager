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
    public partial class ucFiche : UserControl
    {
        Fiche fiche = new Fiche();
        List<Fiche> ficheList = new List<Fiche>();
        DAL.DAL dal = new Alma.DAL.DAL();
        int id = 0;
        public ucFiche()
        {
            InitializeComponent();
        }
        private void FillControl(Fiche fiche)
        {
           multiTypeContor.Text= fiche.TypeContor ;
           txtSharj.Text=fiche.Cost.ToString();
           textTitle.Text= fiche.Title ;
           id= fiche.FicheID;
           txtUntillDate.Text=fiche.UntillDate;
           txtFromDate.Text=fiche.FromDate;
           txtDesc.Text=fiche.Desc;
        }
        private void Clear()
        {
            txtSharj.Text = string.Empty;
            txtDesc.Text = string.Empty;
            //tx.Text = string.Empty;
            
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridFiche.Tables[0].Columns)
            {
                if (c.Caption == "Title")
                {
                    c.Caption = "عنوان";
                }
                if (c.Caption == "Cost")
                {
                    c.Caption = "هزینه";
                }
                //if (c.Caption == "TypeContor")
                //{
                //    c.Caption = "نوع کنتور";
                //}
                if (c.Caption == "Type Contor")
                {
                    c.Caption = "نوع کنتور";
                }
                if (c.Caption == "Fiche ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Desc")
                {
                    c.Visible = false;
                }
                if (c.Caption == "From Date")
                {
                    c.Caption = "از تاریخ";
                }
                if (c.Caption == "Untill Date")
                {
                    c.Caption = "تا تاریخ";
                }
            }
        }
        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            ficheList = dal.LoadFicheList();
            gridFiche.DataSource = ficheList;
            gridFiche.RetrieveStructure();
            gridFiche.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();

        }

        private Fiche LoadControls()
        {
            if (fiche == null)
                fiche = new Fiche();
            fiche.TypeContor = multiTypeContor.Text;
            fiche.Cost =int.Parse( txtSharj.Text);
            fiche.Title = textTitle.Text;
            fiche.FicheID = id;
            fiche.UntillDate = txtUntillDate.Text;
            fiche.FromDate = txtFromDate.Text;
            fiche.Desc = txtDesc.Text;
            return fiche;
        }
        private void ucFiche_Load(object sender, EventArgs e)
        {
            btnCancel.Click+=new EventHandler(btnCancel_Click);
            btnClear.Click+=new EventHandler(btnClear_Click);
            btnEdit.Click+=new EventHandler(btnEdit_Click);
            btnOK.Click+=new EventHandler(btnOK_Click);
            gridFiche.SelectionChanged+=new EventHandler(gridFiche_SelectionChanged);
            LoadUC();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (fiche != null)
            {
                fiche = LoadControls();
                dal.EditFiche(fiche);
                LoadUC();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا قبض مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (fiche != null)
                {
                    dal.DeleteFiche(fiche.FicheID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            fiche = new Fiche();
            fiche = LoadControls();
            if (fiche.Title != "" && fiche.Cost != 0)
            {
               bool Test = dal.InsertFiche(fiche);
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

        private void gridFiche_SelectionChanged(object sender, EventArgs e)
        {
            fiche = (Fiche)gridFiche.BindingContext[gridFiche.DataSource].Current;
            FillControl(fiche);
        }
    }
}
