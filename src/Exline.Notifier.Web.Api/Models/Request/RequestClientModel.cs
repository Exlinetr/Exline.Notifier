
namespace Exline.Notifier.Web.Api.Models.Request
{
    public class RequestClientModel
    {
        public string Token { get; set; }
        public DeviceType DeviceType { get; set; }

        public Core.Services.Models.Client ToClient()
        {
            return new Core.Services.Models.Client(Token, DeviceType);
        }
    }
}
