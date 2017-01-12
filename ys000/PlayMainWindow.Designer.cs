namespace ys000
{
    partial class PlayMainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMainWindow));
            this.btnCapt = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFrm1 = new System.Windows.Forms.Button();
            this.btnFrm4 = new System.Windows.Forms.Button();
            this.btnFrm9 = new System.Windows.Forms.Button();
            this.btnGetlist = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label222 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCapt
            // 
            this.btnCapt.Location = new System.Drawing.Point(296, 16);
            this.btnCapt.Name = "btnCapt";
            this.btnCapt.Size = new System.Drawing.Size(78, 35);
            this.btnCapt.TabIndex = 2;
            this.btnCapt.Text = "截屏";
            this.btnCapt.UseVisualStyleBackColor = true;
            this.btnCapt.Click += new System.EventHandler(this.btnCapt_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(42, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(69, 35);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "停止播放";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(172, 64);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(69, 35);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(172, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 35);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "退出系统";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(4, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 597);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备列表";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(304, 570);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.MouseHover += new System.EventHandler(this.flowLayoutPanel2_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(291, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(975, 702);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "直播预览";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(964, 676);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnFrm1
            // 
            this.btnFrm1.Location = new System.Drawing.Point(959, 16);
            this.btnFrm1.Name = "btnFrm1";
            this.btnFrm1.Size = new System.Drawing.Size(78, 35);
            this.btnFrm1.TabIndex = 16;
            this.btnFrm1.Text = "单画面";
            this.btnFrm1.UseVisualStyleBackColor = true;
            this.btnFrm1.Click += new System.EventHandler(this.btnFrm1_Click);
            // 
            // btnFrm4
            // 
            this.btnFrm4.Location = new System.Drawing.Point(1061, 16);
            this.btnFrm4.Name = "btnFrm4";
            this.btnFrm4.Size = new System.Drawing.Size(78, 35);
            this.btnFrm4.TabIndex = 17;
            this.btnFrm4.Text = "四画面";
            this.btnFrm4.UseVisualStyleBackColor = true;
            this.btnFrm4.Click += new System.EventHandler(this.btnFrm4_Click);
            // 
            // btnFrm9
            // 
            this.btnFrm9.Location = new System.Drawing.Point(1163, 16);
            this.btnFrm9.Name = "btnFrm9";
            this.btnFrm9.Size = new System.Drawing.Size(78, 35);
            this.btnFrm9.TabIndex = 18;
            this.btnFrm9.Text = "九画面";
            this.btnFrm9.UseVisualStyleBackColor = true;
            this.btnFrm9.Click += new System.EventHandler(this.btnFrm9_Click);
            // 
            // btnGetlist
            // 
            this.btnGetlist.Location = new System.Drawing.Point(42, 64);
            this.btnGetlist.Name = "btnGetlist";
            this.btnGetlist.Size = new System.Drawing.Size(69, 35);
            this.btnGetlist.TabIndex = 11;
            this.btnGetlist.Text = "设备列表";
            this.btnGetlist.UseVisualStyleBackColor = true;
            this.btnGetlist.Click += new System.EventHandler(this.btnGetlist_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.label222);
            this.groupBox3.Controls.Add(this.label111);
            this.groupBox3.Controls.Add(this.btnCapt);
            this.groupBox3.Controls.Add(this.btnFrm1);
            this.groupBox3.Controls.Add(this.btnFrm9);
            this.groupBox3.Controls.Add(this.btnFrm4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 702);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1266, 60);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(633, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 35);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(70, 27);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(41, 12);
            this.label222.TabIndex = 20;
            this.label222.Text = "未登录";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(12, 27);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(65, 12);
            this.label111.TabIndex = 19;
            this.label111.Text = "登录状态：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 762);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGetlist);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "直播系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapt;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetlist;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnFrm1;
        private System.Windows.Forms.Button btnFrm4;
        private System.Windows.Forms.Button btnFrm9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Button btnRefresh;
    }
}

