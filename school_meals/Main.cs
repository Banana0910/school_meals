using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Drawing;

namespace school_meals
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        int target_month = 1;

        private string substring_menu(string text)
        {
            string[] lines = Regex.Replace(text, "[0-9\\.]", "").Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Contains("("))
                    lines[i] = line.Substring(0, line.IndexOf('('));
            }
            return string.Join("\n", lines);
        }

        private void setvalue(int value, int max)
        {
            status_label.Text = $"진행 중.. ({value}/{max})";
            progress.Value = value;
        }
        private void setprogress(string msg, int value)
        {
            status_label.Text = $"{msg}.. ({value}%)";
            progress.Value = value;
        }

        private void getschoolmeals(string url)
        {
            try
            {
                status_label.Text = "가상 웹 여는 중..";
                ChromeOptions option = new ChromeOptions();
                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                
                option.AddArguments("--disable-gpu", "--disable-software-rasterizer", "--headless", "--no-sandbox");
                IWebDriver driver = new ChromeDriver(driverService, option);
                Uri uri = new Uri(url);
                int today_year = DateTime.Today.Year;
                int loop_count = DateTime.DaysInMonth(DateTime.Today.Year, target_month);
                progress.Maximum = loop_count;
                setvalue(0, loop_count);
                for (int i = 1; i <= loop_count; i++)
                {
                    string date = new DateTime(today_year, target_month, i).ToString("yyyy/MM/dd");
                    driver.Navigate().GoToUrl($"{uri.Scheme}://{uri.Host}/{uri.Host.Split('.')[0]}/dv/dietView/selectDietDetailView.do?dietDate={date}");
                    string menu = substring_menu(driver.FindElement(By.XPath("//*[@id='subContent']/div/div[3]/div[2]/table/tbody/tr[2]/td")).Text);
                    string calorie = driver.FindElement(By.XPath("//*[@id='subContent']/div/div[3]/div[2]/table/tbody/tr[4]/td")).Text;
                    
                    ListViewItem lvi = new ListViewItem(date);
                    if (string.IsNullOrWhiteSpace(menu))
                    {
                        lvi.SubItems.Add("급식 없음");
                        lvi.ForeColor = Color.Gray;
                    }
                    else
                    {
                        lvi.SubItems.Add(menu);
                    }
                    lvi.SubItems.Add((calorie.Trim() == "Kcal") ? "0 Kcal" : calorie);
                    meals.Items.Add(lvi);
                    setvalue(i, loop_count);
                }
                driver.Quit();
                status_label.Text = "아무 작업 없음";
                progress.Value = 0;
                MessageBox.Show("파싱 완료", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"에러 : {e}");
            }
        }

        private void target_month_box_Click(object sender, EventArgs e)
        {
            target_month_box.SelectAll();
        }

        private void target_month_box_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(target_month_box.Text))
            {
                MessageBox.Show("개월수를 입력해주세요..", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                target_month_box.Focus();
            }
        }

        private void target_month_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(target_month_box.Text))
                return;

            int month;
            if (int.TryParse(target_month_box.Text, out month))
            {
                if (month > 12 || month < 1)
                {
                    MessageBox.Show("현실적인 개월수를 입력해주세요.", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target_month_box.Text = target_month.ToString();
                    target_month_box.Focus();
                }
                else
                {
                    target_month = month;
                }
            }
            else
            {
                MessageBox.Show("숫자를 입력해주세요.", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Error);
                target_month_box.Text = target_month.ToString();
                target_month_box.Focus();
            }
        }

        private void sub_btn_Click(object sender, EventArgs e)
        {
            if (target_month == 1)
                target_month_box.Text = "12";
            else
                target_month_box.Text = (target_month - 1).ToString();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (target_month == 12)
                target_month_box.Text = "1";
            else
                target_month_box.Text = (target_month + 1).ToString();
        }

        private void run_btn_Click(object sender, EventArgs e)
        {
            meals.Items.Clear();
            new Thread(() => getschoolmeals(school_url_box.Text)).Start();
        }

        private void save_excel_Click(object sender, EventArgs e)
        {
            try
            {
                progress.Maximum = 100;

                setprogress("파일 생성 중", 0);
                Excel.Application app = new Excel.Application();
                app.Visible = false;
                Excel.Workbook wb = app.Workbooks.Add();
                Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets.Add();
                sheet.Name = "정보";

                setprogress("정보 작성 중", 50);
                int line = 0;
                foreach (ListViewItem lvi in meals.Items)
                {
                    int weekday = (int)Convert.ToDateTime(lvi.SubItems[0].Text).DayOfWeek;
                    if (weekday == 0)
                        line++;
                    if (weekday == 0 || weekday == 6)
                        continue;
                    for (int i = 0; i < 3; i++)
                        sheet.Cells[line*3+(i+1),weekday] = lvi.SubItems[i].Text;
                    setprogress(lvi.SubItems[0].Text, progress.Value + 1);
                }

                setprogress("다듬는 중", 85);
                
                sheet.Range[sheet.Columns[1], sheet.Columns[5]].ColumnWidth = 18;
                for (int i = 0; i <= 4; i++)
                    sheet.Range[sheet.Rows[2+i*3], sheet.Rows[2+i*3]].RowHeight = 150;

                Excel.Range range = sheet.Range[sheet.Cells[1,1], sheet.Cells[line*4-1,5]];
                range.BorderAround2(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.HorizontalAlignment = 3;

                setprogress("파일 저장 중", 95);

                int file_num = 0;
                string path = "";
                while (true)
                {
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"급식{file_num}.xlsx");
                    if (!File.Exists(path))
                    {
                        wb.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                        break;
                    }
                    else
                    {
                        file_num++;
                    }
                }
                wb.Close(true);
                app.Quit();
                ReleaseExcelObject(wb);
                ReleaseExcelObject(app);
                setprogress("완료", 100);
                MessageBox.Show($"바탕화면에 [{Path.GetFileName(path)}](으)로 저장되었습니다", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 : {ex}");
            }
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void meals_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in meals.SelectedItems)
            {
                Form form = new Information_Form(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text);
                form.Show();
            }
        }
    }
}
