namespace Alma.UI
{
    partial class Tree
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeMenu
            // 
            this.treeMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMenu.Location = new System.Drawing.Point(581, -3);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.RightToLeftLayout = true;
            this.treeMenu.Size = new System.Drawing.Size(199, 492);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMenu_AfterSelect);
            this.treeMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeMenu_MouseDown);
            // 
            // uiTab1
            // 
            this.uiTab1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(1, -3);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiTab1.Size = new System.Drawing.Size(583, 492);
            this.uiTab1.TabDisplay = Janus.Windows.UI.Tab.TabDisplay.ImageAndTextOnSelected;
            this.uiTab1.TabIndex = 1;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TextOrientation = Janus.Windows.UI.Tab.TextOrientation.Horizontal;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Location = new System.Drawing.Point(1, 22);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(579, 467);
            this.uiTabPage1.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 28);
            this.panel1.TabIndex = 2;
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.treeMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Tree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeMenu;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
    }
}