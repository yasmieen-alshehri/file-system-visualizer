namespace FolderVisualizer
{
    partial class MainForm
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
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            btnBrowse = new Button();
            treeView1 = new TreeView();
            mainRightContainer = new Panel();
            LeftPanel = new Panel();
            btnTree = new Button();
            btnBar = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            mainRightContainer.SuspendLayout();
            LeftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(mainRightContainer);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1541, 918);
            splitContainer1.SplitterDistance = 513;
            splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(btnBrowse);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 786);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 132);
            panel1.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = SystemColors.GradientInactiveCaption;
            btnBrowse.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(118, 37);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(259, 66);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(513, 918);
            treeView1.TabIndex = 0;
            // 
            // mainRightContainer
            // 
            mainRightContainer.BackColor = Color.White;
            mainRightContainer.BorderStyle = BorderStyle.FixedSingle;
            mainRightContainer.Controls.Add(LeftPanel);
            mainRightContainer.Dock = DockStyle.Fill;
            mainRightContainer.Location = new Point(0, 0);
            mainRightContainer.Name = "mainRightContainer";
            mainRightContainer.Size = new Size(1024, 918);
            mainRightContainer.TabIndex = 2;
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = Color.LightGray;
            LeftPanel.Controls.Add(btnTree);
            LeftPanel.Controls.Add(btnBar);
            LeftPanel.Dock = DockStyle.Top;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(1022, 140);
            LeftPanel.TabIndex = 0;
            // 
            // btnTree
            // 
            btnTree.BackColor = SystemColors.GradientActiveCaption;
            btnTree.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTree.Location = new Point(56, 31);
            btnTree.Name = "btnTree";
            btnTree.Size = new Size(259, 66);
            btnTree.TabIndex = 1;
            btnTree.Text = "Tree";
            btnTree.UseVisualStyleBackColor = false;
            btnTree.Click += btnTree_Click;
            // 
            // btnBar
            // 
            btnBar.BackColor = SystemColors.GradientActiveCaption;
            btnBar.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBar.Location = new Point(357, 31);
            btnBar.Name = "btnBar";
            btnBar.Size = new Size(264, 66);
            btnBar.TabIndex = 2;
            btnBar.Text = "Bar Chart";
            btnBar.UseVisualStyleBackColor = false;
            btnBar.Click += btnBar_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1541, 918);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "Folder Traverser";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            mainRightContainer.ResumeLayout(false);
            LeftPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private Panel mainRightContainer;
        private Panel LeftPanel;
        private Button btnTree;
        private Button btnBar;
        private Button btnBrowse;
        private TreeView treeView1;
        private Panel panel1;
    }
}