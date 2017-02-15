namespace CSharpApplication3
{
    partial class PersonDAOForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFindById = new System.Windows.Forms.Button();
            this.btnFindAll = new System.Windows.Forms.Button();
            this.tbFindById = new System.Windows.Forms.TextBox();
            this.tbDelete = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "General Commands";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(51, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Person";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(51, 118);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUpdate_MouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(51, 161);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDelete_MouseClick);
            // 
            // btnFindById
            // 
            this.btnFindById.Location = new System.Drawing.Point(51, 199);
            this.btnFindById.Name = "btnFindById";
            this.btnFindById.Size = new System.Drawing.Size(75, 23);
            this.btnFindById.TabIndex = 4;
            this.btnFindById.Text = "FindById";
            this.btnFindById.UseVisualStyleBackColor = true;
            this.btnFindById.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnFindById_MouseClick);
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(51, 241);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(75, 23);
            this.btnFindAll.TabIndex = 5;
            this.btnFindAll.Text = "FindAll";
            this.btnFindAll.UseVisualStyleBackColor = true;
            this.btnFindAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnFindAll_MouseClick);
            // 
            // tbFindById
            // 
            this.tbFindById.Location = new System.Drawing.Point(157, 201);
            this.tbFindById.Name = "tbFindById";
            this.tbFindById.Size = new System.Drawing.Size(100, 20);
            this.tbFindById.TabIndex = 6;
            this.tbFindById.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbDelete
            // 
            this.tbDelete.Location = new System.Drawing.Point(157, 161);
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(100, 20);
            this.tbDelete.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(48, 285);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // PersonDAOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 319);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbDelete);
            this.Controls.Add(this.tbFindById);
            this.Controls.Add(this.btnFindAll);
            this.Controls.Add(this.btnFindById);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "PersonDAOForm";
            this.Text = "PersonDAOForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFindById;
        private System.Windows.Forms.Button btnFindAll;
        private System.Windows.Forms.TextBox tbFindById;
        private System.Windows.Forms.TextBox tbDelete;
        private System.Windows.Forms.Label lblStatus;
    }
}