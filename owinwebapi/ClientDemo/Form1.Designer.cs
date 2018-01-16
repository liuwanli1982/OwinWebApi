namespace ClientDemo
{
    partial class Form1
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
            this.but_runAPI = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.bu_WebService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_runAPI
            // 
            this.but_runAPI.Location = new System.Drawing.Point(786, 41);
            this.but_runAPI.Name = "but_runAPI";
            this.but_runAPI.Size = new System.Drawing.Size(75, 23);
            this.but_runAPI.TabIndex = 0;
            this.but_runAPI.Text = "调用API";
            this.but_runAPI.UseVisualStyleBackColor = true;
            this.but_runAPI.Click += new System.EventHandler(this.but_runAPI_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(74, 41);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(572, 403);
            this.txt_result.TabIndex = 1;
            // 
            // bu_WebService
            // 
            this.bu_WebService.Location = new System.Drawing.Point(786, 178);
            this.bu_WebService.Name = "bu_WebService";
            this.bu_WebService.Size = new System.Drawing.Size(104, 23);
            this.bu_WebService.TabIndex = 2;
            this.bu_WebService.Text = "调用WebService";
            this.bu_WebService.UseVisualStyleBackColor = true;
            this.bu_WebService.Click += new System.EventHandler(this.bu_WebService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 593);
            this.Controls.Add(this.bu_WebService);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.but_runAPI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_runAPI;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button bu_WebService;
    }
}

