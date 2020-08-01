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
    public partial class UCServices : UserControl
    {
        string S;
        DAL.DAL dal = new DAL.DAL();
        List<DetailInfo> detailInfoList = new List<DetailInfo>();
        public UCServices()
        {
            InitializeComponent();
        }
        private void LoadUC()
        {
            DAL.DAL dal = new DAL.DAL();

            detailInfoList = dal.LoadDetailInfoListWithBaseID(5);
            for (int k = 0; detailInfoList.Count > k; k++)
            {
                listBox1.Items.Add(detailInfoList[k].DetailInfoTitle);
            }
            detailInfoList = dal.LoadDetailInfoListWithBaseID(6);
            for (int k = 0; detailInfoList.Count > k; k++)
            {
                listBox3.Items.Add(detailInfoList[k].DetailInfoTitle);
            }
        }
        private void UCServices_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void Add1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                S = listBox1.SelectedItem.ToString();
                listBox2.Items.Add(S);
            }
            else
                MessageBox.Show("لطفا از امکانات پیش فرض انتخاب کنید");
        }

        private void RemoveAll1_Click(object sender, EventArgs e)
        {

        }

        private void Remove1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                S = listBox2.SelectedItem.ToString();
                listBox1.Items.Add(S);
                listBox2.Items.Remove(S);
            }
            else
                MessageBox.Show("لطفا از امکانات ساختمان انتخاب کنید");
        }

        private void AddAll1_Click(object sender, EventArgs e)
        {
            int co = 0;
            for (co = listBox1.Items.Count; co > 0; co--)
            {
                S = listBox1.Items[co - 1].ToString();
                listBox2.Items.Add(S);
                listBox1.Items.Remove(S);
            }
        }
    }
}
