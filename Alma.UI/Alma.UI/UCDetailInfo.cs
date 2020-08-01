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
    public partial class UCDetailInfo : UserControl
    {
        DAL.DAL dal = new Alma.DAL.DAL();
        List<BaseInfo> baseInfoList = new List<BaseInfo>();
        List<DetailInfo> DetailInfoList = new List<DetailInfo>();
        int baseInfoID = 0;
        BaseInfo baseInfo = new BaseInfo();
        DetailInfo detailInfo = new DetailInfo();
        List<DetailInfo> detailInfoList = new List<DetailInfo>();
        int id = 0,i=0;
        public UCDetailInfo()
        {
            InitializeComponent();
        }
        private void LoadUC()
        {
            listBaseInfo.SelectedIndexChanged+=new EventHandler(listBaseInfo_SelectedIndexChanged);
            DAL.DAL dao = new DAL.DAL();
            List<DetailInfo> DetailInfoList = new List<DetailInfo>();
            baseInfoList = dal.LoadBaseInfoList();
            for ( i = 0; baseInfoList.Count > i; i++)
            {
              listBaseInfo.Items.Insert(i, baseInfoList[i].BaseInfoTitle);
            }
        }
        void SetGrid()
        {
            DetailInfo per = new DetailInfo();
            List<DetailInfo> perList = new List<DetailInfo>();
          DataTable dt = dal.LoadDetailInfoForGrid(i);
            for (int x = 0; x < perList.Count; x++)
            {
                DataRow dr = dt.NewRow();
                dr["Detail Info Title"] = perList[x].DetailInfoTitle;
                dr["Base Info ID"] = perList[x].BaseInfoID;
                dr["Detail Info ID"] = perList[x].DetailInfoID;
                dr["Detail Info Desc"] = perList[x].DetailInfoDesc;

                dt.Rows.Add(dr);
            }
            gridDetailInfo.DataSource = DetailInfoList;
            gridDetailInfo.Columns[0].Visible = false;
            gridDetailInfo.Columns[1].Visible = false;
            gridDetailInfo.Columns[2].HeaderText = "عنوان";
            gridDetailInfo.Columns[2].Width = 130;
            gridDetailInfo.Columns[3].HeaderText = "توضیحات";
            gridDetailInfo.Columns[3].Width = 95;
            
        }
        
        private void Clear()
        {
            txtDetailInfoTitle.Text = string.Empty;
            txtDetailInoDesc.Text = string.Empty;
        }

        private DetailInfo LoadControls()
        {
            if (detailInfo == null)
                detailInfo = new DetailInfo();
            detailInfo.DetailInfoTitle = txtDetailInfoTitle.Text;
            detailInfo.DetailInfoDesc = txtDetailInoDesc.Text;
            detailInfo.BaseInfoID =i+1;
            detailInfo.DetailInfoID = id;
            return detailInfo;
        }
        private void FillControl(DetailInfo detailInfo)
        {
            baseInfoID = listBaseInfo.SelectedIndex + 1;
            detailInfo = dal.LoadDetailInfo(baseInfoID);
            txtDetailInfoTitle.Text = detailInfo.DetailInfoTitle;
            txtDetailInoDesc.Text = detailInfo.DetailInfoDesc;
            id = detailInfo.DetailInfoID;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
             if (detailInfo != null)
            {
                detailInfo = LoadControls();
                dal.EditDetailInfo(detailInfo);
                LoadUC();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("آیا رکورد مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (baseInfo != null)
                {
                    dal.DeleteDetailInfo(detailInfo.DetailInfoID);
                    LoadUC();
                    MessageBox.Show("حذف شد");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             DAL.DAL dal=new Alma.DAL.DAL();
            detailInfo = LoadControls();
            if (detailInfo.DetailInfoTitle != "" && detailInfo.BaseInfoID != 0)
            {
                bool Test = dal.InsertDetailInfo(detailInfo);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void UCDetailInfo_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        
        private void listBaseInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            i = listBaseInfo.SelectedIndex;
            baseInfo = dal.LoadBaseInfo(i+1);
            groupBaseTitle.Text = baseInfo.BaseInfoTitle;
            DetailInfoList = dal.LoadDetailInfoListWithBaseID(i+1);
            gridDetailInfo.DataSource = DetailInfoList;
            SetGrid();
            //gridEXDetailInfo.DataSource = DetailInfoList;
            //gridEXDetailInfo.RetrieveStructure();
            //gridEXDetailInfo.BuiltInTexts[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = "برای گروه بندی ستون موردنظر را به این قسمت بکشید";
            //gridMaker();
        }
       
    }
}
