namespace Alma.UI
{
    partial class UCTower
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTower));
            this.txtTowerTitle = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOtherInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.TowerArea = new System.Windows.Forms.NumericUpDown();
            this.ParkingCount = new System.Windows.Forms.NumericUpDown();
            this.FloorCount = new System.Windows.Forms.NumericUpDown();
            this.UnitCount = new System.Windows.Forms.NumericUpDown();
            this.txtTowerNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.TowerArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParkingCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FloorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTowerTitle
            // 
            this.txtTowerTitle.Location = new System.Drawing.Point(366, 26);
            this.txtTowerTitle.Name = "txtTowerTitle";
            this.txtTowerTitle.Size = new System.Drawing.Size(124, 21);
            this.txtTowerTitle.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 22);
            this.btnOK.Text = "  ثبت  ";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.Text = "حذف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOtherInfo});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // btnOtherInfo
            // 
            this.btnOtherInfo.Name = "btnOtherInfo";
            this.btnOtherInfo.Size = new System.Drawing.Size(145, 22);
            this.btnOtherInfo.Text = "سایر مشخصات";
            // 
            // btnClear
            // 
            this.btnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClear.Size = new System.Drawing.Size(49, 22);
            this.btnClear.Text = "جدید";
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(60, 22);
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // TowerArea
            // 
            this.TowerArea.Location = new System.Drawing.Point(15, 51);
            this.TowerArea.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TowerArea.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TowerArea.Name = "TowerArea";
            this.TowerArea.Size = new System.Drawing.Size(100, 21);
            this.TowerArea.TabIndex = 5;
            this.TowerArea.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ParkingCount
            // 
            this.ParkingCount.Location = new System.Drawing.Point(15, 25);
            this.ParkingCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ParkingCount.Name = "ParkingCount";
            this.ParkingCount.Size = new System.Drawing.Size(100, 21);
            this.ParkingCount.TabIndex = 4;
            // 
            // FloorCount
            // 
            this.FloorCount.Location = new System.Drawing.Point(194, 51);
            this.FloorCount.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.FloorCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FloorCount.Name = "FloorCount";
            this.FloorCount.Size = new System.Drawing.Size(100, 21);
            this.FloorCount.TabIndex = 2;
            this.FloorCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UnitCount
            // 
            this.UnitCount.Location = new System.Drawing.Point(194, 25);
            this.UnitCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UnitCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UnitCount.Name = "UnitCount";
            this.UnitCount.Size = new System.Drawing.Size(100, 21);
            this.UnitCount.TabIndex = 3;
            this.UnitCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTowerNumber
            // 
            this.txtTowerNumber.Location = new System.Drawing.Point(368, 53);
            this.txtTowerNumber.Name = "txtTowerNumber";
            this.txtTowerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTowerNumber.Size = new System.Drawing.Size(122, 21);
            this.txtTowerNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "شماره پلاک";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TowerArea);
            this.groupBox1.Controls.Add(this.txtTowerTitle);
            this.groupBox1.Controls.Add(this.ParkingCount);
            this.groupBox1.Controls.Add(this.FloorCount);
            this.groupBox1.Controls.Add(this.UnitCount);
            this.groupBox1.Controls.Add(this.txtTowerNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(566, 95);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات برج";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "مساحت برج";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "تعداد پارکینگ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "تعداد واحد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "تعداد طبقات";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام برج";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.btnCancel,
            this.toolStripDropDownButton1,
            this.btnEdit,
            this.btnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 392);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(619, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UCTower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCTower";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(619, 417);
            this.Load += new System.EventHandler(this.UCTower_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TowerArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParkingCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FloorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTowerTitle;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnOtherInfo;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.NumericUpDown TowerArea;
        private System.Windows.Forms.NumericUpDown ParkingCount;
        private System.Windows.Forms.NumericUpDown FloorCount;
        private System.Windows.Forms.NumericUpDown UnitCount;
        private System.Windows.Forms.TextBox txtTowerNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}
