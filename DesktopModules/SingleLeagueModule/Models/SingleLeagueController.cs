using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.SingleLeagueModule.Models
{
    public class SingleLeagueController
    {
        #region Get Operations
        public IList<League> GetSingleLeagueData(int FILTER_leaguefk)
        {
            return CBO.FillCollection<League>(DataProvider.Instance().ExecuteReader("RPGFL_GetSingleLeagueData", FILTER_leaguefk));
        }

        public IList<LeagueUsers> GetLeagueUsers(int FILTER_leaguefk)
        {
            return CBO.FillCollection<LeagueUsers>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagueUsers", FILTER_leaguefk));
        }

        public int GetLeagueCountByUser(int FILTER_userfk)
        {
            return CBO.FillCollection<int>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagueCountByUser", FILTER_userfk))[0];
        }

        public IList<Character> GetCharacterDraftByLeague(int FILTER_userfk, int FILTER_leaguefk)
        {
            return CBO.FillCollection<Character>(DataProvider.Instance().ExecuteReader("RPGFL_GetCharacterDraftByLeague", FILTER_userfk, FILTER_leaguefk));
        }
        #endregion

        #region Delete Operations
        public void DeleteUserFromLeague(int FILTER_leaguefk, int FILTER_userfk, bool bLeagueOwner)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_DeleteUserFromLeague", FILTER_leaguefk, FILTER_userfk, bLeagueOwner);
        }
        #endregion

        #region Insert Operations
        public void InsertUserInLeague(int FILTER_leaguefk, int FILTER_userfk)
        {
            DataProvider.Instance().ExecuteReader("RPGFL_InsertUserInLeague", FILTER_leaguefk, FILTER_userfk);
        }

        public bool InviteEmailsByUser(string Emails, int User_PK, int League_PK)
        {
            var leagues = CBO.FillCollection<League>(DataProvider.Instance().ExecuteReader("RPGFL_GetLeagueByUser", User_PK));
            foreach (var league in leagues)
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
            return true;
        }
        #endregion
    }
}