namespace TZMDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(340, 397);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(164, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(158, 97);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(663, 34);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(158, 174);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(663, 34);
            txtAuthor.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(158, 253);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(663, 138);
            txtContent.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 66);
            label1.Name = "label1";
            label1.Size = new Size(63, 28);
            label1.TabIndex = 4;
            label1.Text = "Titile :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(158, 143);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.TabIndex = 5;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 222);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 6;
            label3.Text = "Content :";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(158, 397);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(164, 38);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(970, 514);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
    }
}
