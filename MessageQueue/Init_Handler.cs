using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;

using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
internal class Ini_Handler
{
   //public  Logger_Activex.Log_Handler logger=new Logger_Activex.Log_Handler();
	public static string app_settings="chat.ini";

	 public  MultiplatformIni ini  = new MultiplatformIni(AppDomain.CurrentDomain.BaseDirectory  + app_settings);
	

	private string x;
	private string sEntry;
	private string sSection;
	private string sDefault;
	private string sRetBuf;
	private string sFileName;
	private int iLenBuf;
	private string sValue;
	private string sString;
//UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	private void Class_Initialize_Renamed()
	{
		app_settings = "chat.ini";
	}
	public Ini_Handler() : base()
	{
		Class_Initialize_Renamed();
	}

	public string INI_leggi(string section, string entry, string patch_value )
	{
//        MultiplatformIni ini  = new MultiplatformIni(AppDomain.CurrentDomain.BaseDirectory  + app_settings);
//		MultiplatformIni ini  = new MultiplatformIni();

		String default_Renamed = "";
        bool patch = true;
        sSection = section;
		sEntry = entry;
		sDefault = default_Renamed;
       
        int chars = 256;

		byte[] sRetBuf = new byte[chars];
		iLenBuf =sRetBuf.Length;
      
		x =ini.ReadString(sSection,sEntry,sDefault);
		//x = GetPrivateProfileString(sSection, sEntry, sDefault, sRetBuf, chars, sFileName);
		if (x == "") {
		ini.WriteString(sSection,sEntry,patch_value);
		}
        
        sValue = x.ToString();
        return sValue;


	}
}


//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik, @toddanglin
//Facebook: facebook.com/telerik
//=======================================================
