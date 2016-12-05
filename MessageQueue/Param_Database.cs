using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

public class Param_Database
{

    //Nome server
    public string name_server;
    //Nome driver
    public string database_driver;
    //Nome database nel server
    public string database_name;
    //Uname
    public string user_name;
    //Psw
    public string user_pass;
    //Nr of retry to the database
    public short database_retry;
    public short database_pollminutes_dt;
    //------------------------------------------------------------------------------
    private Ini_Handler my_inihndle = new Ini_Handler();
    //UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    private void Class_Initialize_Renamed()
    {
        name_server = "127.0.0.1";
        database_driver = "{MySQL ODBC 5.1 Driver}";
        database_name = "web2park";
        user_name = "root";
        user_pass = "";
        database_retry = 3;
        database_pollminutes_dt = 0;
        //Not used in this context
    }
    public Param_Database()
        : base()
    {
        Class_Initialize_Renamed();
    }
    public bool get_ini()
    {
        
        database_driver = my_inihndle.INI_leggi("Database", "Driver", "{MySQL ODBC 3.51 Driver}");
        database_name = my_inihndle.INI_leggi("Database", "Database", "web2park");
        name_server = my_inihndle.INI_leggi("Database", "Server", "127.0.0.1");
        user_name = my_inihndle.INI_leggi("Database", "User", "root");
        user_pass = my_inihndle.INI_leggi("Database", "Password", "");
        bool get_ini = true;
        return get_ini;
    error_handler:
        return false;
    }
}


