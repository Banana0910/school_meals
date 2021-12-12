
namespace school_meals
{
    partial class Information_Form
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
            this.date_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menu_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.calorie_box = new System.Windows.Forms.TextBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "날짜 :";
            // 
            // date_box
            // 
            this.date_box.BackColor = System.Drawing.Color.White;
            this.date_box.Location = new System.Drawing.Point(15, 30);
            this.date_box.Name = "date_box";
            this.date_box.ReadOnly = true;
            this.date_box.Size = new System.Drawing.Size(168, 23);
            this.date_box.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "급식 :";
            // 
            // menu_box
            // 
            this.menu_box.BackColor = System.Drawing.Color.White;
            this.menu_box.Location = new System.Drawing.Point(15, 78);
            this.menu_box.Multiline = true;
            this.menu_box.Name = "menu_box";
            this.menu_box.ReadOnly = true;
            this.menu_box.Size = new System.Drawing.Size(168, 157);
            this.menu_box.TabIndex = 3;
            this.menu_box.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "칼로리 :";
            // 
            // calorie_box
            // 
            this.calorie_box.BackColor = System.Drawing.Color.White;
            this.calorie_box.Location = new System.Drawing.Point(15, 256);
            this.calorie_box.Name = "calorie_box";
            this.calorie_box.ReadOnly = true;
            this.calorie_box.Size = new System.Drawing.Size(168, 23);
            this.calorie_box.TabIndex = 5;
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(12, 285);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(171, 23);
            this.close_btn.TabIndex = 6;
            this.close_btn.Text = "확인";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // Information_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(195, 318);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.calorie_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menu_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date_box);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Information_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox date_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox menu_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox calorie_box;
        private System.Windows.Forms.Button close_btn;
    }
}