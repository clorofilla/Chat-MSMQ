using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents;
using System.Messaging;
using System.Threading;
using System.Net.Sockets;

namespace MessageQueueDemo
{
    public partial class ChatWindow : Form
    {
        string Generalqueue = @"kapil\General";
        string ServerName = "kapil";

        public ChatWindow()
        {
            InitializeComponent();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            try
            {
                //List all Message Queue's available.
                MessageQueue[] queues = MessageQueue.GetPublicQueues();
                //Fill combo box with all queues.
                foreach (MessageQueue queue in MessageQueue.GetPublicQueues())
                {
                    ConB_SendTo.Items.Add(queue.Path);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Start Thread which will keep track on incoming messages.
            Thread th = new Thread(GetMesqueue);
            th.Start();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            //The code for Sending message.
            try
            {
                MessageQueue msgQ_Send = new MessageQueue();

                if (ConB_SendTo.Text != "")
                {
                    //Select User to which you want to send message.
                    msgQ_Send.Path = @"FormatName:DIRECT=OS:" + ConB_SendTo.Text;
                }

                else
                {
                    //General queue for sending messages
                    msgQ_Send.Path = @"FormatName:DIRECT=OS:" + Generalqueue;
                }

                //Send all information that u want, along with the message
                RequestInformation objMsg = new RequestInformation();
                objMsg.Name = TxtYourName.Text;
                objMsg.Message = TxtSend.Text;

                //Bind your message with Message Class.
                System.Messaging.Message m = new System.Messaging.Message();
                m.Body = objMsg;
                m.Formatter = new BinaryMessageFormatter();
                m.AppSpecific = 34;

                //sending message along with other information. Second parameter we are passing is called 'LABEL'
                //By which we can send some more information so that one can use it farther for the implimentation
                //of functionality such as filteration of messages.
                msgQ_Send.Send(m, DateTime.Now.ToLongTimeString() + "::" + System.Environment.MachineName);

                //see what message you sent.
                TxtMsg.Text += "\r\n" + Environment.MachineName + ": " + TxtSend.Text;

                TxtSend.Text = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    
        private void GetMesqueue()
        {
            //To avoid cross threading
            CheckForIllegalCrossThreadCalls = false;
            while (true)
            {
                try
                {
                    //If message queue is not in the list then create it on server.
                    if (!MessageQueue.Exists(ServerName + @"\" + Environment.MachineName))
                    {
                        MessageQueue.Create(ServerName + @"\" + Environment.MachineName);
                    }

                    //User can get messages from queue which belongs to his machine name.
                    MessageQueue msgqueue_Get = new MessageQueue();
                    msgqueue_Get.Path = @"FormatName:DIRECT=OS:" + ServerName + @"\" + Environment.MachineName;

                    Type[] target = new Type[1];

                    target[0] = typeof(string);

                    //Time out is 2 seconds.
                    System.Messaging.Message msg = msgqueue_Get.Receive(new TimeSpan(0, 0, 2));

                    //Formatter for deserialization of message 
                    msg.Formatter = new System.Messaging.BinaryMessageFormatter();

                    //Deserialization of a message.
                    RequestInformation info = (RequestInformation)msg.Body;
                  
                    TxtMsg.Text += "\r\n" + info.Name+" : "+info.Message;
                }

                catch (Exception ex)
                {
                    //Check whether Queue is empty? if empty then go farther if not then give a message bax with 
                    //error message.
                    if (ex.Message != "Timeout for the requested operation has expired.")
                    {
                        MessageBox.Show(ex.Message, "Error");
                        break;
                    }
                }
            }
        }

        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            this.Dispose();
        }
    }
}
    