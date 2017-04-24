using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tyysocx;
using static tyysocx.HkApi;

namespace tyysoxcexe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (this.tyysocx1.LoginImmediately())
            if (this.tyysocx1.LoginByMid())
            {
                MessageBox.Show("登录成功!");
                button2.Enabled = true;
            }
        }

        private List<camera> _devices = null;
        private void button2_Click(object sender, EventArgs e)
        {
            GetDevListResult result = this.tyysocx1.GetCameraList();
            if (result.resultCode == 200)
            {
                _devices = result.cameraList;
                foreach (var camera in result.cameraList)
                {
                    listBox1.Items.Add(camera.cameraName);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0 && _devices != null)
            {
                var camera = _devices[index];
                this.tyysocx1.StartPlay(camera.cameraId);
            }
        }
    }
}
