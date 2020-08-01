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
    public partial class UCTower : UserControl
    {
        DAL.DAL dal = new DAL.DAL();
        List<Tower> TowerList = new List<Tower>();
        Tower tower = new Tower();
        int id = 0;
        public UCTower()
        {
            InitializeComponent();
        }

        private void FillControl(Tower tower)
        {
            txtTowerTitle.Text = tower.TowerTitle;
            txtTowerNumber.Text = tower.TowerNum;
            ParkingCount.Value = tower.ParkingCount;
            FloorCount.Value = tower.FloorCount;
            UnitCount.Value = tower.UnitNum;
            id = tower.ID;
        }

        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            List<Tower> TowerList = new List<Tower>();
            TowerList = dal.LoadTowerList();
            //gridEXTowers.DataSource = TowerList;
            //gridEXTowers.RetrieveStructure();
            //gridEXTowers.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            //gridMaker();
        }

        private void Clear()
        {
            txtTowerTitle.Text = string.Empty;
            txtTowerNumber.Text = string.Empty;
            ParkingCount.Value = 0;
            FloorCount.Value = 1;
            UnitCount.Value = 1;
        }

        private Tower LoadControls()
        {
            if (tower == null)
                tower = new Tower();
            tower.TowerTitle = txtTowerTitle.Text;
            tower.TowerNum = txtTowerNumber.Text;
            tower.ParkingCount = Convert.ToInt32(ParkingCount.Value);
            tower.FloorCount = Convert.ToInt32(FloorCount.Value);
            tower.UnitNum = Convert.ToInt32(UnitCount.Value);
            tower.ID = id;
            return tower;
        }
        //private void gridMaker()
        //{
        //    foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXTowers.Tables[0].Columns)
        //    {
        //        if (c.Caption == "Tower Title")
        //        {
        //            c.Caption = "نام برج";
        //        }
        //        if (c.Caption == "Floor Count")
        //        {
        //            c.Caption = "تعداد طبقه";
        //        }
        //        if (c.Caption == "Unit Num")
        //        {
        //            c.Caption = "تعداد واحد";

        //        }
        //        if (c.Caption == "Parking Count")
        //        {
        //            c.Visible = false;
        //        }
        //        if (c.Caption == "Area")
        //        {
        //            c.Caption = "مساحت";
        //        }
        //        if (c.Caption == "Tower Num")
        //        {
        //            c.Caption = "شماره پلاک";
        //        }
        //        if (c.Caption == "ID")
        //        {
        //            c.Visible = false;
        //        }
        //        if (c.Caption == "TowerDesc")
        //        {
        //            c.Visible = false;
        //        }
        //    }
        //}
        private void UCTower_Load(object sender, EventArgs e)
        {
            LoadUC();  
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tower != null)
            {
                tower = LoadControls();
                dal.EditTower(tower);
                LoadUC();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            tower = new Tower();
            int towercount=dal.LoadTowerList().Count;
            if (towercount == 0)
            {
                tower = LoadControls();
                if (tower.TowerTitle != "" && tower.TowerNum != "" && tower.FloorCount != 0)
                {
                     bool Test=dal.InsertTower(tower);
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
            else
                MessageBox.Show("شما مجاز به وارد کردن برج جدید نمی باشید");

            //try
            //{

            //    if (dal.InsertTower(tower);.ToString().Trim() == dsinsert.Tables[0].Rows[0]["TowerID"].ToString().Trim())
            //    {
            //        MessageBox.Show("TowerID is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        dal.InsertTower(tower);
            //    }
            //}
            //catch
            //{
            //    dal.InsertTower(tower);
            //}

//            // If a node is double-clicked, open the file indicated by the TreeNode.
//void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
//{
//    try
//    {
//        // Look for a file extension.
//        if (e.Node.Text.Contains("."))
//            System.Diagnostics.Process.Start(@"c:\" + e.Node.Text);
//    }
//        // If the file is not found, handle the exception and inform the user.
//    catch (System.ComponentModel.Win32Exception)
//    {
//        MessageBox.Show("File not found.");
//    }
//}


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (tower != null)
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا برج مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    dal.DeleteTower(tower.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        //private void gridEXTowers_SelectionChanged(object sender, EventArgs e)
        //{
        //    tower = (Tower)gridEXTowers.BindingContext[gridEXTowers.DataSource].Current;
        //    FillControl(tower);
        //}
    }
}
