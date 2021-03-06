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
using System.Diagnostics;

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

        private void initprogress()
        {
            status_label.Text = "아무 작업 없음";
            progress.Value = 0;
            progress.Maximum = 100;
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
                initprogress();
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

        private void save_excel_btn_Click(object sender, EventArgs e)
        {
            string path = save_excel();
            if (path != "error")
                MessageBox.Show($"바탕화면에 [{Path.GetFileName(path)}](으)로 저장되었습니다", "school_meals", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string save_excel()
        {
            try
            {
                const int start_weekday = 2;
                const int end_weekday = 8;

                setprogress("파일 생성 중", 10);

                Excel.Application app = new Excel.Application();
                app.Visible = false;
                Excel.Workbook wb = app.Workbooks.Add();
                Excel.Worksheet sheet = wb.Sheets[1];
                sheet.Name = "정보";

                setprogress("정보 작성 중", 50);

                int line = 0;
                foreach (ListViewItem lvi in meals.Items)
                {
                    int weekday = (int)Convert.ToDateTime(lvi.SubItems[0].Text).DayOfWeek + 2;
                    if (weekday == 2)
                        line++;
                    for (int i = 0; i < 3; i++)
                        sheet.Cells[(line * 3) + line + i + 2, weekday] = lvi.SubItems[i].Text;
                    setprogress(lvi.SubItems[0].Text, progress.Value + 1);
                }

                setprogress("다듬는 중", 85);

                sheet.Range[sheet.Columns[start_weekday], sheet.Columns[end_weekday]].ColumnWidth = 18;
                sheet.Columns[1].ColumnWidth = 1.25;
                sheet.Rows[1].RowHeight = 12;
                for (int i = 0; i <= line; i++)
                {
                    sheet.Rows[(i * 4) + 3].RowHeight = 150;
                    Excel.Range range = sheet.Range[sheet.Cells[(i * 4) + 2, start_weekday], sheet.Cells[(i * 4) + 4, end_weekday]];
                    range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.HorizontalAlignment = 3;
                }

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
                    file_num++;
                }
                wb.Close(true);
                app.Quit();
                ReleaseExcelObject(wb);
                ReleaseExcelObject(app);
                setprogress("완료", 100);
                initprogress();
                return path;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 : {ex}");
                initprogress();
                return "error";
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

        private void save_open_excel_btn_Click(object sender, EventArgs e)
        {
            string path = save_excel();
            if (path != "error")
                Process.Start(path);
        }
    }
}
