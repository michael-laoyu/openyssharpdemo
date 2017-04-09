namespace tyysocx
{
    partial class tyysocx
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

            DisposeCamera();//释放所有资源；
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.playboxPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn16 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playboxPanel
            // 
            this.playboxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playboxPanel.Location = new System.Drawing.Point(0, 0);
            this.playboxPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.playboxPanel.Name = "playboxPanel";
            this.playboxPanel.Size = new System.Drawing.Size(458, 439);
            this.playboxPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn9);
            this.panel1.Controls.Add(this.btn16);
            this.panel1.Controls.Add(this.btn4);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 439);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 38);
            this.panel1.TabIndex = 2;
            // 
            // btn9
            // 
            this.btn9.BackgroundImage = global::tyysocx.Properties.Resources.v_9;
            this.btn9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn9.Location = new System.Drawing.Point(121, 1);
            this.btn9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(54, 36);
            this.btn9.TabIndex = 3;
            this.btn9.UseVisualStyleBackColor = true;
            // 
            // btn16
            // 
            this.btn16.BackgroundImage = global::tyysocx.Properties.Resources.v_16;
            this.btn16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn16.Location = new System.Drawing.Point(177, 1);
            this.btn16.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn16.Name = "btn16";
            this.btn16.Size = new System.Drawing.Size(54, 36);
            this.btn16.TabIndex = 2;
            this.btn16.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.BackgroundImage = global::tyysocx.Properties.Resources.v_4;
            this.btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn4.Location = new System.Drawing.Point(65, 1);
            this.btn4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(54, 36);
            this.btn4.TabIndex = 1;
            this.btn4.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.BackgroundImage = global::tyysocx.Properties.Resources.v_1;
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn1.Location = new System.Drawing.Point(9, 1);
            this.btn1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(54, 36);
            this.btn1.TabIndex = 0;
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // tyysocx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playboxPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "tyysocx";
            this.Size = new System.Drawing.Size(458, 477);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel playboxPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn16;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn9;
    }
}
