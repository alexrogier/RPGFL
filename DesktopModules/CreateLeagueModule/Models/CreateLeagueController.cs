using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.CreateLeagueModule.Models
{
    public class CreateLeagueController
    {
        public int CreateNewLeague(string League_Name, string League_Description, bool Join_Allow_Anyone, int? Creator_User_FK,
                                    bool Trade_Day_Enabled, bool Randomize_Enabled, int Game_Mode, int League_Duration,
                                    bool Renew_Duration, string League_Icon, bool System_Public = false)
        {
            // create league and return PK of newly created league
            return CBO.FillCollection<NewLeague>(DataProvider.Instance().ExecuteReader("RPGFL_CreateNewLeague",
                                                    League_Name, League_Description, Join_Allow_Anyone, Creator_User_FK, Trade_Day_Enabled,
                                                    Randomize_Enabled, Game_Mode, League_Duration, Renew_Duration, League_Icon, System_Public)
                                                )[0].League_PK;
        }

        public void SendEmails(string Emails, int League_PK)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("alexrogier.webit@gmail.com", "rerout11");

            List<string> listOfEmails = Emails.Split(',').ToList();
            foreach (var email in listOfEmails)
            {
                if (email.Contains("@"))
                {
                    MailMessage mm = new MailMessage
                    {
                        From = new MailAddress("alexrogier.webit@gmail.com", "RPGFL"),
                        Subject = "RPGFL League Invitation",
                        BodyEncoding = UTF8Encoding.UTF8,
                        IsBodyHtml = true,
                        DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                    };

                    mm.To.Add(new MailAddress(email, email));
                    var token = CBO.FillCollection<EmailInvite>(DataProvider.Instance().ExecuteReader("RPGFL_CreateEmailInvite", email, League_PK))[0].Token;
                    mm.Body = "You have been invited to join a RPGFL League! <a href=\"http://localhost:31658/RPGFLHome/token?token=" + token + "&email=" + email + "\">Click here</a> to accept the invitation.";
                    client.Send(mm);
                }
            }
        }
    }
}