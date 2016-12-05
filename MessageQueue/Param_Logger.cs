using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

// ERROR: Not supported in C#: OptionDeclaration
public class Param_Logger
{

    public string log_folder;
    public string log_pos_folder;
    public string log_format;
    public string log_name;
    public string log_name1;
    public int index = 0;
    public short log_rotation;
    public short log_righe;
    public short log_pos_rotation;
    public bool log_network_enabled;
    public string log_network_destaddr;

    public string log_network_destport;
    private Ini_Handler my_inihndle = new Ini_Handler();
    public bool get_ini()
    {
       
        int i = 0;
        log_folder = my_inihndle.INI_leggi("Log", "log_path", System.Reflection.Assembly.GetExecutingAssembly().Location);
        log_pos_folder = my_inihndle.INI_leggi("Log", "log_pos_folder", System.Reflection.Assembly.GetExecutingAssembly().Location);
        log_format = my_inihndle.INI_leggi("Log", "log_format", "yyyy_MM_dd");
        log_name = my_inihndle.INI_leggi("Log", "log_name", "cassa");
        log_name1 = log_name;
       
      bool  get_ini = true;
      return get_ini;
    error_handler:

        return false;
    }
}

