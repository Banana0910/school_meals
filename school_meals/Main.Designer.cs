
namespace school_meals
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.school_url_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.meals = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.run_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.target_month_box = new System.Windows.Forms.TextBox();
            this.sub_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.save_excel_btn = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.status_label = new System.Windows.Forms.Label();
            this.save_open_excel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // school_url_box
            // 
            this.school_url_box.Location = new System.Drawing.Point(132, 6);
            this.school_url_box.Name = "school_url_box";
            this.school_url_box.Size = new System.Drawing.Size(484, 23);
            this.school_url_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "창원 학교 사이트";
            // 
            // meals
            // 
            this.meals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.meals.HideSelection = false;
            this.meals.Location = new System.Drawing.Point(132, 35);
            this.meals.Name = "meals";
            this.meals.Size = new System.Drawing.Size(484, 190);
            this.meals.TabIndex = 2;
            this.meals.UseCompatibleStateImageBehavior = false;
            this.meals.View = System.Windows.Forms.View.SmallIcon;
            this.meals.DoubleClick += new System.EventHandler(this.meals_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "날짜";
            this.columnHeader1.Width = 129;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "급식";
            this.columnHeader2.Width = 415;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "칼로리";
            this.columnHeader3.Width = 100;
            // 
            // run_btn
            // 
            this.run_btn.Location = new System.Drawing.Point(12, 232);
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(114, 23);
            this.run_btn.TabIndex = 3;
            this.run_btn.Text = "파싱";
            this.run_btn.UseVisualStyleBackColor = true;
            this.run_btn.Click += new System.EventHandler(this.run_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "원하는 개월";
            // 
            // target_month_box
            // 
            this.target_month_box.Location = new System.Drawing.Point(52, 62);
            this.target_month_box.Name = "target_month_box";
            this.target_month_box.Size = new System.Drawing.Size(31, 23);
            this.target_month_box.TabIndex = 5;
            this.target_month_box.Text = "1";
            this.target_month_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.target_month_box.Click += new System.EventHandler(this.target_month_box_Click);
            this.target_month_box.TextChanged += new System.EventHandler(this.target_month_box_TextChanged);
            this.target_month_box.Leave += new System.EventHandler(this.target_month_box_leave);
            // 
            // sub_btn
            // 
            this.sub_btn.Location = new System.Drawing.Point(15, 62);
            this.sub_btn.Name = "sub_btn";
            this.sub_btn.Size = new System.Drawing.Size(31, 23);
            this.sub_btn.TabIndex = 6;
            this.sub_btn.Text = "<";
            this.sub_btn.UseVisualStyleBackColor = true;
            this.sub_btn.Click += new System.EventHandler(this.sub_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(89, 62);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(31, 23);
            this.add_btn.TabIndex = 7;
            this.add_btn.Text = ">";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // save_excel_btn
            // 
            this.save_excel_btn.Location = new System.Drawing.Point(132, 231);
            this.save_excel_btn.Name = "save_excel_btn";
            this.save_excel_btn.Size = new System.Drawing.Size(239, 23);
            this.save_excel_btn.TabIndex = 8;
            this.save_excel_btn.Text = "엑셀로 저장";
            this.save_excel_btn.UseVisualStyleBackColor = true;
            this.save_excel_btn.Click += new System.EventHandler(this.save_excel_btn_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 203);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(114, 23);
            this.progress.TabIndex = 9;
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Location = new System.Drawing.Point(12, 185);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(87, 15);
            this.status_label.TabIndex = 10;
            this.status_label.Text = "아무 작업 없음";
            // 
            // save_open_excel_btn
            // 
            this.save_open_excel_btn.Location = new System.Drawing.Point(377, 232);
            this.save_open_excel_btn.Name = "save_open_excel_btn";
            this.save_open_excel_btn.Size = new System.Drawing.Size(239, 23);
            this.save_open_excel_btn.TabIndex = 11;
            this.save_open_excel_btn.Text = "엑셀로 저장 후 열기";
            this.save_open_excel_btn.UseVisualStyleBackColor = true;
            this.save_open_excel_btn.Click += new System.EventHandler(this.save_open_excel_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 266);
            this.Controls.Add(this.save_open_excel_btn);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.save_excel_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.sub_btn);
            this.Controls.Add(this.target_month_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.run_btn);
            this.Controls.Add(this.meals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.school_url_box);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "창원 학교 급식 크롤러";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox school_url_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView meals;
        private System.Windows.Forms.Button run_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox target_month_box;
        private System.Windows.Forms.Button sub_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button save_excel_btn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Button save_open_excel_btn;
    }
}

