using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticalFiber
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMain());
            //FrmLogin frmLogin = new FrmLogin();
            //if (frmLogin.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new FrmMain());

            //}
            //FrmInitDB frmInitDB = new FrmInitDB();
            //if (frmInitDB.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new FrmLogin());
            //}


            bool ret;
            Mutex mutex = new Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                FrmInitDB frmInitDB = new FrmInitDB();
                if (frmInitDB.ShowDialog() == DialogResult.OK)
                {
                    FrmLogin frmLogin = new FrmLogin();
                    if (frmLogin.ShowDialog()== DialogResult.OK)
                    {
                        Application.Run(new FrmMain());
                    }
                }
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("软件运行中，请忽重复运行！");
                Application.Exit();
            }
        }
    }
}
