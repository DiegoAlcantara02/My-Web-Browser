using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Browser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //enter key
                browser.Load(txtUrl.Text);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            browser.Load(txtUrl.Text);
        }
        ChromiumWebBrowser browser;

        private void frmMain_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            txtUrl.Text = "https://www.google.com";
            browser = new ChromiumWebBrowser(txtUrl.Text);
            browser.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(browser); //Add browser to panel control
            browser.AddressChanged += Browser_AddressChanged; 
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                txtUrl.Text = e.Address;

            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            browser.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
                browser.Forward();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
                browser.Back();
        }
    }
}
