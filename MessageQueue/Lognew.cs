using Microsoft.VisualBasic;
using System.Diagnostics;
using System;
using System.IO;
using System.Text;


public static class Lognew
{

    public struct LLOG_PATHS
    {
        public string strDefault;
        public string strDebug;
        public string strAperture;
    }
    //Percorsi dei 3 file di log
    public static LLOG_PATHS Log_path;

    public struct LLOG_LEVELS
    {
        public int intDefault;
        public int intDebug;
        public int intAperture;
    }
    //Livelli di debug dei 3 file
    public static LLOG_LEVELS Log_livello;
    //public appl ini = new MultiplatformIni(AppDomain.CurrentDomain.BaseDirectory + app_settings);

    public static void Log_scrivi(string Log_time, string Log_string)
    {
        int i_file = 0;
        //Log_path.strDebug = "D:\\Logs\\FTP_server\\FTP_server_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
        //Log_path.strDebug = Global_VAR.par_logger.log_folder +" \\" + Global_VAR.par_logger.log_name + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
        Log_path.strDebug = MessageQueueDemo.ChatWindow.par_logger.log_folder + MessageQueueDemo.ChatWindow.par_logger.log_name + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
        if (!File.Exists(MessageQueueDemo.ChatWindow.par_logger.log_folder + MessageQueueDemo.ChatWindow.par_logger.log_name + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
        {
            Log_path.strDebug = MessageQueueDemo.ChatWindow.par_logger.log_folder + MessageQueueDemo.ChatWindow.par_logger.log_name + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
            using (FileStream fs = File.Create(Log_path.strDebug))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file." + "\n");

                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
        try
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(Log_path.strDebug, true);


            file.WriteLine(Log_time + "  " + Log_string + "\n");

            file.Close();
        }
        catch { }
    }
        // ERROR: Not supported in C#: OnErrorStatement
        //if (!File.Exists("D:\\Logs\\FTP_server\\FTP_server_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
        //{
        //    Log_path.strDebug = "D:\\Logs\\FTP_server\\FTP_server_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
        //    using (FileStream fs = File.Create(Log_path.strDebug))
        //    {
        //        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

        //        // Add some information to the file.
        //        fs.Write(info, 0, info.Length);
        //    }
        //}
    //    if (Log_path.strDebug == null)
    //    {
    //         //Log_path.strDebug = Ini_Handler.app_settings."D:\\Logs\\FTP_server\\FTP_server_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
    //        return;
    //    //Global_VAR.par_logger.log_folder
    //    }
    //    if (!File.Exists(Global_VAR.par_logger.log_folder + Global_VAR.par_logger.log_name + ".txt")) ;
    //    {
    //        Log_path.strDebug = Global_VAR.par_logger.log_folder ;
    //        using (FileStream fs = File.Create(Log_path.strDebug + Global_VAR.par_logger.log_name + ".txt" ))
    //        {
    //            Byte[] info = new UTF8Encoding(true).GetBytes("start");

    //             //Add some information to the file.
    //            fs.Write(info, 0, info.Length);
    //        }
    //    }
    //    try
    //    {
    //        System.IO.StreamWriter file = new System.IO.StreamWriter(Log_path.strDebug + Global_VAR.par_logger.log_name + ".txt", true);
    //        //Byte[] info = new UTF8Encoding(true).GetBytes(Log_time + "  " + Log_string);
    //        //file.Write(info, 0, info.Length);
    //        file.WriteLine(Log_time + "  " + Log_string);

    //        file.Close();
    //    }
    //    catch { }
    //}



    //public static void Log_debug(string Log_time, string Log_string)
    //{
    //    int i_file = 0;
    //    // ERROR: Not supported in C#: OnErrorStatement

    //    //i_file = FreeFile;
    //    FileSystem.FileClose(i_file);
    //    FileSystem.FileOpen(i_file, Log_path.strDebug, OpenMode.Append, OpenAccess.Default, OpenShare.Default, 10);
    //    using (FileStream fs = File.Open(Log_path.strDebug, FileMode.Open, FileAccess.Write, FileShare.None))

    //        FileSystem.PrintLine(i_file, Log_time, Log_string);
    //    FileSystem.FileClose(i_file);
    //    //if ((Information.Err().Number != 0))
    //    //	Information.Err().Clear();
    //}
}