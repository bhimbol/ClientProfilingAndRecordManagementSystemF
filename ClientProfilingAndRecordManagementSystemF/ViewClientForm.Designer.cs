namespace ClientProfilingAndRecordManagementSystemF
{
    partial class ViewClientForm
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
            this.rvClient = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvClient
            // 
            this.rvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvClient.LocalReport.ReportEmbeddedResource = "ClientProfilingAndRecordManagementSystemF.ViewClientReport.rdlc";
            this.rvClient.Location = new System.Drawing.Point(0, 0);
            this.rvClient.Margin = new System.Windows.Forms.Padding(1);
            this.rvClient.Name = "rvClient";
            this.rvClient.Size = new System.Drawing.Size(884, 548);
            this.rvClient.TabIndex = 0;
            this.rvClient.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ViewClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 548);
            this.Controls.Add(this.rvClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewClientForm";
            this.Load += new System.EventHandler(this.ViewClientForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvClient;
    }
}