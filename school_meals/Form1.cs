using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace school_meals
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string school_site = "";
        int target_month = 0;

        private string substring_menu(string text)
        {
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Contains("("))
                    lines[i] = line.Substring(0, line.IndexOf('('));
            }
            return string.Join("\n", lines);
        }
        private void getschoolmeals()
        {
            ChromeOptions option = new ChromeOptions();
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            option.AddArguments("--disable-gpu", "--disable-software-rasterizer", "--headless", "--no-sandbox");
            WebDriver driver = new ChromeDriver(driverService, option);
            Uri uri = new Uri(school_site);
            int today_year = DateTime.Today.Year;
            int loop_count = DateTime.DaysInMonth(DateTime.Today.Year, target_month);
            for (int i = 0; i < loop_count; i++)
            {
                driver.Navigate().GoToUrl($"{uri.Scheme}://{uri.Host}/{uri.Host.Split('.')[0]}/dv/dietView/selectDietCalendarView.do?dietDate={today_year}/{target_month}/{i}");
                string menu = substring_menu(driver.FindElement(By.XPath("//*[@id='subContent']/div/div[3]/div[2]/table/tbody/tr[2]/td")).Text);
                string calorie = driver.FindElement(By.XPath("//*[@id='subContent']/div/div[3]/div[2]/table/tbody/tr[4]/td")).Text;
            }
        }

        ////*[@id="widgDiv5"]/div/a
        //
    }
}
