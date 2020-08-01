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
    public partial class UCcar : UserControl
    {
        DAL.DAL dal = new DAL.DAL();
        Car car = new Car();
        List<Car> carList = new List<Car>();
        List<DetailInfo> carInfoList = new List<DetailInfo>();
        public UCcar()
        {
            InitializeComponent();
            //this.Load += new EventHandler(UCcar_Load);
        }

        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            List<Car> carList = new List<Car>();
            List<Unit> unitList = new List<Unit>();
            carList = dal.LoadCarList();
            gridEXCar.DataSource = carList;
            //gridEX1.RetrieveStructure();
            //gridEX1.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            //gridmaker();

            carInfoList = dal.LoadDetailInfoListWithBaseID(3);
            for (int k = 0; carInfoList.Count > k; k++)
            {
                comColor.Items.Add(carInfoList[k].DetailInfoTitle);
            }
            carInfoList = dal.LoadDetailInfoListWithBaseID(4);
            for (int k = 0; carInfoList.Count > k; k++)
            {
                comCarModel.Items.Add(carInfoList[k].DetailInfoTitle);
            }
            carList = dal.LoadCarList();
            gridEXCar.DataSource = carList;
            gridEXCar.RetrieveStructure();
            gridEXCar.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
            //unitList = dal.LoadUnitList();
            //for (int k = 0; unitList.Count > k; k++)
            //{
            //    comOwner.Items.Add(unitList[k].UnitCode);
            //}
        }

        private void Clear()
        {
            txtCarCode.Text = string.Empty;
            comColor.Text = string.Empty;
            comCarModel.Text = string.Empty;
            //comOwner.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }

        private Car LoadControls()
        {
            if (car == null)
                car = new Car();
            car.Code = txtCarCode.Text;
            car.Color = comColor.Text;
            car.Model = comCarModel.Text;
            //car.Owner = comOwner.Text;
            car.Desc = txtDesc.Text;
            return car;
        }
        private void FillControl(Car car)
        {
            txtCarCode.Text = car.Code;
            comColor.Text = car.Color;
            comCarModel.Text = car.Model;
           // comOwner.Text = car.Owner;
            txtDesc.Text = car.Desc;
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXCar.Tables[0].Columns)
            {
                if (c.Caption == "Code")
                {
                    c.Caption = "شماره پلاک";
                }
                if (c.Caption == "Color")
                {
                    c.Caption = "رنگ";
                }
                if (c.Caption == "Model")
                {
                    c.Caption = "مدل";

                }
                if (c.Caption == "Owner")
                {
                    c.Visible = false;
                }
                if (c.Caption == "Desc")
                {
                    c.Visible = false;
                }
                if (c.Caption == "ID")
                {
                    c.Visible = false;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            car = new Car();
            car = LoadControls();
            if (car.Code != "" && car.Color != "" && car.Model != "")
            {
                bool Test=dal.InsertCar(car);
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
            dlr = MessageBox.Show("آیا ماشین مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (car != null)
                {
                    dal.DeleteCar(car.ID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (car != null)
            {
                car = LoadControls();
                dal.EditCar(car);
                LoadUC();
            }
        }

        private void UCcar_Load(object sender, EventArgs e)
        {
            LoadUC();  
        }

        private void gridEXCar_SelectionChanged(object sender, EventArgs e)
        {
            car = (Car)gridEXCar.BindingContext[gridEXCar.DataSource].Current;
            FillControl(car);
        }
    }
}
