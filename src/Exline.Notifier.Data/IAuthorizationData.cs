using Exline.Notifier.Data.Collections;

namespace Exline.Notifier.Data
{
    public interface IAuthorizationData:IData
    {
        Result Insert(AuthorizeCollection authorizeCollection);
        string GetApplicationIdByApiKey(string apiKey);
        string GetApplicationIdByToken(string token);

        Result RemoveFromExpiredToken(string applicationId);
        
    }
}