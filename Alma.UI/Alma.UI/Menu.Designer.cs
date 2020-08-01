namespace Alma.UI
{
    partial class Menu
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
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMenu
            // 
            this.treeMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMenu.Location = new System.Drawing.Point(579, -2);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.RightToLeftLayout = true;
            this.treeMenu.Size = new System.Drawing.Size(173, 492);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeMenu_MouseDown);
            // 
            // uiTab1
            // 
            this.uiTab1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(-1, -2);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiTab1.Size = new System.Drawing.Size(583, 492);
            this.uiTab1.TabDisplay = Janus.Windows.UI.Tab.TabDisplay.ImageAndTextOnSelected;
            this.uiTab1.TabIndex = 1;
            this.uiTab1.TabStripAlignment = Janus.Windows.UI.Tab.TabStripAlignment.Right;
            this.uiTab1.TextOrientation = Janus.Windows.UI.Tab.TextOrientation.Horizontal;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 487);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.treeMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Tree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeMenu;
        private Janus.Windows.UI.Tab.UITab uiTab1;
    }
}