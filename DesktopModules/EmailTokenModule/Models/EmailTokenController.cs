using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;

namespace Christoc.Modules.EmailTokenModule.Models
{
    public class EmailTokenController
    {
        public bool AttemptLeagueInvitationAcceptance(string Email, string Token)
        {
            var bAccepted = false;

            EmailInvite i = CBO.FillCollection<EmailInvite>(DataProvider.Instance().ExecuteReader("RPGFL_AttemptLeagueInvitationAcceptance", Email, Token))[0];
            if (i != null) bAccepted = true;

            return bAccepted;
        }
    }
}