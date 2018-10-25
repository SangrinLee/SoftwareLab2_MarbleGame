namespace _60
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.state_text = new System.Windows.Forms.TextBox();
            this.send_text = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.multi4_mode = new System.Windows.Forms.RadioButton();
            this.btn_Server = new System.Windows.Forms.Button();
            this.multi3_mode = new System.Windows.Forms.RadioButton();
            this.multi2_mode = new System.Windows.Forms.RadioButton();
            this.single_mode = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chat_text = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // state_text
            // 
            this.state_text.Location = new System.Drawing.Point(19, 24);
            this.state_text.Multiline = true;
            this.state_text.Name = "state_text";
            this.state_text.Size = new System.Drawing.Size(289, 169);
            this.state_text.TabIndex = 5;
            // 
            // send_text
            // 
            this.send_text.Location = new System.Drawing.Point(13, 24);
            this.send_text.Name = "send_text";
            this.send_text.Size = new System.Drawing.Size(179, 25);
            this.send_text.TabIndex = 7;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(35, 64);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(143, 36);
            this.btn_Send.TabIndex = 9;
            this.btn_Send.Text = "전송(ToClient)";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.multi4_mode);
            this.groupBox2.Controls.Add(this.btn_Server);
            this.groupBox2.Controls.Add(this.multi3_mode);
            this.groupBox2.Controls.Add(this.multi2_mode);
            this.groupBox2.Controls.Add(this.single_mode);
            this.groupBox2.Location = new System.Drawing.Point(30, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 212);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "플레이어 설정";
            // 
            // multi4_mode
            // 
            this.multi4_mode.AutoSize = true;
            this.multi4_mode.Location = new System.Drawing.Point(38, 119);
            this.multi4_mode.Name = "multi4_mode";
            this.multi4_mode.Size = new System.Drawing.Size(123, 19);
            this.multi4_mode.TabIndex = 3;
            this.multi4_mode.Text = "멀티모드(4명)";
            this.multi4_mode.UseVisualStyleBackColor = true;
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(27, 157);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(143, 36);
            this.btn_Server.TabIndex = 1;
            this.btn_Server.Text = "서버 켜기";
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Click += new System.EventHandler(this.button1_Click);
            // 
            // multi3_mode
            // 
            this.multi3_mode.AutoSize = true;
            this.multi3_mode.Location = new System.Drawing.Point(38, 92);
            this.multi3_mode.Name = "multi3_mode";
            this.multi3_mode.Size = new System.Drawing.Size(123, 19);
            this.multi3_mode.TabIndex = 2;
            this.multi3_mode.Text = "멀티모드(3명)";
            this.multi3_mode.UseVisualStyleBackColor = true;
            // 
            // multi2_mode
            // 
            this.multi2_mode.AutoSize = true;
            this.multi2_mode.Checked = true;
            this.multi2_mode.Location = new System.Drawing.Point(38, 67);
            this.multi2_mode.Name = "multi2_mode";
            this.multi2_mode.Size = new System.Drawing.Size(123, 19);
            this.multi2_mode.TabIndex = 1;
            this.multi2_mode.TabStop = true;
            this.multi2_mode.Text = "멀티모드(2명)";
            this.multi2_mode.UseVisualStyleBackColor = true;
            // 
            // single_mode
            // 
            this.single_mode.AutoSize = true;
            this.single_mode.Location = new System.Drawing.Point(38, 39);
            this.single_mode.Name = "single_mode";
            this.single_mode.Size = new System.Drawing.Size(123, 19);
            this.single_mode.TabIndex = 0;
            this.single_mode.Text = "싱글모드(1명)";
            this.single_mode.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(50, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "프로그램 종료";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.state_text);
            this.groupBox1.Location = new System.Drawing.Point(248, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 212);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "오퍼레이터 상황";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.chat_text);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(30, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(548, 224);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "메시지 큐";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.send_text);
            this.groupBox4.Controls.Add(this.btn_Send);
            this.groupBox4.Location = new System.Drawing.Point(15, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(207, 117);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "서버 알림(전체 메시지)";
            // 
            // chat_text
            // 
            this.chat_text.Location = new System.Drawing.Point(237, 34);
            this.chat_text.Multiline = true;
            this.chat_text.Name = "chat_text";
            this.chat_text.Size = new System.Drawing.Size(289, 173);
            this.chat_text.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 511);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "서버";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox state_text;
        private System.Windows.Forms.TextBox send_text;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton multi4_mode;
        private System.Windows.Forms.Button btn_Server;
        private System.Windows.Forms.RadioButton multi3_mode;
        private System.Windows.Forms.RadioButton multi2_mode;
        private System.Windows.Forms.RadioButton single_mode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox chat_text;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

