using System;

namespace Exline.Notifier.Core.Services.Models
{
    public class Authorize
    {
        public Authorize()
        {

        }
        internal Authorize(Data.Collections.AuthorizeCollection authorizeCollection)
        {
            Token = authorizeCollection.Token;
            ExpireDate = authorizeCollection.ExpireTime;
        }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}