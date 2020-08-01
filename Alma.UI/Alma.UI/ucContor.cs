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
    public partial class ucContor : UserControl
    {
        DAL.DAL dal = new Alma.DAL.DAL();
        Contor contor = new Contor();
        List<Contor> contorList = new List<Contor>();
        int id = 0;
        public ucContor()
        {
            InitializeComponent();
        }
        private void LoadUC()
        {
            DAL.DAL dao = new DAL.DAL();
            contorList = dal.LoadContorList();
            gridEXContor.DataSource = contorList;
            gridEXContor.RetrieveStructure();
            gridEXContor.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
            
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXContor.Tables[0].Columns)
            {
                if (c.Caption == "Contor Num")
                {
                    c.Caption = "شماره";
                }
                if (c.Caption == "Contor Value")
                {
                    c.Caption = "مقدار";
                }
                if (c.Caption == "Contor ID")
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
            txtValue.Text = "";
        }

        private Contor LoadControls()
        {
            if (contor == null)
                contor = new Contor();
            contor.ContorNum =Convert.ToInt32(ContorNum.Value);
            contor.ContorValue = txtValue.Text;
            contor.Desc = txtDesc.Text;
            contor.ContorID = id;
            return contor;
        }
        private void FillControl(Contor contor)
        {
            ContorNum.Value =decimal.Parse( contor.ContorNum.ToString());
            txtValue.Text = contor.ContorValue.ToString();
            txtDesc.Text = contor.Desc.ToString();
            id = contor.ContorID;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DAL.DAL dal = new Alma.DAL.DAL();
            contor = LoadControls();
            if (contor.ContorNum != 0 && contor.ContorValue != "")
            {
                bool Test=dal.InsertContor(contor);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا کنتور مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (contor != null)
                {
                    dal.DeleteContor(contor.ContorID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (contor != null)
            {
                contor = LoadControls();
                dal.EditContor(contor);
                LoadUC();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gridEXContor_SelectionChanged(object sender, EventArgs e)
        {
            contor = (Contor)gridEXContor.BindingContext[gridEXContor.DataSource].Current;
            FillControl(contor);
        }

        private void ucContor_Load(object sender, EventArgs e)
        {
            LoadUC();
        }
    }
}
