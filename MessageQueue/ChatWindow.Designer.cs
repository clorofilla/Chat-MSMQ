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
            this.TxtMsg = new System.Windows.Forms.TextBox();
            this.TxtSend = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.lblreceived = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtYourName = new System.Windows.Forms.TextBox();
            this.ConB_SendTo = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtMsg
            // 
            this.TxtMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TxtMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtMsg.Font = new System.Drawing.Font("Arial Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMsg.HideSelection = false;
            this.TxtMsg.Location = new System.Drawing.Point(0, 0);
            this.TxtMsg.Multiline = true;
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.ReadOnly = true;
            this.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtMsg.Size = new System.Drawing.Size(443, 196);
            this.TxtMsg.TabIndex = 10;
            // 
            // TxtSend
            // 
            this.TxtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtSend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSend.Location = new System.Drawing.Point(0, 202);
            this.TxtSend.Multiline = true;
            this.TxtSend.Name = "TxtSend";
            this.TxtSend.Size = new System.Drawing.Size(443, 113);
            this.TxtSend.TabIndex = 0;
            // 
            // BtnSend
            // 
            this.BtnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSend.Enabled = false;
            this.BtnSend.Location = new System.Drawing.Point(129, 321);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(188, 23);
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
            this.label1.Location = new System.Drawing.Point(11, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Send to : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Your Name : ";
            // 
            // TxtYourName
            // 
            this.TxtYourName.Enabled = false;
            this.TxtYourName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtYourName.Location = new System.Drawing.Point(88, 414);
            this.TxtYourName.Name = "TxtYourName";
            this.TxtYourName.Size = new System.Drawing.Size(194, 21);
            this.TxtYourName.TabIndex = 14;
            this.TxtYourName.Text = "name";
            // 
            // ConB_SendTo
            // 
            this.ConB_SendTo.Enabled = false;
            this.ConB_SendTo.FormattingEnabled = true;
            this.ConB_SendTo.Location = new System.Drawing.Point(58, 385);
            this.ConB_SendTo.Name = "ConB_SendTo";
            this.ConB_SendTo.Size = new System.Drawing.Size(373, 21);
            this.ConB_SendTo.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 358);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sentences : ";
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 448);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConB_SendTo);
            this.Controls.Add(this.TxtYourName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblreceived);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtSend);
            this.Controls.Add(this.TxtMsg);
            this.Name = "ChatWindow";
            this.Text = "CityChat";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_FormClosed);
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
        private ComboBox comboBox1;
        private Label label3;
    }
}