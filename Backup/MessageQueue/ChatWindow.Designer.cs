using System.Windows.Forms;
namespace MessageQueueDemo
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtMsg = new TextBox();
            this.TxtSend = new TextBox();
            this.BtnSend = new Button();
            this.lblreceived = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtYourName = new TextBox();
            this.ConB_SendTo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TxtMsg
            // 
            // 
            // 
            // 
           
            this.TxtMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtMsg.Location = new System.Drawing.Point(0, 0);
            this.TxtMsg.Multiline = true;
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMsg.Size = new System.Drawing.Size(245, 282);
            this.TxtMsg.TabIndex = 10;
            // 
            // TxtSend
            // 
            // 
            // 
            // 
            
            this.TxtSend.Location = new System.Drawing.Point(0, 288);
            this.TxtSend.Multiline = true;
            this.TxtSend.Name = "TxtSend";
            this.TxtSend.Size = new System.Drawing.Size(245, 27);
            this.TxtSend.TabIndex = 0;
            // 
            // BtnSend
            // 
            this.BtnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSend.Location = new System.Drawing.Point(77, 321);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(75, 23);
            this.BtnSend.TabIndex = 1;
            this.BtnSend.Text = "Send";
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // lblreceived
            // 
            this.lblreceived.AutoSize = true;
            this.lblreceived.Location = new System.Drawing.Point(-3, 407);
            this.lblreceived.Name = "lblreceived";
            this.lblreceived.Size = new System.Drawing.Size(0, 13);
            this.lblreceived.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Send to      : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Your Name : ";
            // 
            // TxtYourName
            // 
            // 
            // 
            // 
           
            this.TxtYourName.Location = new System.Drawing.Point(88, 387);
            this.TxtYourName.Name = "TxtYourName";
            this.TxtYourName.Size = new System.Drawing.Size(131, 20);
            this.TxtYourName.TabIndex = 14;
            // 
            // ConB_SendTo
            // 
            this.ConB_SendTo.FormattingEnabled = true;
            this.ConB_SendTo.Location = new System.Drawing.Point(88, 360);
            this.ConB_SendTo.Name = "ConB_SendTo";
            this.ConB_SendTo.Size = new System.Drawing.Size(131, 21);
            this.ConB_SendTo.TabIndex = 15;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 415);
            this.Controls.Add(this.ConB_SendTo);
            this.Controls.Add(this.TxtYourName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblreceived);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtSend);
            this.Controls.Add(this.TxtMsg);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_FormClosed);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TxtMsg;
        private TextBox TxtSend;
        private Button BtnSend;
        private System.Windows.Forms.Label lblreceived;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TextBox TxtYourName;
        private System.Windows.Forms.ComboBox ConB_SendTo;
    }
}