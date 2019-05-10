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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFinancialAdvisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListLabel = new System.Windows.Forms.Label();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.ListAXAFormButton = new System.Windows.Forms.Button();
            this.ListFinancialAdvisorButton = new System.Windows.Forms.Button();
            this.ListPlanButton = new System.Windows.Forms.Button();
            this.ListClientsButton = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPanel.Location = new System.Drawing.Point(0, 29);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(809, 40);
            this.MainPanel.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 29);
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
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // manageClientsToolStripMenuItem
            // 
            this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
            this.manageClientsToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.manageClientsToolStripMenuItem.Text = "Manage Clients";
            this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
            // 
            // manageFinancialAdvisorToolStripMenuItem
            // 
            this.manageFinancialAdvisorToolStripMenuItem.Name = "manageFinancialAdvisorToolStripMenuItem";
            this.manageFinancialAdvisorToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.manageFinancialAdvisorToolStripMenuItem.Text = "Manage Financial Advisor";
            this.manageFinancialAdvisorToolStripMenuItem.Click += new System.EventHandler(this.manageFinancialAdvisorToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLabel.Location = new System.Drawing.Point(21, 100);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(69, 20);
            this.ListLabel.TabIndex = 14;
            this.ListLabel.Text = "List of: ";
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListDataGridView.Location = new System.Drawing.Point(18, 125);
            this.ListDataGridView.MultiSelect = false;
            this.ListDataGridView.Name = "ListDataGridView";
            this.ListDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListDataGridView.Size = new System.Drawing.Size(581, 372);
            this.ListDataGridView.TabIndex = 13;
            this.ListDataGridView.Tag = "CLIENTS";
            this.ListDataGridView.DataSourceChanged += new System.EventHandler(this.ListDataGridView_DataSourceChanged);
            this.ListDataGridView.Click += new System.EventHandler(this.ListDataGridView_Click);
            this.ListDataGridView.DoubleClick += new System.EventHandler(this.ListDataGridView_DoubleClick);
            // 
            // ListAXAFormButton
            // 
            this.ListAXAFormButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ListAXAFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListAXAFormButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListAXAFormButton.Location = new System.Drawing.Point(615, 323);
            this.ListAXAFormButton.Name = "ListAXAFormButton";
            this.ListAXAFormButton.Size = new System.Drawing.Size(172, 56);
            this.ListAXAFormButton.TabIndex = 12;
            this.ListAXAFormButton.Text = "AXA FORMS";
            this.ListAXAFormButton.UseVisualStyleBackColor = false;
            this.ListAXAFormButton.Click += new System.EventHandler(this.ListAXAFormButton_Click);
            // 
            // ListFinancialAdvisorButton
            // 
            this.ListFinancialAdvisorButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ListFinancialAdvisorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFinancialAdvisorButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListFinancialAdvisorButton.Location = new System.Drawing.Point(615, 261);
            this.ListFinancialAdvisorButton.Name = "ListFinancialAdvisorButton";
            this.ListFinancialAdvisorButton.Size = new System.Drawing.Size(172, 56);
            this.ListFinancialAdvisorButton.TabIndex = 11;
            this.ListFinancialAdvisorButton.Text = "LIST OF FINANCIAL ADVISOR";
            this.ListFinancialAdvisorButton.UseVisualStyleBackColor = false;
            this.ListFinancialAdvisorButton.Click += new System.EventHandler(this.ListFinancialAdvisorButton_Click);
            // 
            // ListPlanButton
            // 
            this.ListPlanButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ListPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPlanButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListPlanButton.Location = new System.Drawing.Point(615, 199);
            this.ListPlanButton.Name = "ListPlanButton";
            this.ListPlanButton.Size = new System.Drawing.Size(172, 56);
            this.ListPlanButton.TabIndex = 10;
            this.ListPlanButton.Text = "LIST OF PLAN";
            this.ListPlanButton.UseVisualStyleBackColor = false;
            this.ListPlanButton.Click += new System.EventHandler(this.ListPlanButton_Click);
            // 
            // ListClientsButton
            // 
            this.ListClientsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ListClientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListClientsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListClientsButton.Location = new System.Drawing.Point(615, 137);
            this.ListClientsButton.Name = "ListClientsButton";
            this.ListClientsButton.Size = new System.Drawing.Size(172, 56);
            this.ListClientsButton.TabIndex = 9;
            this.ListClientsButton.Text = "LIST OF CLIENTS";
            this.ListClientsButton.UseVisualStyleBackColor = false;
            this.ListClientsButton.Click += new System.EventHandler(this.ListClientsButton_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtSearch.Location = new System.Drawing.Point(20, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(169, 26);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.Text = "Search";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(809, 523);
            this.Controls.Add(this.ListLabel);
            this.Controls.Add(this.ListDataGridView);
            this.Controls.Add(this.ListAXAFormButton);
            this.Controls.Add(this.ListFinancialAdvisorButton);
            this.Controls.Add(this.ListPlanButton);
            this.Controls.Add(this.ListClientsButton);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Profiling And Record Management System In AXA Samar";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFinancialAdvisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.DataGridView ListDataGridView;
        internal System.Windows.Forms.Button ListAXAFormButton;
        internal System.Windows.Forms.Button ListFinancialAdvisorButton;
        internal System.Windows.Forms.Button ListPlanButton;
        internal System.Windows.Forms.Button ListClientsButton;
        internal System.Windows.Forms.TextBox txtSearch;
    }
}

