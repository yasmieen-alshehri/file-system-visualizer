using FolderVisualizer.Core;
using FolderVisualizer.Services;
using FolderVisualizer.UI;
using FolderVisualizer.Visualization;

using System;
using System.Windows.Forms;

namespace FolderVisualizer
{
    public partial class MainForm : Form
    {
        private FolderItem _root;
        private readonly VisualizationPanel _vizPanel;
        private readonly IVisualizer _treeVis = new TreeVisualizer();
        private readonly IVisualizer _barVis = new BarChartVisualizer();

        public MainForm()
        {
            InitializeComponent();

            treeView1.Font = new Font("Segoe UI", 12, FontStyle.Regular);


            _vizPanel = new VisualizationPanel
            {
                Dock = DockStyle.Fill
            };
            mainRightContainer.Controls.Add(_vizPanel);


            _vizPanel.SetVisualizer(_treeVis);
        }
        private bool EnsureFolderSelected()
        {
            if (_root == null)
            {
                MessageBox.Show("Please browse a folder first.", "No Folder Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadFolder(dlg.SelectedPath);
            }
        }

        private void LoadFolder(string path)
        {
            _root = FolderTraverser.BuildTree(path);
            _root.CalculateSize();
            _root.Visualize(_vizPanel);
            BuildTreeView();
        }


        private void btnTree_Click(object sender, EventArgs e)
        {
            if (!EnsureFolderSelected()) return;

            _vizPanel.SetVisualizer(_treeVis);
        }

        private void btnBar_Click(object sender, EventArgs e)
        {
            if (!EnsureFolderSelected()) return;

            _vizPanel.SetVisualizer(_barVis);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainRightContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BuildTreeView()
        {
            treeView1.Nodes.Clear();
            if (_root == null) return;

           
            TreeNode rootNode = new TreeNode(_root.Name);
            treeView1.Nodes.Add(rootNode);

            foreach (var child in _root.Children)
            {
                child.BuildTreeNode(rootNode);
            }

            treeView1.ExpandAll();
        }


    }
}
