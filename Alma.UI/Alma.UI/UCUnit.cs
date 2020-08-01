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
    public partial class UCUnit : UserControl
    {
        DAL.DAL dao = new DAL.DAL();
        Unit unit = new Unit();
        List<Unit> unitList = new List<Unit>();
        DAL.DAL dal = new Alma.DAL.DAL();
        UnitInfo unitInfo = new UnitInfo();
        List<UnitInfo> unitInfoList = new List<UnitInfo>();
        DetailInfo detailInfo2 = new DetailInfo();
        DetailInfo DetailInfoU = new DetailInfo();
        DetailInfo detailInfo = new DetailInfo();
        int detailInfoIDU = 0;
        List<DetailInfo> detailInfoList2 = new List<DetailInfo>();
        Unit_Person unit_person = new Unit_Person();
        List<Person> personList = new List<Person>();
        Person person = new Person();
        Unit_Person unitperson = new Unit_Person();
        List<Unit_Person> unitpersonList = new List<Unit_Person>();
        Unit_Person unitperson1 = new Unit_Person();
        int id = 0;
        int idInfo = 0;
        public UCUnit()
        {
            InitializeComponent();
        }
        private void LoadU()
        {
         //مالک
            multiColumnOwner.Clear();
            personList = dal.LoadPersonList();
            multiColumnOwner.DataSource = personList;
            multiColumnOwner.DisplayMember = "Family";
            multiColumnOwner.ValueMember = "PersonID";
            Janus.Windows.GridEX.GridEXColumn Col = new Janus.Windows.GridEX.GridEXColumn();
            Col.Caption = "نام";
            Col.DataMember = "Name";
            multiColumnOwner.DropDownList.Columns.Add(Col);
            Janus.Windows.GridEX.GridEXColumn Col1 = new Janus.Windows.GridEX.GridEXColumn();
            Col1.Caption = "نام خانوادگی";
            Col1.DataMember = "Family";
            multiColumnOwner.DropDownList.Columns.Add(Col1);
            Janus.Windows.GridEX.GridEXColumn Col2 = new Janus.Windows.GridEX.GridEXColumn();
            Col2.Caption = "شماره شناسنامه";
            Col2.DataMember = "RegisterCardNum";
            multiColumnOwner.DropDownList.Columns.Add(Col2);

            //مستاجر
            multiColumnLessee.Clear();
            personList = dal.LoadPersonList();
            multiColumnLessee.DataSource = personList;
            multiColumnLessee.DisplayMember = "Family";
            multiColumnLessee.ValueMember = "PersonID";
            Janus.Windows.GridEX.GridEXColumn col = new Janus.Windows.GridEX.GridEXColumn();
            col.Caption = "نام";
            col.DataMember = "Name";
            multiColumnLessee.DropDownList.Columns.Add(col);
            Janus.Windows.GridEX.GridEXColumn col1 = new Janus.Windows.GridEX.GridEXColumn();
            col1.Caption = "نام خانوادگی";
            col1.DataMember = "Family";
            multiColumnLessee.DropDownList.Columns.Add(col1);
            Janus.Windows.GridEX.GridEXColumn col2 = new Janus.Windows.GridEX.GridEXColumn();
            col2.Caption = "شماره شناسنامه";
            col2.DataMember = "RegisterCardNum";
            multiColumnLessee.DropDownList.Columns.Add(col2);
    }
        private void LoadUC()
        {

            //اطلاعات تکمیلی
            detailInfoList2 = dal.LoadDetailInfoListWithBaseID(2);
            for (int j = 0; detailInfoList2.Count > j; j++)
            {
                comDetailUnit.Items.Add(detailInfoList2[j].DetailInfoTitle);
            }
            //gridMakerUnit();
            personList = dal.LoadPersonList();
            multiColumnOwner.DataSource = personList;

            /// اشخاص
            personList = dal.LoadPersonList();
           
            //لیست اطلاعات اصلی
            unitList = dal.LoadUnitList();
            gridEXUnit.DataSource = unitList;
            gridEXUnit.RetrieveStructure();
            gridEXUnit.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMakerUnit();

            //لیست اطلاعات تکمیلی
            unitInfoList = dal.LoadUnitInfoList();
            gridEXUnitInfo.DataSource = unitInfoList;
            gridEXUnitInfo.RetrieveStructure();
            gridEXUnitInfo.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMakerUnitInfo();
        }
        private Unit LoadControls()
        {
            if (unit == null)
                unit = new Unit();
            unit.Type = comUnitType.Text;
            unit.UnitCode = Convert.ToInt32(txtUnitCode.Text);
            unit.UnitNumber = txtUnitNumber.Text;
            unit.Desc = txtDesc.Text;
            unit.UnitArea = Convert.ToInt32(UnitArea.Value);
            unit.UnitFloor = Convert.ToInt32(txtUnitFloor.Text);
            unit.UnitPersonsNum = Convert.ToInt32(numUnitPersonsNum.Value);
            unit.UnitRooms = Convert.ToInt32(numUnitRooms.Value);
            unit.ID = id;
            return unit;
        }

        private UnitInfo LoadControlsU()
        {
            if (unitInfo == null)
                unitInfo = new UnitInfo();
            unitInfo.UnitInfoValue = txtDetailNameU.Text;
            detailInfo = dal.LoadDetailInfoWithTitle(comDetailUnit.Text);

            detailInfoIDU = detailInfo.DetailInfoID;
            unitInfo.InfoID = detailInfoIDU;
            unitInfo.UnitInfoDesc = txtDescU.Text;
            unitInfo.UnitInfoID = id;
            return unitInfo;
        }

        private void FillControlU(UnitInfo unitInfo)
        {
            txtDetailNameU.Text = unitInfo.UnitInfoValue.ToString();
            detailInfo = dal.LoadDetailInfo(unitInfo.InfoID);
            comDetailUnit.Text = detailInfo.DetailInfoTitle;
            idInfo = unitInfo.UnitInfoID;
            txtDescU.Text = unitInfo.UnitInfoDesc;
            id = unitInfo.UnitInfoID;
        }
        private void Clear()
        {
            txtUnitCode.Text = string.Empty;
            comUnitType.Text = string.Empty;
            unit.Desc = string.Empty;
            UnitArea.Value = decimal.Parse(string.Empty);
            txtUnitFloor.Text = string.Empty;
            numUnitPersonsNum.Value = decimal.Parse(string.Empty);
            txtDetailNameU.Text = string.Empty;
            comDetailUnit.Text = string.Empty;
            txtDescU.Text = string.Empty;
        }
        private void FillControl(Unit unit)
        {
            txtUnitCode.Text = Convert.ToString(unit.UnitCode);
            comUnitType.Text = unit.Type.ToString();
            UnitArea.Value = Convert.ToDecimal(unit.UnitArea);
            txtUnitFloor.Text = Convert.ToString(unit.UnitFloor);
            numUnitPersonsNum.Value = Convert.ToDecimal(unit.UnitPersonsNum);
            txtDesc.Text = unit.Desc;
            id = unit.ID;
        }
        private void FillControlOwner(Unit_Person unit_person)
        {
            if (unit_person.Relation == "مالک" )
            {
                person = dal.LoadPerson(unit_person.PersonID);
                multiColumnLessee.Text = person.Family;
                multiColumnLessee.Visible = false;
                label10.Visible = false;
                checkLessee.Checked = false;
            }
        }
        private void FillControlLessee(Unit_Person unit_person)
        {
            if (unit_person.Relation == "مستاجر")
            {
                multiColumnLessee.Visible = true;
                label10.Visible = true;
                checkLessee.Checked = true;
                person = dal.LoadPerson(1);
                multiColumnOwner.Text = person.Family;
            }
        }
        private Unit_Person LoadControlsOwner()
        {
            if (unitperson == null)
                unitperson = new Unit_Person();
            person = dal.LoadPersonWithFamily(multiColumnOwner.Text);
            unitperson.PersonID = person.PersonID;
            unitperson.Relation = "مالک";
            unitperson.Desc = "";
            unitperson.UnitID = 1;
            return unitperson;
        }
        private Unit_Person LoadControlsLessee()
            {
            
                if (unitperson1 == null)
                unitperson1 = new Unit_Person();
                person = dal.LoadPersonWithFamily(multiColumnLessee.Text);
                unitperson1.PersonID = person.PersonID;
                unitperson1.Relation = "مستاجر";
                unitperson1.Desc = "";
                unitperson1.UnitID = 1;
                return unitperson1;
        }

        private void gridMakerUnit()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXUnit.Tables[0].Columns)
            {
                if (c.Caption == "Unit Code")
                {
                    c.Caption = "کد واحد";
                }
                if (c.Caption == "Unit Area")
                {
                    c.Caption = "متراژ واحد";
                }
                if (c.Caption == "Unit Floor")
                {
                    c.Caption = "طبقه واحد";
                }

                if (c.Caption == "Unit Rooms")
                {
                    c.Caption = "تعداد اتاق ها";
                }
                if (c.Caption == "Unit Persons Num")
                {
                    c.Caption = "تعداد افراد ساکن";
                }
                if (c.Caption == "Type")
                {
                    c.Caption = "نوع";
                }
                if (c.Caption == "ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Unit Number")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Desc")
                {
                    c.Visible = false;
                }
            }
        }
        private void gridMakerUnitInfo()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXUnitInfo.Tables[0].Columns)
            {
                if (c.Caption == "Unit Info Value")
                {
                    c.Caption = "عنوان";
                }
                if (c.Caption == "Unit Info Desc")
                {
                    c.Caption = "توضیحات";
                    c.Width = 200;
                }
                if (c.Caption == "Unit Info ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Info ID")
                {
                    c.Caption = "نوع";
                }
            }
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            if (unit != null)
            {
                unit = LoadControls();
                dal.EditUnit(unit);
                LoadUC();
            }

        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا واحد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (unit != null)
                {
                    dal.DeleteUnit(unit.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            unit = new Unit();
            unit = LoadControls();
            unitperson = LoadControlsOwner();
            unitperson1 = LoadControlsLessee();

            if (unit.UnitArea != 0 && unit.UnitCode != 0 && unit.UnitFloor != 0)
            {
                if (multiColumnOwner.Text == "")
                    MessageBox.Show("لطفا نام مالک را وارد کنید");
                else
                {
                    bool Test = dal.InsertUnit(unit);
                    if (Test == false)
                        MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Test == true)
                    {
                        bool Test1 = dal.InsertUnit_Person(unitperson);
                        if (Test1 == false)
                            MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (Test1 == true)
                        {
                            if (multiColumnLessee.Visible == true)
                            {
                                dal.InsertUnit_Person(unitperson1);
                            }
                            LoadUC();
                            MessageBox.Show("ثبت شد");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را پر نمائید");
            }
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (unitInfo != null)
               {
                  unitInfo  = LoadControlsU();
                  dal.EditUnitInfo(unitInfo);
                  LoadUC();
               }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا رکورد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (unitInfo != null)
                {
                    dal.DeleteUnitInfo(unitInfo.UnitInfoID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            unitInfo = new UnitInfo();
            unitInfo = LoadControlsU();
            if (unitInfo.InfoID != 0 && unitInfo.UnitInfoValue != "")
            {
                bool Test=dal.InsertUnitInfo(unitInfo);
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

        private void btnClear2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
           
        }

        

        private void UCUnit_Load(object sender, EventArgs e)
        {
            LoadUC();
            LoadU();
        }
        private void multiColumnOwner_KeyUp(object sender, KeyEventArgs e)
        {
            multiColumnOwner.DisplayMember = "Family";
            multiColumnOwner.ValueMember = "PersonID";
        }

        private void multiColumnOwner_DropDown(object sender, EventArgs e)
        {
            person = (Person)multiColumnOwner.SelectedItem;
            if (person != null)
                multiColumnOwner.Text = person.Family;
        }

        private void multiColumnOwner_CursorChanged(object sender, EventArgs e)
        {
            person = (Person)multiColumnOwner.SelectedItem;
            if (person != null)
                multiColumnOwner.Text = person.Family;
        }
        private void multiColumnOwner_ThemedAreasChanged(object sender, EventArgs e)
        {
            person = (Person)multiColumnOwner.SelectedItem;
            if (person != null)
                multiColumnOwner.Text = person.Family;
        }

        private void checkLessee_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLessee.Checked == true)
            {
                label10.Visible = true;
                multiColumnLessee.Visible = true;
            }
            else 
            {
                label10.Visible = false;
                multiColumnLessee.Visible =false;
            }
        }

       
        

        private void tabPage2_Click(object sender, EventArgs e)
        {
             

        }

        private void gridEXUnit_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEXUnit.DataSource != null)
            {
                unit = (Unit)gridEXUnit.BindingContext[gridEXUnit.DataSource].Current;
                FillControl(unit);
                unitperson = dal.LoadUnit_Person(unit.ID);
                FillControlOwner(unitperson);
                unitperson1 = dal.LoadUnit_Person(unit.ID);
                FillControlLessee(unitperson1);

            }
        }

        private void gridEXUnitInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEXUnitInfo.DataSource != null)
            {
                unitInfo = (UnitInfo)gridEXUnitInfo.BindingContext[gridEXUnitInfo.DataSource].Current;
                FillControlU(unitInfo);
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
