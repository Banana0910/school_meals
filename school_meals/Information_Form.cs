using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_meals
{
    public partial class Information_Form : Form
    {
        public Information_Form(string date, string menu, string calorie)
        {
            InitializeComponent();
            

            date_box.Text = $"{date} {weekday_to_text((int)Convert.ToDateTime(date).DayOfWeek)}";
            menu_box.Text = menu.Replace("\n", Environment.NewLine);
            calorie_box.Text = calorie;
        }

        private string weekday_to_text(int weekday)
        {
            switch (weekday)
            {
                case 0: return "일요일";
                case 1: return "월요일";
                case 2: return "화요일";
                case 3: return "수요일";
                case 4: return "목요일";
                case 5: return "금요일";
                case 6: return "토요일";
                default: return "오류";
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
