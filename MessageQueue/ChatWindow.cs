using System;
using System.Data;
using System.Windows.Forms;
using System.Messaging;
using System.Threading;

namespace MessageQueueDemo
{ 
    
    public partial class ChatWindow : Form
    {
      
        public MSMQ.MSMQQueue QQUEUE_Renamed;
        public MSMQ.MSMQMessage qMessage;
        public MSMQ.MSMQQueueInfo qInfo = new MSMQ.MSMQQueueInfo();
        public MSMQ.MSMQQueue emess;
        public MSMQ.MSMQEvent qEvent;
        
        public static Param_Database par_db = new Param_Database();
        public static Param_Logger par_logger = new Param_Logger();
        public static Param_Generic par_general = new Param_Generic();
       
      
        
       
        string ServerName = "";
        string dest = "";
        public ChatWindow()
        {
            InitializeComponent();
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            try
            {
               
                par_db.get_ini();
                par_general.get_ini();
                
                
              
                Db_Handler myconn = new Db_Handler();

                myconn.OpenDB();
                IDbCommand dbcmd = myconn.dbcon.CreateCommand();
                object v = null;
                
                this.Controls.Add(TxtSend);


                string strSQL = " select * from chat_frasi ;";
                    dbcmd.CommandText = strSQL;
                    IDataReader reader = dbcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        v = reader["descrizione"];
                        comboBox1.Items.Add(Convert.ToString(v));
                    }
                
                TxtSend.KeyPress += new KeyPressEventHandler(keypressed);
                
                TxtSend.Focus();
                      MessageQueue myQueue = new MessageQueue(".\\private$\\"+ par_general.coda);
                      myQueue.Purge();
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

                // Add an event handler for the ReceiveCompleted event.
                myQueue.ReceiveCompleted += new
                    ReceiveCompletedEventHandler(MyReceiveCompleted);

                // Begin the asynchronous receive operation.
                myQueue.BeginReceive();

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Start Thread which will keep track on incoming messages.
            Thread th = new Thread(GetMesqueue);
            th.Start();
        }
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                //The code for Sending message.
                try
                {
                    MessageQueue msgQ_Send = new MessageQueue();

                    if (ConB_SendTo.Text != "")
                    {
                       
                        msgQ_Send.Path = "FORMATNAME:Direct=TCP:" + dest + "\\private$\\" + par_general.coda;

                    }

                    else
                    {
                        
                        msgQ_Send.Path = "FORMATNAME:Direct=TCP:" + dest + "\\private$\\" + par_general.coda;
                    }

                    //Send all information that u want, along with the message
                    RequestInformation objMsg = new RequestInformation();
                    objMsg.Name = TxtYourName.Text;
                    objMsg.Message = TxtSend.Text;

                    //Bind your message with Message Class.
                    System.Messaging.Message m = new System.Messaging.Message();
                    m.Body = TxtSend.Text;
                    
                    msgQ_Send.Send(m);
                   
                    TxtMsg.Text +=  Environment.MachineName + ": " + TxtSend.Text + "\r\n";

                    TxtSend.Text = "";
                    TxtMsg.SelectionStart = TxtMsg.Text.Length;
                    TxtMsg.ScrollToCaret();
                    TxtSend.Focus();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public  void MyReceiveCompleted(Object source,
            ReceiveCompletedEventArgs asyncResult)
        {
            // Connect to the queue.
            MessageQueue mq = (MessageQueue)source;
            this.TopMost = true;
            // End the asynchronous Receive operation.
            System.Messaging.Message m = mq.EndReceive(asyncResult.AsyncResult);

           
            try
            {
                string mess = null;
                mess = m.Body.ToString();
                string[] words = mess.Split('@');

                //string str()= new string();
                if (words[4] == "True")
                {
                    this.ConB_SendTo.Items.Add(words[2] + words[3]);
                    TxtMsg.Text = TxtMsg.Text + words[2] + words[3] + ": Start chat...\r\n";
                    this.ConB_SendTo.Enabled = true;
                    goto goout;
                }
                else if (words[4] == "False")
                {
                   
                    int i = 0;
                    while (i <= this.ConB_SendTo.Controls.Count)
                    {
                        
                           i= this.ConB_SendTo.Items.IndexOf(words[2] + words[3]);
                           this.ConB_SendTo.Items.Remove(words[2] + words[3]);
                        i=i+1 ;
                    }
                    TxtMsg.Text = TxtMsg.Text + words[2] + words[3] + ": End chat...\r\n";
                    if (this.ConB_SendTo.Items.Count == 0)
                    {
                        this.ConB_SendTo.Items.Clear();
                        this.ConB_SendTo.Enabled = false;
                    }
                    goto goout;
                }
                TxtMsg.Text = TxtMsg.Text + words[0] + "\r\n" + words[2] + words[3] + ":";
                TxtMsg.Text = TxtMsg.Text + words[4] + "\r\n";
                TxtMsg.SelectionStart = TxtMsg.Text.Length;
                TxtMsg.ScrollToCaret();
                this.ConB_SendTo.Text = words[2] + words[3]  ;
                dest = words[1];
                BtnSend.Enabled = true;
                string path = par_general.path_file;
                playSound(path);
              
            }
           
         
            catch
            {
                mq.BeginReceive();
            }
  goout:          mq.BeginReceive();
            this.TopMost = false;
            TxtMsg.SelectionStart = TxtMsg.Text.Length;
            TxtMsg.ScrollToCaret();
            TxtSend.Focus();
            return;
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
           
            try
            {
                MessageQueue msgQ_Send = new MessageQueue();

                if (ConB_SendTo.Text != "")
                {
                    
                    msgQ_Send.Path = "FORMATNAME:Direct=TCP:" + dest + "\\private$\\"+ par_general.coda;
               
                }

                else
                {
                   
                    msgQ_Send.Path = "FORMATNAME:Direct=TCP:" + dest + "\\private$\\" + par_general.coda;
                }

                //Send all information that u want, along with the message
                RequestInformation objMsg = new RequestInformation();
                objMsg.Name = TxtYourName.Text;
                objMsg.Message = TxtSend.Text;

                //Bind your message with Message Class.
                System.Messaging.Message m = new System.Messaging.Message();
                m.Body = TxtSend.Text;
               
                msgQ_Send.Send(m);
             
                TxtMsg.Text +=  Environment.MachineName + ": " + TxtSend.Text +"\r\n";

                TxtSend.Text = "";
                TxtMsg.SelectionStart = TxtMsg.Text.Length;
                TxtMsg.ScrollToCaret();
                TxtSend.Focus();

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
                    //if (!MessageQueue.Exists(ServerName + @"\" + Environment.MachineName))
                    if (!MessageQueue.Exists(ServerName + @"\" + par_general.coda))
                   
                    {
                        MessageQueue.Create(ServerName + @"\" + par_general.coda);
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
                        //MessageBox.Show(ex.Message, "Error");
                        break;
                    }
                }
            }
        }

        private void playSound(string path)
        {
            System.Media.SoundPlayer player =
            new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }

        private void qEvent_Arrived(object q, int Cursor_Renamed)
        {
            
            bool blnEsito = false;
            bool blnINI = false;
            string strEsito = null;
            MSMQ.MSMQQueue qArrive = default(MSMQ.MSMQQueue);
            bool bOk = false;
            object a = new object();
            object b = new object();
            qArrive = (MSMQ.MSMQQueue)q; 
          
        }
        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtSend.Text = TxtSend.Text + comboBox1.SelectedItem.ToString() + "\r\n ";
          
        }
    }
}
    