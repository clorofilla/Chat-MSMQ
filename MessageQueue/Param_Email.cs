using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
public class Param_Email
{

    bool invia_email = false;
    string lista_indirizzi_email = null;
    string password = null;
    string port = null;
    string user_name = null;
    string oggetto = null;
    string smtp1 = null;
    string indirizzo_mittente = null;
    string nome_mittente = null;
    string Host = null;
    private Ini_Handler my_inihndle = new Ini_Handler();
    private MailMessage mail;
    public bool get_ini()
    {
        bool functionReturnValue = false;
       
        int i = 0;

        indirizzo_mittente = my_inihndle.INI_leggi("Email", "indirizzo_mittente", "");
        invia_email = Convert.ToBoolean(my_inihndle.INI_leggi("Email", "invia_email", "false"));
        lista_indirizzi_email = my_inihndle.INI_leggi("Email", "lista_indirizzi_email", "");
        nome_mittente = my_inihndle.INI_leggi("Email", "nome_mittente", "");
        oggetto = my_inihndle.INI_leggi("Email", "pw", "oggetto");
        smtp1 = my_inihndle.INI_leggi("Email", "smtp", "");
        user_name = my_inihndle.INI_leggi("Email", "user_name", "");
        password = my_inihndle.INI_leggi("Email", "password", "");
        port = my_inihndle.INI_leggi("Email", "porta", "");
        Host = my_inihndle.INI_leggi("Email", "Host", "");
        functionReturnValue = true;
        return functionReturnValue;
       
    }


    public  bool Send_email(string sql)
{

	MailAddress destinatario = null;
	string[] lista_destinatari = null;
	int i = 0;

	if ((invia_email == false))
		return true;
	if ((string.IsNullOrEmpty(lista_indirizzi_email)))
		return true;
	if ((string.IsNullOrEmpty(user_name)))
		return true;
	if ((string.IsNullOrEmpty(password)))
		return true;

	try {
		mail = new MailMessage();

		MailAddress mittente = new MailAddress(indirizzo_mittente, nome_mittente);
		mail.From = mittente;

        //lista_destinatari = Strings.Split(lista_indirizzi_email, ",",-1, CompareMethod.Binary);
        lista_destinatari = lista_indirizzi_email.Split(',');
        for (i = 0; i <= (lista_destinatari.Length - 1); i++) {
			if (((destinatario == null) == false))
				destinatario = null;
			if (((destinatario == null) == true))
				destinatario = new MailAddress(lista_destinatari[i]);
			mail.To.Add(destinatario);
			if (((destinatario == null) == false))
				destinatario = null;
		}

		mail.Subject = oggetto + ":SMARTCITY ANOMALIA";
    
        mail.Body =  "Possibile problema **** " + sql + "****";


		SmtpClient smtp = new SmtpClient(smtp1);

		//Dim smtp1 As New Smtp


		smtp.Credentials = new System.Net.NetworkCredential(user_name, password);
		smtp.UseDefaultCredentials = false;
		//smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
        smtp.EnableSsl = true;
        
        smtp.Host = Host;
        smtp.Port = Convert.ToInt32(port);
		//scommentare quando si mettera sul server perché senno non manda la mail forse!!!!
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        
        //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;

        //smtp.SendCompleted +=  invio_completato;
         smtp.SendCompleted +=  SmtpClient_OnCompleted;
         ServicePointManager.ServerCertificateValidationCallback =
         delegate(object s, X509Certificate certificate, X509Chain chant,
         SslPolicyErrors error)
        {
            return true;
            };
        object Token = new object();
		//smtp.Send(mail);

		return true;


	} catch (SmtpException ex) {
		mail.To.Clear();
		mail.Attachments.Clear();
		mail.Dispose();
		return false;
	}

}
    //private void invio_completato(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    //{
    //    object Token = e.UserState;

    //    if (e.Cancelled)
    //    {
    //        alarm_was_set_z1_mail = alarm_was_set_z0_mail;
    //    }

    //    if (e.Error != null)
    //    {
    //    }
    //    else
    //    {
    //        alarm_was_set_z1_mail = alarm_was_set_z0_mail;
    //    }

    //    mail.To.Clear();
    //    mail.Attachments.Clear();
    //    mail.Dispose();
    //}
    private void SmtpClient_OnCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        //Get the Original MailMessage object
        //MailMessage mail = (MailMessage)e.UserState;

        //write out the subject
        string subject = mail.Subject;

        if (e.Cancelled)
        {
            Console.WriteLine("Send canceled for mail with subject [{0}].", subject);
        }
        if (e.Error != null)
        {
            Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
        }
        else
        {
            Console.WriteLine("Message [{0}] sent.", subject);
        }

    }

}
