using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Browser
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            AppContainer container = new AppContainer();
            container.Tabs.Add(new EasyTabs.TitleBarTab(container) {
                Content = new frmMain
                {
                    Text = "New Tab"
                }
            });
            container.SelectedTabIndex =  0;
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
    }
}
