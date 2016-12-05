using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

//Option Strict Off
//Option Explicit On
public class Param_Generic
{

    public string coda;
    public string path_file;
   
    private Ini_Handler my_inihndle = new Ini_Handler();
    private void Class_Initialize_Renamed()
    {
        coda = "chat";
        path_file = "001";
        
    }
    public Param_Generic()
        : base()
    {
        Class_Initialize_Renamed();
    }
    public bool get_ini()
    {
       
        coda = my_inihndle.INI_leggi("Generale", "coda", "chat_recive");
        path_file = my_inihndle.INI_leggi("Generale", "percorso_audio_Cassa", "");
          bool get_ini = true;
        return get_ini;
    error_handler:

         return false;
    }
}

