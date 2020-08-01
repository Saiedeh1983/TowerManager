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
    public partial class UCFloor : UserControl
    {
        DAL.DAL dal = new Alma.DAL.DAL();
        Floor floor = new Floor();
        List<Floor> floorList = new List<Floor>();
        Tower tower = new Tower();
        int id = 0;
        int floorcount = 0;
        int countUnit = 0;
        public UCFloor()
        {
            InitializeComponent();
        }
        private void LoadUC()
        {
            int floorcount = 0;
            int countUnit = 0;
            DAL.DAL dal = new DAL.DAL();
            List<Unit> unitList = new List<Unit>();
            List<Floor> floorList = new List<Floor>();
            Floor floor = new Floor();
            floorList = dal.LoadFloorList();
            gridEXFloor.DataSource = floorList;
            gridEXFloor.RetrieveStructure();
            gridEXFloor.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
            floorcount = dal.LoadFloorList().Count;
            tower = dal.LoadTower(1);
            for (int i = 1;floorcount>=i ; i++)
            {
                floor = dal.LoadFloor(i);
                countUnit=floor.UnitCount+countUnit;
            }
            int Count=tower.UnitNum - countUnit;
            if (Count < 0)
            {
                Count = countUnit - tower.UnitNum;
                label7.Text = Count.ToString() + "-";
            }
            else
            label7.Text = Count.ToString(); 
        }

        private void Clear()
        {
            txtFloorTitle.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }

        private Floor LoadControls()
        {
            if (floor == null)
                floor = new Floor();
            floor.FloorNum = Convert.ToInt16(numFloorNum.Value);
            floor.FloorTitle = txtFloorTitle.Text;
            floor.UnitCount = Convert.ToInt16(UnitCount.Value);
            floor.ID = id;
            if (radioUnder.Checked == true)
            {
                floor.Area ="زیر زمین";
            }
            if (radioTop.Checked == true)
            {
                floor.Area = "روی زمین";
            }
            if (checkHalfFloor.Checked == true)
            {
                floor.Half = true;
            }
            else
            {
                floor.Half = false;
            }
            floor.Desc = txtDesc.Text;
            return floor;
        }
        private void FillControl(Floor floor)
        {
            txtFloorTitle.Text = floor.FloorTitle.ToString();
            UnitCount.Value = floor.UnitCount;
            numFloorNum.Value = floor.FloorNum;
            txtDesc.Text = floor.Desc;
            id = floor.ID;
            if (floor.Area =="زیر زمین")
            {
                radioTop.Checked = false;
                radioUnder.Checked = true;
            }
            if (floor.Area =="روی زمین")
            {
                radioTop.Checked =true;
                radioUnder.Checked =false;
            }
            if (floor.Half == true)
            {
                checkHalfFloor.Checked =true;
            }
            else
            {
                checkHalfFloor.Checked = false;
            }
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXFloor.Tables[0].Columns)
            {
                if (c.Caption == "Floor Num")
                {
                    c.Caption = "شماره طبقه";
                }
                if (c.Caption == "Unit Count")
                {
                    c.Caption = "تعداد واحد";
                }
                if (c.Caption == "Area")
                {
                    c.Caption = "مکان طبقه";
                }
                if (c.Caption == "Half")
                {
                    c.Caption = "نیم طبقه";
                }
                if (c.Caption == "Floor Title")
                {
                    c.Caption = "عنوان طبقه";
                }
                if (c.Caption == "ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Desc")
                {
                    c.Visible = false;
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا طبقه مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (floor != null)
                {
                    dal.DeleteFloor(floor.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (floor != null)
            {
               //countUnit= floor.UnitCount + countUnit;
                countUnit =countUnit+int.Parse(UnitCount.Value.ToString());
               //if (countUnit > tower.UnitNum)
               //{
               //    MessageBox.Show("!" + "تعداد واحدها از میزان مجاز بیشتر شده");
               //    LoadUC();
               //}
               //else
               //{
                   floor = LoadControls();
                   dal.EditFloor(floor);
                   LoadUC();
               //}
            }
        }

        private void UCFloor_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            floor = new Floor();
            floor = LoadControls();
            tower = dal.LoadTower(1);
            int count1 = tower.FloorCount;
            floorcount = dal.LoadFloorList().Count;
            if (floorcount < count1)
            {
                if (countUnit <= tower.UnitNum)
                {

                    if (floor.Area != "" && floor.UnitCount != 0 && floor.FloorNum != 0)
                    {


                        bool Test=dal.InsertFloor(floor);
                        if (Test == false)
                            MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (Test == true)
                        {
                            LoadUC();
                            if (countUnit > tower.UnitNum)
                            {
                                MessageBox.Show("!" + "تعداد واحدها از میزان مجاز بیشتر شده");
                            }

                            MessageBox.Show("ثبت شد");
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفاً تمامی فیلدها را پر نمائید");
                    }
                }
                else
                    MessageBox.Show("شما مجاز به وارد کردن واحد جدید نمی باشید");
            }
                    else
                        MessageBox.Show("شما مجاز به وارد کردن طبقه جدید نمی باشید");
        }

        private void gridEXFloor_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEXFloor.DataSource != null)
            {
                floor = (Floor)gridEXFloor.BindingContext[gridEXFloor.DataSource].Current;
                FillControl(floor);
            }
        }
    }
}
