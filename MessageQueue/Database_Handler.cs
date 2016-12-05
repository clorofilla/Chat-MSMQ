using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

using MySql.Data.MySqlClient;


public class Db_Handler
{

    public IDbConnection dbcon;

    private void Class_Initialize_Renamed()
    {

    }
    public Db_Handler()
        : base()
    {
        Class_Initialize_Renamed();
    }
     
    public bool OpenDB()
    {
        try
        {
            string conntectionstring =
               "Server=" + MessageQueueDemo.ChatWindow.par_db.name_server +
              ";Database=" + MessageQueueDemo.ChatWindow.par_db.database_name +
              ";User ID=" + MessageQueueDemo.ChatWindow.par_db.user_name +
              ";Password=" + MessageQueueDemo.ChatWindow.par_db.user_pass +
              ";Pooling=false";
            dbcon = new MySqlConnection(conntectionstring);
            dbcon.Open();
            bool OpenDB = true;
            return OpenDB;
        }
        catch
        {
            return false;
        }


    }

}