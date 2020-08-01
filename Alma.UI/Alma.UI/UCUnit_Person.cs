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
    public partial class UCUnit_Person : UserControl
    {
        DAL.DAL dal = new Alma.DAL.DAL();
        Unit_Person unit_person = new Unit_Person();
        List<Unit_Person> unit_personList = new List<Unit_Person>();
        DetailInfo detailInfo = new DetailInfo();
        List<DetailInfo> detailInfoList = new List<DetailInfo>();
        List<Person> personList = new List<Person>();
        Person person = new Person();
        public UCUnit_Person()
        {
            InitializeComponent();
        }
        private void FillControl(Unit_Person unit_person)
        {
           // txtOwner.Text =unit_person.PersonID;
            txtDesc.Text = unit_person.Desc;
            comRelation.Text = unit_person.Relation;
            person = dal.LoadPerson(unit_person.PersonID);
            multiColumnFamily.Text = person.Family;
            //نام سرپرست
            //unit_person = dal.LoadUnit_Person(17);
            Person person1 = new Person();
            person1 = dal.LoadPerson(unit_person.PersonID);
            lblProtector.Text = person1.Family;
        }
        private void Clear()
        {
            txtDesc.Text = string.Empty;
            comRelation.Text = string.Empty;
            multiColumnFamily.Text = string.Empty;
            //txtOwner.Text = string.Empty;
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXUnitPerson.Tables[0].Columns)
            {
                if (c.Caption == "Person ID")
                {
                    c.Caption = "کد شخص";
                }
                if (c.Caption == "Relation")
                {
                    c.Caption = "نسبت";
                }
                if (c.Caption == "Unit ID")
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
        private void LoadU()
    {
           //نام شخص
            multiColumnFamily.Clear();
            multiColumnFamily.DataSource = personList;
            multiColumnFamily.DisplayMember = "Family";
            multiColumnFamily.ValueMember = "PersonID";
            //multiColumnFamily.DataMember = personList;
            Janus.Windows.GridEX.GridEXColumn col = new Janus.Windows.GridEX.GridEXColumn();
            col.Caption = "نام";
            col.DataMember = "Name";
            multiColumnFamily.DropDownList.Columns.Add(col);
            Janus.Windows.GridEX.GridEXColumn col1 = new Janus.Windows.GridEX.GridEXColumn();
            col1.Caption = "نام خانوادگی";
            col1.DataMember = "Family";
            multiColumnFamily.DropDownList.Columns.Add(col1);
            Janus.Windows.GridEX.GridEXColumn col2 = new Janus.Windows.GridEX.GridEXColumn();
            col2.Caption = "شماره شناسنامه";
            col2.Width = 120;
            col2.DataMember = "RegisterCardNum";
            multiColumnFamily.DropDownList.Columns.Add(col2);

    }
        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            personList = dal.LoadPersonWithUnitID(1);
            detailInfoList = dal.LoadDetailInfoListWithBaseID(7);
            comRelation.Items.Clear();
            for (int k = 0; detailInfoList.Count > k; k++)
            {
                comRelation.Items.Add(detailInfoList[k].DetailInfoTitle);
            }
           
            //نمایش لیست
            unit_personList = dal.LoadUnit_PersonList();
            //string sqlstr = "select * from Unit_Person,Person where Unit_Person.IsDel=0 and  Person.PersonID=Unit_Person.PersonID";
            gridEXUnitPerson.DataSource = unit_personList;
            gridEXUnitPerson.RetrieveStructure();
            gridEXUnitPerson.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
            //نام سرپرست
            unit_person=dal.LoadUnit_Person(17);
            Person person=new Person();
            person = dal.LoadPerson(unit_person.PersonID);
            lblProtector.Text=person.Family;
        }

        private Unit_Person LoadControls()
        {
            if (unit_person == null)
                unit_person = new Unit_Person();
                unit_person.UnitID=1;
                person=dal.LoadPersonWithFamily(multiColumnFamily.Text);
                unit_person.PersonID = person.PersonID;
                unit_person.Relation = comRelation.Text;
                unit_person.Desc = txtDesc.Text;
                return unit_person;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا شخص مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (unit_person != null)
                {
                    dal.DeleteUnit_Person(unit_person.UnitID, unit_person.PersonID);
                    LoadUC();
                    //MessageBox.Show(("حذف شد");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DAL.DAL dal = new Alma.DAL.DAL();
            unit_person = LoadControls();
            if (comRelation.Text != "" && multiColumnFamily.Text != "")
            {
                bool Test=dal.InsertUnit_Person(unit_person);
                if (Test == false)
                        MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Test == true)
                    {
                        //LoadUC();
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
            if (unit_person != null)
            {
                unit_person = LoadControls();
                dal.EditUnit_Person(unit_person);
                LoadUC();
            }
        }

        private void UCUnit_Person_Load(object sender, EventArgs e)
        {
            LoadUC();
            LoadU();
        }

        private void gridEXUnitPerson_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEXUnitPerson.DataSource != null)
            {
                unit_person = (Unit_Person)gridEXUnitPerson.BindingContext[gridEXUnitPerson.DataSource].Current;
                FillControl(unit_person);
            }
        }
    }
}
