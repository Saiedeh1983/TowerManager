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
    public partial class ucUnitContor : UserControl
    {
        Unit_Contor unit_contor = new Unit_Contor();
        List<Unit_Contor> unit_contorList = new List<Unit_Contor>();
        Tower tower = new Tower();
        Unit unit = new Unit();
        Contor contor = new Contor();
        Floor floor = new Floor();
        DAL.DAL dal = new DAL.DAL();
        int count1 = 0;
        int H = 0;
        int floornum = 0;
        //int countUnit = 0;
        string floorarea;
        //List<int>  countarray=new List<int>() ;
        int[] countarray = new int[30];
        int[] unitsNum=new int[30];
        public ucUnitContor()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (unit_contor != null)
            //{
            //    unit_contor = LoadControls();
            //    //dal.EditUnit_Contor(unit_contor);
            //    LoadUC();
            //}
        }

        private void ucUnitContor_Load(object sender, EventArgs e)
        {
            btnConfirm.Click+=new EventHandler(btnConfirm_Click);
            btnCancel.Click+=new EventHandler(btnCancel_Click);
            btnClear.Click+=new EventHandler(btnClear_Click);
            btnEdit.Click+=new EventHandler(btnEdit_Click);
            btnOK.Click+=new EventHandler(btnOK_Click);
            btnUnts.Click+=new EventHandler(btnUnts_Click);
            LoadPanel();
            LoadUC();
        }
        private void LoadPanel()
        {
            
            tower = dal.LoadTower(1);

            treeMenu.Nodes.Insert(0, "برج " + tower.TowerTitle, " برج " + tower.TowerTitle);
            //treeMenu.Nodes[0].Nodes.Insert(0, "طبقات", " طبقات ");
            tower = dal.LoadTower(1);
            count1 = tower.FloorCount;
            for (int j = 1; j <= count1; j++)
            {
                floor = dal.LoadFloor(j);
                countarray[j] = floor.UnitCount;
                floornum = floor.FloorNum;
                floorarea = floor.Area;
                if (floorarea == "روی زمین")
                    treeMenu.Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum, " طبقه " + floornum);
                else if (floorarea == "زیر زمین")
                    treeMenu.Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum + "-", " طبقه " + floornum + "-");

                for (int i = 1; i <= countarray[j]; i++)
                {
                    treeMenu.Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i);
                }
            }
        }
        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();
            unit_contorList = dal.LoadUnit_ContorList();
            gridEXContorUnit.DataSource = unit_contorList;
            gridEXContorUnit.RetrieveStructure();
            gridEXContorUnit.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            gridMaker();
        }
        private void gridMaker()
        {
            foreach (Janus.Windows.GridEX.GridEXColumn c in gridEXContorUnit.Tables[0].Columns)
            {
                if (c.Caption == "Unit ID")
                {
                    c.Caption = "واحد";
                }
                if (c.Caption == "Contor ID")
                {
                    c.Caption = "کنتور";
                }
                if (c.Caption == "Desc")
                {
                    c.Caption = "توضیحات";
                    c.Width = 200;
                }
            }
        }
        //private Unit_Contor LoadControls(int UnitID)
        //{
        //    if (unit_contor == null)
        //        unit_contor = new Unit_Contor();

        //    unit_contor.UnitID = multiTypeContor.Text;
        //    //unit_contor.ContorID = int.Parse(txtSharj.Text);
        //    unit_contor.Desc = txtDesc.Text;
        //    return unit_contor;
        //}
        private Unit_Contor LoadUnit_Contor(int UnitID)
        {
            if (unit_contor == null)
                unit_contor = new Unit_Contor();
            unit_contor.UnitID = UnitID;
            int y = 0;
             y=Convert.ToInt32(ContorNum.Value.ToString());
            contor = dal.LoadContorListWithContorNum(y);
            unit_contor.ContorID =contor.ContorID ;
            unit_contor.Desc = txtDesc.Text;
            return unit_contor;
        }
        private void FillControl(Unit_Contor unit_contor)
        {
            //multiTypeContor.Text = unit_contor.UnitID;
            //txtSharj.Text = unit_contor.ContorID.ToString();
            txtDesc.Text = unit_contor.Desc.ToString();
        }
        private void Clear()
        {
            txtDesc.Text = string.Empty;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا رکورد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (unit != null)
                {
                    dal.DeleteUnit_Contor(unit_contor.UnitID, unit_contor.ContorID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            unit_contor = new Unit_Contor();
            for (int i = 0; i <= listBox1.Items.Count-1; i++)
            {
                H=Convert.ToInt32(listBox1.Items[i].ToString());
                unit_contor = LoadUnit_Contor(H);
                if (unit_contor.ContorID != 0 && unit_contor.UnitID != 0)
                {
                    bool Test = dal.InsertUnit_Contor(LoadUnit_Contor(H));
                    if (Test == false)
                        MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Test == true)
                    {
                        LoadUC();
                        MessageBox.Show("کنتور موردنظر ثبت شد ");
                    }
                }
                else

                    MessageBox.Show("لطفاً تمامی فیلدها را پر نمائید");
            } 
        }

        private void btnUnts_Click(object sender, EventArgs e)
        {
            pnlUnits.Visible = true;
            treeMenu.Visible = true;
            btnConfirm.Visible = true;
            btnUnts.Enabled = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pnlUnits.Visible = false;
            btnConfirm.Visible = false;
            btnUnts.Enabled = true;
            tower = dal.LoadTower(1);
            count1 = tower.FloorCount;
            if (treeMenu.Nodes[0].Checked == true)
            {
               
                for (int j = 1; j <= count1; j++)
                {
                    floor = dal.LoadFloor(j);
                    countarray[j] = floor.UnitCount;
                    floornum = floor.FloorNum;
                    floorarea = floor.Area;
                    for (int i = 1; i <= countarray[j]; i++)
                    {
                        unit = dal.LoadUnitWithUnitCodeandUnitFloor(i, j);
                        listBox1.Items.Add(unit.ID);
                        //dal.InsertUnit_Contor(LoadUnit_Contor(unit.ID));
                    }
                }
            }
            else 
            {
                for (int j = 1; j <= count1; j++)
                {
                    if (treeMenu.Nodes[0].Nodes[j - 1].Checked == true)
                    {
                        floor = dal.LoadFloor(j);
                        countarray[j] = floor.UnitCount;
                        floornum = floor.FloorNum;
                        floorarea = floor.Area;
                        for (int i = 1; i <= countarray[j]; i++)
                        {
                            unit = dal.LoadUnitWithUnitCodeandUnitFloor(i, j);
                            listBox1.Items.Add(unit.ID);
                        }
                    }
                    else
                    {
                        floor = dal.LoadFloor(j);
                        countarray[j] = floor.UnitCount;
                        floornum = floor.FloorNum;
                        floorarea = floor.Area;
                        for (int i = 1; i <= countarray[j]; i++)
                        {
                            if (treeMenu.Nodes[0].Nodes[j - 1].Nodes[i - 1].Checked == true)
                            {
                                unit = dal.LoadUnitWithUnitCodeandUnitFloor(i, j);
                                listBox1.Items.Add(unit.ID);
                            }
                        }
                    }
                }
            }
        }
        private void gridEXContorUnit_SelectionChanged(object sender, EventArgs e)
        {
            unit_contor = (Unit_Contor)gridEXContorUnit.BindingContext[gridEXContorUnit.DataSource].Current;
            FillControl(unit_contor);
        }
    }
}
