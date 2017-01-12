using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ys000
{
    public partial class FullScreenWindow : Form
    {
        IntPtr session;//存放会话session
        string cameraid1 { get; set; }
        public FullScreenWindow(string cameraid,IntPtr sessionid)
        {
            InitializeComponent();
            session = sessionid;
            
            pictureBox1.Dock = DockStyle.Fill;//设置全屏
            bool play = HkAction.Play(pictureBox1.Handle,cameraid,sessionid);
            if (play == false)
            {
                MessageBox.Show("全屏播放失败！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            //cameraid1 = cameraid;
        }
        //鼠标双击画面关闭
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool close = HkAction.Stop(session);//关闭会话，停止播放
            this.Close();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
    }
}
