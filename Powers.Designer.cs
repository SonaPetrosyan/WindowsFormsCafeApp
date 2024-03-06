using System.Windows.Forms;

namespace WindowsFormsApp4
{
    partial class Powers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tab1button = new System.Windows.Forms.Button();
            this.Tab2button = new System.Windows.Forms.Button();
            this.Tab3button = new System.Windows.Forms.Button();
            this.Tab4button = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridView1.Location = new System.Drawing.Point(4, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 6;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(960, 226);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "login";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column2.HeaderText = "login";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column1.HeaderText = "id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "button11";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column3.HeaderText = "1 , 1";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "button12";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column4.HeaderText = "1 , 2";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "button13";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column5.HeaderText = "1 ,3";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "button14";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.Format = "d";
            dataGridViewCellStyle18.NullValue = null;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Blue;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column6.HeaderText = "1 , 4";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "button15";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Blue;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column7.HeaderText = "1 , 5";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "button16";
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column8.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column8.HeaderText = "1 , 6";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "button17";
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column9.HeaderText = "1 , 7";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "button18";
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column10.HeaderText = "1 , 8";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "button19";
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column11.HeaderText = "1 , 9";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 80;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "button110";
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column12.HeaderText = "1 , 10";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.Width = 80;
            // 
            // Tab1button
            // 
            this.Tab1button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab1button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tab1button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Tab1button.FlatAppearance.BorderSize = 2;
            this.Tab1button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Tab1button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tab1button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab1button.Location = new System.Drawing.Point(134, 9);
            this.Tab1button.Name = "Tab1button";
            this.Tab1button.Size = new System.Drawing.Size(92, 27);
            this.Tab1button.TabIndex = 4;
            this.Tab1button.Text = "1-ին սյուն";
            this.Tab1button.UseVisualStyleBackColor = false;
            this.Tab1button.Click += new System.EventHandler(this.Tab1button_Click);
            // 
            // Tab2button
            // 
            this.Tab2button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab2button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tab2button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Tab2button.FlatAppearance.BorderSize = 2;
            this.Tab2button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Tab2button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tab2button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab2button.Location = new System.Drawing.Point(232, 9);
            this.Tab2button.Name = "Tab2button";
            this.Tab2button.Size = new System.Drawing.Size(92, 27);
            this.Tab2button.TabIndex = 5;
            this.Tab2button.Text = "2-րդ սյուն";
            this.Tab2button.UseVisualStyleBackColor = false;
            this.Tab2button.Click += new System.EventHandler(this.Tab2button_Click);
            // 
            // Tab3button
            // 
            this.Tab3button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab3button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tab3button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Tab3button.FlatAppearance.BorderSize = 2;
            this.Tab3button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Tab3button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tab3button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab3button.Location = new System.Drawing.Point(329, 9);
            this.Tab3button.Name = "Tab3button";
            this.Tab3button.Size = new System.Drawing.Size(92, 27);
            this.Tab3button.TabIndex = 6;
            this.Tab3button.Text = "3-րդ սյուն";
            this.Tab3button.UseVisualStyleBackColor = false;
            this.Tab3button.Click += new System.EventHandler(this.Tab3button_Click);
            // 
            // Tab4button
            // 
            this.Tab4button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab4button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tab4button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Tab4button.FlatAppearance.BorderSize = 2;
            this.Tab4button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Tab4button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tab4button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab4button.Location = new System.Drawing.Point(427, 9);
            this.Tab4button.Name = "Tab4button";
            this.Tab4button.Size = new System.Drawing.Size(92, 27);
            this.Tab4button.TabIndex = 7;
            this.Tab4button.Text = "4-րդ սյուն";
            this.Tab4button.UseVisualStyleBackColor = false;
            this.Tab4button.Click += new System.EventHandler(this.Tab4button_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Savebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Savebutton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Savebutton.FlatAppearance.BorderSize = 2;
            this.Savebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.Savebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebutton.Location = new System.Drawing.Point(4, 9);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(92, 27);
            this.Savebutton.TabIndex = 8;
            this.Savebutton.Tag = "1";
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = false;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // message
            // 
            this.message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.Orange;
            this.message.Location = new System.Drawing.Point(525, 13);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(433, 21);
            this.message.TabIndex = 10;
            this.message.Tag = "4";
            this.message.Text = "message";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.message.Visible = false;
            // 
            // Powers
            // 
            this.ClientSize = new System.Drawing.Size(966, 310);
            this.Controls.Add(this.message);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Tab4button);
            this.Controls.Add(this.Tab3button);
            this.Controls.Add(this.Tab2button);
            this.Controls.Add(this.Tab1button);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Powers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Tab1button;
        private System.Windows.Forms.Button Tab2button;
        private System.Windows.Forms.Button Tab3button;
        private System.Windows.Forms.Button Tab4button;
        private System.Windows.Forms.Button Savebutton;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private Label message;
    }
}
