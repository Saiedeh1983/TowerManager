using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Alma.Common;
using Alma.DAL;
using System.Globalization;

namespace Alma.UI
{
    public partial class Tree : Form
    {
        
        Tower tower = new Tower();
        Unit unit = new Unit();
        Floor floor = new Floor();
        DAL.DAL dal = new DAL.DAL();
        int count1 = 0;
        int count2 = 0;
        int floornum = 0;
        int countUnit = 0;
        int NumberFloor = 0;
        int NumberUnit = 0;
        string floorarea;
        //List<int>  countarray=new List<int>() ;
        int[] countarray = new int[30];
        public Tree()
        {
            InitializeComponent();
        }

        private void LoadUC()
        {
            tower = dal.LoadTower(1);

            treeMenu.Nodes.Insert(0, "برج " + tower.TowerTitle, " برج " + tower.TowerTitle);
            treeMenu.Nodes.Insert(1, " اطلاعات کنترلی " , " اطلاعات کنترلی ");
            treeMenu.Nodes[0].Nodes.Insert(0, "طبقات", " طبقات ");
            treeMenu.Nodes[0].Nodes.Insert(1, "مستقلات", " مستقلات ");
            treeMenu.Nodes[0].Nodes.Insert(2, "افراد", " افراد ");
            treeMenu.Nodes[0].Nodes.Insert(3, " کنتورها ", " کنتورها ");
            treeMenu.Nodes[0].Nodes.Insert(4, "حسابداری", " حسابداری ");
            treeMenu.Nodes[0].Nodes[4].Nodes.Insert(0," قبض ها ");
            treeMenu.Nodes[0].Nodes[4].Nodes.Insert(1, " شارژها ");
            treeMenu.Nodes[0].Nodes[4].Nodes[1].Nodes.Insert(0, " امکانات ");
            treeMenu.Nodes[0].Nodes[4].Nodes[1].Nodes.Insert(1, " کنتورها ");
            treeMenu.Nodes[0].Nodes[4].Nodes[1].Nodes.Insert(2, " پیش بینی نشده ", " پیش بینی نشده ");
            treeMenu.Nodes[1].Nodes.Insert(0, " تعیین مشخصات ", " تعیین مشخصات ");
            treeMenu.Nodes[1].Nodes.Insert(1, " تغییر پسورد ", " تغییر پسورد ");
            tower = dal.LoadTower(1);
            count1 = tower.FloorCount;
            for (int j = 1; j <= count1; j++)
            {
                floor = dal.LoadFloor(j);
                countarray[j] = floor.UnitCount;
                floornum = floor.FloorNum;
                floorarea = floor.Area;
                if(floorarea=="روی زمین")
                treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum, " طبقه " + floornum);
            else if (floorarea == "زیر زمین")
                treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum + "-", " طبقه " + floornum + "-");
                
                for (int i = 1; i <= countarray[j]; i++)
                {
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i);
                    
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(3, "ساکنین ");
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(4, "ماشین ها");
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(5, "کنتورها");
                }
            }
        }
        private void Tree_Load(object sender, EventArgs e)
        {
            LoadUC();
        }


        public static string GetDate()
        {
            int year;
            int month;
            int day;
            string date = "";
            PersianCalendar p = new PersianCalendar();
            year = p.GetYear(DateTime.Now);
            day = p.GetDayOfMonth(DateTime.Now);
            month = p.GetMonth(DateTime.Now);
            if (month <= 9)
            {
                date = year.ToString() + "/0" + month.ToString() + "/" + day.ToString();
            }
            if (day <= 9)
            {
                date = year.ToString() + "/" + month.ToString() + "/0" + day.ToString();
            }
            if (month <= 9 && day <= 9)
            {
                date = year.ToString() + "/0" + month.ToString() + "/0" + day.ToString();
            }
            if (month > 9 && day > 9)
            {
                date = year.ToString() + "/" + month.ToString() + "/" + day.ToString();
            }
            return date;
        }


        private void toolStripButton20_Click(object sender, EventArgs e)
        {

        }

        private void treeMenu_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode clickedNode = treeMenu.GetNodeAt(e.X, e.Y);
            ImageList myImageList = new ImageList();
           // myImageList.Images.Add(Image.FromFile("save.ico"));
            //myImageList.Images.Add("buddy.gif");

            // Assign the ImageList to the TreeView.
            treeMenu.ImageList = myImageList;

            treeMenu.SelectedNode = clickedNode;
            tower = dal.LoadTower(1);
            if (count1 != tower.FloorCount)
            {
                //treeMenu.Nodes[0].Nodes[0].Nodes.Remove();
                count1 = tower.FloorCount;
                treeMenu.Nodes[0].Nodes[0].BeginEdit();
                int countFloor = treeMenu.Nodes[0].Nodes[0].Nodes.Count;
                for (int w = 1; w <= countFloor; w++)
                {
                    treeMenu.Nodes[0].Nodes[0].Nodes.Remove(treeMenu.Nodes[0].Nodes[0].Nodes[0]);
                }
                for (int j = 1; j <= count1; j++)
                {
                    treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j, " طبقه " + j, " طبقه " + j,1);
                    NumberFloor = j;
                    floor = dal.LoadFloor(j);
                    countarray[j] = floor.UnitCount;
                    for (int i = 1; i <= countarray[j]; i++)
                    {
                        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i,0);
                        NumberUnit = i;
                        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(3, "ساکنین ");
                        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(4, "ماشین ها");
                    }
                }
            }
            else
            {
                for (int j = 1; j <= count1; j++)
                {
                    //treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه " + j, " طبقه " + j);

                    floor = dal.LoadFloor(j);
                    if (countarray[j] != floor.UnitCount)
                    {
                        countarray[j] = floor.UnitCount;
                        treeMenu.LabelEdit = true;
                        treeMenu.Nodes[0].Nodes[0].BeginEdit();
                        if (treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Count != 0)
                            countUnit = treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Count;
                        for (int w = 1; w <= countUnit; w++)
                        {
                            treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Remove(treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[0]);
                        }
                        for (int i = 1; i <= countarray[j]; i++)
                        {
                            treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i);
                            treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(3, "ساکنین ");
                            treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(4, "ماشین ها");
                        }
                    }
                }
            }

            if (clickedNode != null)
            {
                if (clickedNode.Level == 0)
                {
                    if (clickedNode.Text == " اطلاعات کنترلی ")
                    {
                        
                    }
                    else
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCTower uc = new UCTower();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                }
                if (clickedNode.Level == 1)
                {
                    if (clickedNode.Text == " مستقلات ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCIndependent uc = new UCIndependent();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    else if (clickedNode.Text == " افراد ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCPerson uc = new UCPerson();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    else if (clickedNode.Text == " تعیین مشخصات ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCDetailInfo uc = new UCDetailInfo();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    else if (clickedNode.Text == " تغییر پسورد ")
                    {
                        
                    }
                    else if (clickedNode.Text == " کنتورها ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        ucContor uc = new ucContor();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    else if (clickedNode.Text == " حسابداری ")
                    {
                        
                    }
                    else
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCFloor uc = new UCFloor();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                }
                if (clickedNode.Level == 2)
                {
                    if (clickedNode.Text == " قبض ها ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        ucFiche uc = new ucFiche();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    else if (clickedNode.Text == " شارژها ")
                    {
                       
                    }
                    else
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCUnit uc = new UCUnit();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                      
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        //uc["txtUnitFloor"].text = NumberFloor.ToString();
                        //this.uiTab1.Controls[uiTab1.TabPages.Count - 1].Controls["txtUnitCode"].Text = NumberUnit.ToString();
                        //this.uiTab1.Controls['uc'].Controls['txtUnitFloor'].Text = NumberFloor.ToString();
                        this.Text = clickedNode.FullPath;
                    }
                }
                if (clickedNode.Level == 3)
                {
                    if (clickedNode.Text == " کنتورها ")
                    {
                    Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                    ucUnitContor uc = new ucUnitContor();
                    uc.Dock = DockStyle.Fill;
                    t.Controls.Add(uc);
                    t.Text = clickedNode.Text;
                       // clickedNode
                    uiTab1.TabPages.Add(t);
                    uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                    this.Text = clickedNode.FullPath;
                    }
                    if (clickedNode.Text == " امکانات ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        ucIndependentSharj uc = new ucIndependentSharj();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    if (clickedNode.Text == " پیش بینی نشده ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        ucUnforeseen uc = new ucUnforeseen();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                }

                if (clickedNode.Level == 4)
                {
                    if (clickedNode.Text == "ماشین ها")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCcar uc = new UCcar();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    if (clickedNode.Text == "کنتورها")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        ucContor uc = new ucContor();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                    }
                    if (clickedNode.Text == "ساکنین ")
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCUnit_Person uc = new UCUnit_Person();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                        this.Text = clickedNode.FullPath;
                       
                    }
                }
            }
            treeMenu.LabelEdit = false;
        }
        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        }
        
    }
