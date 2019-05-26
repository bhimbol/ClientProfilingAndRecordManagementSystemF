namespace ClientProfilingAndRecordManagementSystemF
{
    partial class ManageAXAForms
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
            this.listBoxAXAFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAXAForms = new System.Windows.Forms.ComboBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddAXAForm = new System.Windows.Forms.Button();
            this.btnDeleteAXAForm = new System.Windows.Forms.Button();
            this.btnEditAXAForm = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listBoxAXAFiles
            // 
            this.listBoxAXAFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAXAFiles.FormattingEnabled = true;
            this.listBoxAXAFiles.ItemHeight = 20;
            this.listBoxAXAFiles.Location = new System.Drawing.Point(12, 132);
            this.listBoxAXAFiles.Name = "listBoxAXAFiles";
            this.listBoxAXAFiles.Size = new System.Drawing.Size(649, 204);
            this.listBoxAXAFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "LIST OF AXA FORMS";
            // 
            // comboBoxAXAForms
            // 
            this.comboBoxAXAForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAXAForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAXAForms.FormattingEnabled = true;
            this.comboBoxAXAForms.Location = new System.Drawing.Point(12, 75);
            this.comboBoxAXAForms.Name = "comboBoxAXAForms";
            this.comboBoxAXAForms.Size = new System.Drawing.Size(309, 28);
            this.comboBoxAXAForms.TabIndex = 2;
            this.comboBoxAXAForms.SelectedValueChanged += new System.EventHandler(this.comboBoxAXAForms_SelectedValueChanged);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(99, 342);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 3;
            this.btnDeleteFile.Text = "Delete";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(12, 342);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 4;
            this.btnAddFile.Text = "Add";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(560, 342);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddAXAForm
            // 
            this.btnAddAXAForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAXAForm.Location = new System.Drawing.Point(354, 73);
            this.btnAddAXAForm.Name = "btnAddAXAForm";
            this.btnAddAXAForm.Size = new System.Drawing.Size(92, 30);
            this.btnAddAXAForm.TabIndex = 9;
            this.btnAddAXAForm.Text = "Add";
            this.btnAddAXAForm.UseVisualStyleBackColor = true;
            this.btnAddAXAForm.Click += new System.EventHandler(this.btnAddAXAForm_Click);
            // 
            // btnDeleteAXAForm
            // 
            this.btnDeleteAXAForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAXAForm.Location = new System.Drawing.Point(569, 73);
            this.btnDeleteAXAForm.Name = "btnDeleteAXAForm";
            this.btnDeleteAXAForm.Size = new System.Drawing.Size(92, 30);
            this.btnDeleteAXAForm.TabIndex = 8;
            this.btnDeleteAXAForm.Text = "Delete";
            this.btnDeleteAXAForm.UseVisualStyleBackColor = true;
            this.btnDeleteAXAForm.Click += new System.EventHandler(this.btnDeleteAXAForm_Click);
            // 
            // btnEditAXAForm
            // 
            this.btnEditAXAForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAXAForm.Location = new System.Drawing.Point(460, 73);
            this.btnEditAXAForm.Name = "btnEditAXAForm";
            this.btnEditAXAForm.Size = new System.Drawing.Size(92, 30);
            this.btnEditAXAForm.TabIndex = 10;
            this.btnEditAXAForm.Text = "Edit";
            this.btnEditAXAForm.UseVisualStyleBackColor = true;
            this.btnEditAXAForm.Click += new System.EventHandler(this.btnEditAXAForm_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ManageAXAForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 399);
            this.Controls.Add(this.btnEditAXAForm);
            this.Controls.Add(this.btnAddAXAForm);
            this.Controls.Add(this.btnDeleteAXAForm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.comboBoxAXAForms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAXAFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageAXAForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageAXAForms";
            this.Load += new System.EventHandler(this.ManageAXAForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAXAFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAXAForms;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddAXAForm;
        private System.Windows.Forms.Button btnDeleteAXAForm;
        private System.Windows.Forms.Button btnEditAXAForm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}