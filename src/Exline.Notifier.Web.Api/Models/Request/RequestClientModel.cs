
namespace Exline.Notifier.Web.Api.Models.Request
{
    public class RequestClientModel
    {
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceOS{get;set;}
        public string Language { get; set; }
        //public double[] Location { get; set; }
        public double Latitude {get;set;}
        public double Longitude {get;set;}

        public Core.Services.Models.Client ToClient()
        {
            return new Core.Services.Models.Client(Token, DeviceType);
        }
    }
}
