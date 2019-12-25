using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace OpticalFiber
{
    public partial class UCDeviceManagement : UserControl
    {
        List<struct_DeviceEnable> struct_DeviceEnables;
        struct_DeviceEnable struct_DeviceEnable;
        public UCDeviceManagement()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            try
            {
                struct_DeviceEnables = ConfigClass.GetStruct_DeviceEnables();
               
                struct_DeviceEnable = struct_DeviceEnables[0];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_1.Checked = true;
                    grbDevice_1.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_1.Checked = true;
                    grbDevice_1.BackColor = Color.Gray;
                }
                tbxDeviceName_1.Text = struct_DeviceEnable.name;
                tbxIpAddress_1.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_1.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[1];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_2.Checked = true;
                    grbDevice_2.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_2.Checked = true;
                    grbDevice_2.BackColor = Color.Gray;
                }
                tbxDeviceName_2.Text = struct_DeviceEnable.name;
                tbxIpAddress_2.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_2.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[2];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_3.Checked = true;
                    grbDevice_3.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_3.Checked = true;
                    grbDevice_3.BackColor = Color.Gray;
                }
                tbxDeviceName_3.Text = struct_DeviceEnable.name;
                tbxIpAddress_3.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_3.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[3];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_4.Checked = true;
                    grbDevice_4.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_4.Checked = true;
                    grbDevice_4.BackColor = Color.Gray;
                }
                tbxDeviceName_4.Text = struct_DeviceEnable.name;
                tbxIpAddress_4.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_4.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[4];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_5.Checked = true;
                    grbDevice_5.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_5.Checked = true;
                    grbDevice_5.BackColor = Color.Gray;
                }
                tbxDeviceName_5.Text = struct_DeviceEnable.name;
                tbxIpAddress_5.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_5.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[5];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_6.Checked = true;
                    grbDevice_6.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_6.Checked = true;
                    grbDevice_6.BackColor = Color.Gray;
                }
                tbxDeviceName_6.Text = struct_DeviceEnable.name;
                tbxIpAddress_6.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_6.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[6];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_7.Checked = true;
                    grbDevice_7.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_7.Checked = true;
                    grbDevice_7.BackColor = Color.Gray;
                }
                tbxDeviceName_7.Text = struct_DeviceEnable.name;
                tbxIpAddress_7.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_7.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();

                struct_DeviceEnable = struct_DeviceEnables[7];
                if (struct_DeviceEnable.enable)
                {
                    rbdEnable_8.Checked = true;
                    grbDevice_8.BackColor = Color.SteelBlue;
                }
                else
                {
                    rbdDisable_8.Checked = true;
                    grbDevice_8.BackColor = Color.Gray;
                }
                tbxDeviceName_8.Text = struct_DeviceEnable.name;
                tbxIpAddress_8.Text = struct_DeviceEnable.ipEndPoint.Address.ToString();
                tbxPort_8.Text = struct_DeviceEnable.ipEndPoint.Port.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取设备配置信息失败！" + ex.Message);
            }
        }

        private void rbdEnable_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_1.Checked)
            {
                grbDevice_1.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_1.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_2.Checked)
            {
                grbDevice_2.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_2.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_3.Checked)
            {
                grbDevice_3.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_3.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_4.Checked)
            {
                grbDevice_4.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_4.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_5.Checked)
            {
                grbDevice_5.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_5.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_6_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_6.Checked)
            {
                grbDevice_6.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_6.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_7_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_7.Checked)
            {
                grbDevice_7.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_7.BackColor = Color.Gray;
            }
        }

        private void rbdEnable_8_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdEnable_8.Checked)
            {
                grbDevice_8.BackColor = Color.SteelBlue;
            }
            else
            {
                grbDevice_8.BackColor = Color.Gray;
            }
        }

        private void btnConfirm_1_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_1.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_1.Text);
            int port = Convert.ToInt32(tbxPort_1.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_1.Text;
            ConfigClass.SetStruct_DeviceEnables(1, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_2_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_2.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_2.Text);
            int port = Convert.ToInt32(tbxPort_2.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_2.Text;
            ConfigClass.SetStruct_DeviceEnables(2, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_3_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_3.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_3.Text);
            int port = Convert.ToInt32(tbxPort_3.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_3.Text;
            ConfigClass.SetStruct_DeviceEnables(3, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_4_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_4.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_4.Text);
            int port = Convert.ToInt32(tbxPort_4.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_4.Text;
            ConfigClass.SetStruct_DeviceEnables(4, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_5_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_5.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_5.Text);
            int port = Convert.ToInt32(tbxPort_5.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_5.Text;
            ConfigClass.SetStruct_DeviceEnables(5, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_6_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_6.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_6.Text);
            int port = Convert.ToInt32(tbxPort_6.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_6.Text;
            ConfigClass.SetStruct_DeviceEnables(6, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_7_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_7.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_7.Text);
            int port = Convert.ToInt32(tbxPort_7.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_7.Text;
            ConfigClass.SetStruct_DeviceEnables(7, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

        private void btnConfirm_8_Click(object sender, EventArgs e)
        {
            struct_DeviceEnable struct_DeviceEnable;
            struct_DeviceEnable.enable = rbdEnable_8.Checked;
            IPAddress iPAddress = IPAddress.Parse(tbxIpAddress_8.Text);
            int port = Convert.ToInt32(tbxPort_8.Text);
            struct_DeviceEnable.ipEndPoint = new IPEndPoint(iPAddress, port);
            struct_DeviceEnable.name = tbxDeviceName_8.Text;
            ConfigClass.SetStruct_DeviceEnables(8, struct_DeviceEnable);
            MessageBox.Show("设置成功！");
        }

       
    }
}
