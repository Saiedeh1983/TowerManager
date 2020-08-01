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
    public partial class UCPerson : UserControl
    {
        DAL.DAL dal = new DAL.DAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
       int id = 0;
        public UCPerson()
        {
            InitializeComponent();
        }
        private void FillControl(Person person)
        {
            txtName.Text = person.Name;
            txtFamily.Text = person.Family;
            txtRegisterCardNum.Text = person.RegisterCardNum;
            txtPicture.Text = person.PicturePath;
            txtDateEnter.Text = person.DateEnter;
            txtDateExit.Text = person.DateExit;
            txtFatherName.Text = person.FatherName;
            txtNationalCode.Text = person.NationalCode;
            txtTelephon.Text = person.Telephon;
            txtMobile.Text = person.Mobile;
            id = person.PersonID;
            if (person.Sex == false)
            {
                rdoSexF.Checked = true;
                rdoSexM.Checked = false;
            }
            if (person.Sex == true)
            {
                rdoSexM.Checked = true;
                rdoSexF.Checked = false;
            }
        }
        private void Clear()
        {
            txtName.Text = string.Empty;
            txtFamily.Text = string.Empty;
            txtRegisterCardNum.Text = string.Empty;
            txtPicture.Text = string.Empty;
            rdoSexF.Checked = false;
            rdoSexM.Checked = false;
            txtNationalCode.Text = string.Empty;
            txtDateEnter.Text = string.Empty;
            txtDateExit.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtTelephon.Text = string.Empty;
            txtMobile.Text = string.Empty;
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXPerson.Tables[0].Columns)
            {
                if (c.Caption == "Name")
                {
                    c.Caption = "نام";
                }
                if (c.Caption == "Family")
                {
                    c.Caption = "نام خانوادگی";
                }
                if (c.Caption == "Father Name")
                {
                    c.Caption = "نام پدر";

                }
                if (c.Caption == "Register Card Num")
                {
                    c.Caption = "شماره شناسنامه";
                }
                if (c.Caption == "National Code")
                {
                    c.Caption = "کد ملی";
                }
                if (c.Caption == "Telephon")
                {
                    c.Caption = "تلفن";
                }
                if (c.Caption == "Person ID")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Picture Path")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Mobile")
                {
                    c.Caption = "موبایل";
                }
                if (c.Caption == "Date Enter")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Sex")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Date Exit")
                {
                    c.Visible = false;
                }
            }
        }
        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            personList = dal.LoadPersonList();
            gridEXPerson.DataSource = personList;
            gridEXPerson.RetrieveStructure();
            gridEXPerson.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
            
        }

        private Person LoadControls()
        {
            if (person == null)
                person = new Person();
            person.Name = txtName.Text;
            person.Family = txtFamily.Text;
            person.FatherName = txtFatherName.Text;
            person.DateEnter = txtDateEnter.Text;
            person.DateExit = txtDateExit.Text;
            person.RegisterCardNum = txtRegisterCardNum.Text;
            person.NationalCode = txtNationalCode.Text;
            person.PicturePath = txtPicture.Text;
            person.Mobile = txtMobile.Text;
            person.Telephon = txtTelephon.Text;
            person.PersonID = id;
            if (rdoSexF.Checked == true)
            {
                person.Sex = false;
            }
            if (rdoSexM.Checked == true)
            {
                person.Sex = true;
            }
            return person;
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = "Pictures";
            filedialog.RestoreDirectory = true;
            filedialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                txtPicture.Text = filedialog.FileName;
                PictureBox.ImageLocation = filedialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
       
        private void grdPersons_SelectionChanged(object sender, EventArgs e)
        {
            //person = (Person)grdPersons.BindingContext[grdPersons.DataSource].Current;
            //FillControl(person);
        }
        
        private void UCPerson_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void grpPersons_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا شخص مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (person != null)
                {
                    dal.DeletePerson(person.PersonID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person = LoadControls();
                dal.EditPerson(person);
                LoadUC();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            person = new Person();
            person = LoadControls();
            if (person.Name != "" && person.Family != "" && person.NationalCode != "")
            {
                bool Test=dal.InsertPerson(person);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gridEXPerson_SelectionChanged(object sender, EventArgs e)
        {
            person = (Person)gridEXPerson.BindingContext[gridEXPerson.DataSource].Current;
            FillControl(person);
        }
    }
}
