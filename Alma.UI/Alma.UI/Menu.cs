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
    public partial class Menu : Form
    {
        Tower tower = new Tower();
        Unit unit = new Unit();
        Floor floor = new Floor();
        DAL.DAL dal = new DAL.DAL();
        Menu M = new Menu();
        public Menu()
        {
            InitializeComponent();
        }
        private void LoadUC()
        {
            treeMenu.Nodes.Insert(0, "مشخات ساختمان");

            treeMenu.Nodes[0].Nodes.Insert(0, "برج 1", "برج 1");
            treeMenu.Nodes[0].Nodes.Insert(1, "مستقلات", "مستقلات");
            treeMenu.Nodes[0].Nodes.Insert(2, "افراد", "افراد");
            tower = dal.LoadTower(1);
            int count1 = tower.FloorCount;
            for (int j = 1; j <= count1; j++)
            {
                treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه" + j, " طبقه " + j);

                floor = dal.LoadFloor(j);
                int count2 = floor.UnitCount;
                for (int i = 1; i <= count2; i++)
                {
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i);


                    //treeMenu.Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(1, "اطلاعات اصلی");
                    //treeMenu.Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(2, "اطلاعات تکمیلی");
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(3, "ساکنین");
                    treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(4, "ماشین ها");
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
                treeMenu.SelectedNode = clickedNode;
                if (clickedNode.Level== 1)
                {
                     if (clickedNode.Text == "مستقلات")
                     {
                    Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                    UCIndependent uc = new UCIndependent();
                    uc.Dock = DockStyle.Fill;
                    t.Controls.Add(uc);
                    t.Text = clickedNode.Text;
                    uiTab1.TabPages.Add(t);
                    uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                   //M.Text=t
                     }
                     else if (clickedNode.Text == "افراد")
                     {
                         Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                         UCPerson uc = new UCPerson();
                         uc.Dock = DockStyle.Fill;
                         t.Controls.Add(uc);
                         t.Text = clickedNode.Text;
                         uiTab1.TabPages.Add(t);
                         uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
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
                     }
                }
                    if (clickedNode.Level == 2)
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCFloor uc = new UCFloor();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
                    }
                    if (clickedNode.Level == 3)
                    {
                        Janus.Windows.UI.Tab.UITabPage t = new Janus.Windows.UI.Tab.UITabPage();
                        UCUnit uc = new UCUnit();
                        uc.Dock = DockStyle.Fill;
                        t.Controls.Add(uc);
                        t.Text = clickedNode.Text;
                        uiTab1.TabPages.Add(t);
                        uiTab1.TabPages[uiTab1.TabPages.Count - 1].Selected = true;
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
                        }
                    }
                }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {

        }
        }
        
    }
