namespace ClientProfilingAndRecordManagementSystemF
{
    partial class ClientPlanForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanType = new System.Windows.Forms.TextBox();
            this.txtPlanCategory = new System.Windows.Forms.TextBox();
            this.txtPlanDescription = new System.Windows.Forms.TextBox();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbModeofPayment = new System.Windows.Forms.ListBox();
            this.lblDue = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAddPlan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plan Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plan Categery:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plan Description:";
            // 
            // txtPlanType
            // 
            this.txtPlanType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPlanType.Enabled = false;
            this.txtPlanType.Location = new System.Drawing.Point(167, 49);
            this.txtPlanType.Name = "txtPlanType";
            this.txtPlanType.Size = new System.Drawing.Size(269, 20);
            this.txtPlanType.TabIndex = 3;
            // 
            // txtPlanCategory
            // 
            this.txtPlanCategory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPlanCategory.Enabled = false;
            this.txtPlanCategory.Location = new System.Drawing.Point(167, 75);
            this.txtPlanCategory.Name = "txtPlanCategory";
            this.txtPlanCategory.Size = new System.Drawing.Size(269, 20);
            this.txtPlanCategory.TabIndex = 4;
            // 
            // txtPlanDescription
            // 
            this.txtPlanDescription.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPlanDescription.Enabled = false;
            this.txtPlanDescription.Location = new System.Drawing.Point(167, 101);
            this.txtPlanDescription.Name = "txtPlanDescription";
            this.txtPlanDescription.Size = new System.Drawing.Size(269, 20);
            this.txtPlanDescription.TabIndex = 5;
            // 
            // txtDue
            // 
            this.txtDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.Location = new System.Drawing.Point(20, 267);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(177, 26);
            this.txtDue.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 105;
            this.label4.Text = "Mode of Payment";
            // 
            // lbModeofPayment
            // 
            this.lbModeofPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModeofPayment.FormattingEnabled = true;
            this.lbModeofPayment.ItemHeight = 20;
            this.lbModeofPayment.Items.AddRange(new object[] {
            "Monthly Premium",
            "Quarterly Premium",
            "Semi Anual Premium",
            "Anual Premium"});
            this.lbModeofPayment.Location = new System.Drawing.Point(19, 157);
            this.lbModeofPayment.Name = "lbModeofPayment";
            this.lbModeofPayment.Size = new System.Drawing.Size(336, 84);
            this.lbModeofPayment.TabIndex = 104;
            this.lbModeofPayment.SelectedIndexChanged += new System.EventHandler(this.lbModeofPayment_SelectedIndexChanged_1);
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(16, 244);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(114, 20);
            this.lblDue.TabIndex = 103;
            this.lblDue.Text = "Monthly Due:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancel.Location = new System.Drawing.Point(361, 226);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 57);
            this.BtnCancel.TabIndex = 107;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAddPlan
            // 
            this.BtnAddPlan.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAddPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPlan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddPlan.Location = new System.Drawing.Point(361, 157);
            this.BtnAddPlan.Name = "BtnAddPlan";
            this.BtnAddPlan.Size = new System.Drawing.Size(75, 57);
            this.BtnAddPlan.TabIndex = 108;
            this.BtnAddPlan.Text = "Add Plan";
            this.BtnAddPlan.UseVisualStyleBackColor = false;
            this.BtnAddPlan.Click += new System.EventHandler(this.BtnAddPlan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 40);
            this.panel1.TabIndex = 109;
            // 
            // ClientPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 305);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnAddPlan);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.txtDue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbModeofPayment);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.txtPlanDescription);
            this.Controls.Add(this.txtPlanCategory);
            this.Controls.Add(this.txtPlanType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ClientPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientPlanForm";
            this.Load += new System.EventHandler(this.ClientPlanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanType;
        private System.Windows.Forms.TextBox txtPlanCategory;
        private System.Windows.Forms.TextBox txtPlanDescription;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbModeofPayment;
        internal System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAddPlan;
        private System.Windows.Forms.Panel panel1;
    }
}