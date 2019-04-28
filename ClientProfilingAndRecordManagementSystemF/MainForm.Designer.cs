namespace ClientProfilingAndRecordManagementSystemF
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ListLabel = new System.Windows.Forms.Label();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.ListAXAFormButton = new System.Windows.Forms.Button();
            this.ListFinancialAdvisorButton = new System.Windows.Forms.Button();
            this.ListPlanButton = new System.Windows.Forms.Button();
            this.ListClientsButton = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFinancialAdvisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainPanel.Controls.Add(this.ListLabel);
            this.MainPanel.Controls.Add(this.ListDataGridView);
            this.MainPanel.Controls.Add(this.ListAXAFormButton);
            this.MainPanel.Controls.Add(this.ListFinancialAdvisorButton);
            this.MainPanel.Controls.Add(this.ListPlanButton);
            this.MainPanel.Controls.Add(this.ListClientsButton);
            this.MainPanel.Controls.Add(this.txtSearch);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(809, 499);
            this.MainPanel.TabIndex = 3;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Location = new System.Drawing.Point(23, 44);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(41, 13);
            this.ListLabel.TabIndex = 7;
            this.ListLabel.Text = "List of: ";
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListDataGridView.Location = new System.Drawing.Point(12, 59);
            this.ListDataGridView.MultiSelect = false;
            this.ListDataGridView.Name = "ListDataGridView";
            this.ListDataGridView.ReadOnly = true;
            this.ListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListDataGridView.Size = new System.Drawing.Size(581, 406);
            this.ListDataGridView.TabIndex = 6;
            this.ListDataGridView.Tag = "CLIENTS";
            this.ListDataGridView.DataSourceChanged += new System.EventHandler(this.ListDataGridView_DataSourceChanged);
            this.ListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListDataGridView_CellContentClick);
            this.ListDataGridView.Click += new System.EventHandler(this.ListDataGridView_Click);
            this.ListDataGridView.DoubleClick += new System.EventHandler(this.ListDataGridView_DoubleClick);
            // 
            // ListAXAFormButton
            // 
            this.ListAXAFormButton.Location = new System.Drawing.Point(613, 262);
            this.ListAXAFormButton.Name = "ListAXAFormButton";
            this.ListAXAFormButton.Size = new System.Drawing.Size(172, 56);
            this.ListAXAFormButton.TabIndex = 5;
            this.ListAXAFormButton.Text = "AXA FORMS";
            this.ListAXAFormButton.UseVisualStyleBackColor = true;
            this.ListAXAFormButton.Click += new System.EventHandler(this.ListAXAFormButton_Click);
            // 
            // ListFinancialAdvisorButton
            // 
            this.ListFinancialAdvisorButton.Location = new System.Drawing.Point(613, 200);
            this.ListFinancialAdvisorButton.Name = "ListFinancialAdvisorButton";
            this.ListFinancialAdvisorButton.Size = new System.Drawing.Size(172, 56);
            this.ListFinancialAdvisorButton.TabIndex = 4;
            this.ListFinancialAdvisorButton.Text = "LIST OF FINANCIAL ADVISOR";
            this.ListFinancialAdvisorButton.UseVisualStyleBackColor = true;
            this.ListFinancialAdvisorButton.Click += new System.EventHandler(this.ListFinancialAdvisorButton_Click);
            // 
            // ListPlanButton
            // 
            this.ListPlanButton.Location = new System.Drawing.Point(613, 138);
            this.ListPlanButton.Name = "ListPlanButton";
            this.ListPlanButton.Size = new System.Drawing.Size(172, 56);
            this.ListPlanButton.TabIndex = 3;
            this.ListPlanButton.Text = "LIST OF PLAN";
            this.ListPlanButton.UseVisualStyleBackColor = true;
            this.ListPlanButton.Click += new System.EventHandler(this.ListPlanButton_Click);
            // 
            // ListClientsButton
            // 
            this.ListClientsButton.Location = new System.Drawing.Point(613, 76);
            this.ListClientsButton.Name = "ListClientsButton";
            this.ListClientsButton.Size = new System.Drawing.Size(172, 56);
            this.ListClientsButton.TabIndex = 2;
            this.ListClientsButton.Text = "LIST OF CLIENTS";
            this.ListClientsButton.UseVisualStyleBackColor = true;
            this.ListClientsButton.Click += new System.EventHandler(this.ListClientsButton_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(461, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(132, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageClientsToolStripMenuItem,
            this.manageFinancialAdvisorToolStripMenuItem,
            this.manageUsersToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // manageClientsToolStripMenuItem
            // 
            this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
            this.manageClientsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.manageClientsToolStripMenuItem.Text = "Manage Clients";
            this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
            // 
            // manageFinancialAdvisorToolStripMenuItem
            // 
            this.manageFinancialAdvisorToolStripMenuItem.Name = "manageFinancialAdvisorToolStripMenuItem";
            this.manageFinancialAdvisorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.manageFinancialAdvisorToolStripMenuItem.Text = "Manage Financial Advisor";
            this.manageFinancialAdvisorToolStripMenuItem.Click += new System.EventHandler(this.manageFinancialAdvisorToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(809, 523);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Profiling And Record Management System In AXA Samar";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel MainPanel;
        internal System.Windows.Forms.Button ListAXAFormButton;
        internal System.Windows.Forms.Button ListFinancialAdvisorButton;
        internal System.Windows.Forms.Button ListPlanButton;
        internal System.Windows.Forms.Button ListClientsButton;
        internal System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.DataGridView ListDataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFinancialAdvisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
    }
}

