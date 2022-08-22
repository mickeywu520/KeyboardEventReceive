namespace KeyboardEventReceive
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2_PORT = new System.Windows.Forms.TextBox();
            this.button1_startService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1_IP
            // 
            this.textBox1_IP.Location = new System.Drawing.Point(395, 149);
            this.textBox1_IP.Name = "textBox1_IP";
            this.textBox1_IP.Size = new System.Drawing.Size(227, 36);
            this.textBox1_IP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // textBox2_PORT
            // 
            this.textBox2_PORT.Location = new System.Drawing.Point(395, 202);
            this.textBox2_PORT.Name = "textBox2_PORT";
            this.textBox2_PORT.Size = new System.Drawing.Size(227, 36);
            this.textBox2_PORT.TabIndex = 2;
            // 
            // button1_startService
            // 
            this.button1_startService.Location = new System.Drawing.Point(298, 258);
            this.button1_startService.Name = "button1_startService";
            this.button1_startService.Size = new System.Drawing.Size(324, 41);
            this.button1_startService.TabIndex = 4;
            this.button1_startService.Text = "Start";
            this.button1_startService.UseVisualStyleBackColor = true;
            this.button1_startService.Click += new System.EventHandler(this.button1_startService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1_startService);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2_PORT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2_PORT;
        private System.Windows.Forms.Button button1_startService;
    }
}

