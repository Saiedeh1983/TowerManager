using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Alma.DAL;
using Alma.Common;

namespace Alma.UI
{
    public partial class frmTree : Form
    {

        public frmTree()
        {
            InitializeComponent();
        }

        private void frmTree_Load(object sender, EventArgs e)
        {
            //tower = dal.LoadTower(1);

            //treeMenu.Nodes.Insert(0, "برج " + tower.TowerTitle, " برج " + tower.TowerTitle);
            //treeMenu.Nodes[0].Nodes.Insert(0, "طبقات", " طبقات ");
            //treeMenu.Nodes[0].Nodes.Insert(1, "مستقلات", " مستقلات ");
            //treeMenu.Nodes[0].Nodes.Insert(2, "افراد", " افراد ");
            //treeMenu.Nodes[0].Nodes.Insert(3, "حسابداری", " حسابداری ");
            //treeMenu.Nodes[0].Nodes[3].Nodes.Insert(0, " قبض ها ");
            //treeMenu.Nodes[0].Nodes[3].Nodes.Insert(1, " شارژها ");
            //treeMenu.Nodes[0].Nodes[3].Nodes[1].Nodes.Insert(0, " امکانات ");
            //treeMenu.Nodes[0].Nodes[3].Nodes[1].Nodes.Insert(1, " کنتورها ");
            //treeMenu.Nodes[0].Nodes[3].Nodes[1].Nodes.Insert(2, " پیش بینی نشده ", " پیش بینی نشده ");
            //tower = dal.LoadTower(1);
            //count1 = tower.FloorCount;
            //for (int j = 1; j <= count1; j++)
            //{
            //    floor = dal.LoadFloor(j);
            //    countarray[j] = floor.UnitCount;
            //    floornum = floor.FloorNum;
            //    floorarea = floor.Area;
            //    if (floorarea == "روی زمین")
            //        treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum, " طبقه " + floornum);
            //    else if (floorarea == "زیر زمین")
            //        treeMenu.Nodes[0].Nodes[0].Nodes.Insert(j - 1, " طبقه " + floornum + "-", " طبقه " + floornum + "-");

            //    for (int i = 1; i <= countarray[j]; i++)
            //    {
            //        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes.Insert(i - 1, " واحد " + i, " واحد " + i);


            //        treeMenu.Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(1, "اطلاعات اصلی");
            //        treeMenu.Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(2, "اطلاعات تکمیلی");
            //        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(3, "ساکنین ");
            //        treeMenu.Nodes[0].Nodes[0].Nodes[j - 1].Nodes[i - 1].Nodes.Insert(4, "ماشین ها");
            //    }
            //}
        }
    }
}