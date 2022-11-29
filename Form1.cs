using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmptyStandbyList
{
    public partial class Form1 : Form
    {
        public static Form1 _instance;
        public Form1()
        {
            InitializeComponent();
            _instance = this;
            LoadConfig();
            if (config.enabled)
                Start();
            Thread updFrm = new Thread(() =>
            {
                while (!_instance.Created)
                    Thread.Sleep(10);
                UpdateForm();
                Form1._instance.Invoke(new Action(() => { Form1._instance.Hide(); }));
            });
            updFrm.IsBackground = true;
            updFrm.Start();
            
        }

        public static void UpdateForm()
        {
            try
            {
                Form1._instance.Invoke(new Action(() => { Form1._instance.intervalTb.Text = config.interval.ToString(); }));
                Form1._instance.Invoke(new Action(() => { Form1._instance.statusBtn.Text = config.enabled ? "Stop" : "Start"; }));
            }
            catch (Exception exc) {MessageBox.Show($"UpdateForm exception: {exc.Message}"); }
        }

        public static Config config;
        private static void LoadConfig()
        {
            if (!File.Exists(Config.path) || string.IsNullOrWhiteSpace(File.ReadAllText(Config.path)))
            {
                File.Create(Config.path).Close();
                config = new Config();
            }
            else
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Config.path));
        }
        private static void SaveConfig()
        {
            File.WriteAllText(Config.path, JsonConvert.SerializeObject(config));
        }
        public static void Start()
        {
            Thread dispatcher = new Thread(() =>
            {
                int clearCounter = 0;
                while (config.enabled)
                {
                    ClearMemory.ClearFileSystemCache(true);
                    clearCounter++;
                    Form1._instance.Invoke(new Action(() => { Form1._instance.Text = $"EmptyStandbyList ({clearCounter})"; }));
                    Thread.Sleep(config.interval);
                }
            });
            dispatcher.IsBackground = true;
            dispatcher.Start();
        }

        private void statusBtn_Click(object sender, EventArgs e)
        {
            config.enabled = !config.enabled;
            Form1._instance.Invoke(new Action(() => { Form1._instance.statusBtn.Text = config.enabled ? "Stop" : "Start"; }));
            SaveConfig();
            if (config.enabled)
                Start();
        }

        private void intervalTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void intervalTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                var value = int.Parse(_instance.intervalTb.Text);
                if (value < 1000)
                {
                    value = 1000;
                    Form1._instance.Invoke(new Action(() => { Form1._instance.intervalTb.Text = value.ToString(); }));
                }
                config.interval = value;
                SaveConfig();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Exit(null, null);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => notifyIcon.Visible = false;

        private void Exit(object sender, EventArgs e) => Close();
    }
    public class Config
    {
        public static string path = "config.txt";
        public bool enabled = false;
        public int interval = 5000;
    }
}
