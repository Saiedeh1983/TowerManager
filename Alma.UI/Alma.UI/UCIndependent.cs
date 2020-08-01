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
    public partial class UCIndependent : UserControl
    {
        DAL.DAL dal = new Alma.DAL.DAL();
        Independent independent = new Independent();
        List<Independent> independentList = new List<Independent>();
        List<DetailInfo> detailInfoList = new List<DetailInfo>();
        int id = 0;
        public UCIndependent()
        {
            InitializeComponent();
        }

        private void LoadUC()
        {
            detailInfoList = dal.LoadDetailInfoListWithBaseID(6);
            for (int j = 0; detailInfoList.Count > j; j++)
            {
                comType.Items.Add(detailInfoList[j].DetailInfoTitle);
            }
            independentList = dal.LoadIndependentList();
            gridEXIndependent.DataSource = independentList;
            gridEXIndependent.RetrieveStructure();
            gridEXIndependent.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
        }
        private Independent LoadControls()
        {
            if (independent == null)
                independent = new Independent();
            independent.Type = comType.Text;
            independent.Title = txtTitle.Text;
            independent.Count = Convert.ToInt32(numCount.Value); 
            independent.Area =Convert.ToInt32( numArea.Value);
            independent.FloorNum = Convert.ToInt32(numFloorNum.Value);
            independent.Desc =txtDesc.Text;
            independent.ID = id;
            return independent;
        }

        private void Clear()
        {
            comType.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }
        private void FillControl(Independent independent)
        {
            comType.Text = independent.Type.ToString();
            txtTitle.Text = independent.Title.ToString();
            numCount.Value = Convert.ToDecimal(independent.Count);
            numArea.Value = Convert.ToDecimal(independent.Area);
            numFloorNum.Value = Convert.ToDecimal(independent.FloorNum);
            txtDesc.Text = independent.Desc;
            id = independent.ID;

        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXIndependent.Tables[0].Columns)
            {
                if (c.Caption == "Type")
                {
                    c.Caption = "نوع";
                }
                if (c.Caption == "Title")
                {
                    c.Caption = "عنوان";
                }
                if (c.Caption == "Count")
                {
                    c.Caption = "تعداد";
                    //c.Width = 200;
                }
                if (c.Caption == "Area")
                {
                    c.Caption = "متراژ";
                }
                if (c.Caption == "ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Floor Num")
                {
                    c.Caption = "طبقه";
                }
                if (c.Caption == "Desc")
                {
                    c.Visible = false;
                }
            }
        }

        private void UCIndependent_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا مستقلات مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (independent != null)
                {
                    dal.DeleteIndependent(independent.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            independent = new Independent();
            independent = LoadControls();
            if (independent.Count != 0 && independent.Title != "" && independent.Type != "")
            {
               bool Test=dal.InsertIndependent(independent);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (independent != null)
            {
                independent = LoadControls();
                dal.EditIndependent(independent);
                LoadUC();
            }
        }

        private void gridEXIndependent_SelectionChanged(object sender, EventArgs e)
        {
            independent = (Independent)gridEXIndependent.BindingContext[gridEXIndependent.DataSource].Current;
            FillControl(independent);
        }
    }
}
