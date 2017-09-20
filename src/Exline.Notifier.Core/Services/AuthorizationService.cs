namespace Exline.Notifier.Core.Services
{
    public class AuthorizationService : BaseService
    {
        public AuthorizationService(Config config)
        : base(config)
        {
        }

        public Result TokenCheck(string applicationId, string token, string requestIp)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrWhiteSpace(applicationId))
                {
                    result.Unauthorized();
                    return result;
                }
                if (string.IsNullOrWhiteSpace(token))
                {
                    result.Unauthorized();
                    return result;
                }
                Data.IAuthorizationData authorizationData = new Data.DataFactory<Data.IAuthorizationData>(Config).Create();
                string dbApplicationId = authorizationData.GetApplicationIdByToken(token);
                if (string.IsNullOrEmpty(dbApplicationId) || dbApplicationId.ToLower() != applicationId.ToLower())
                {
                    result.Unauthorized();
                    return result;
                }
                result.OK();
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result<Models.Authorize> TokenCreate(string applicationId,string apiKey)
        {
            Result<Models.Authorize> result = new Result<Models.Authorize>();
            try
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    result.NotAcceptable("$gecersiz_api_keyi");
                    return result;
                }
                Data.IAuthorizationData authorizationData = new Data.DataFactory<Data.IAuthorizationData>(Config).Create();
                //string applicationId = authorizationData.GetApplicationIdByApiKey(apiKey);
                if (string.IsNullOrEmpty(applicationId))
                {
                    result.NotAcceptable("$gecersiz_uygulama_id");
                    return result;
                }
                Data.Collections.AuthorizeCollection authorizeCollection = new Data.Collections.AuthorizeCollection(applicationId, apiKey);
                result = new Result<Models.Authorize>(authorizationData.Insert(authorizeCollection));
                if (result)
                {
                    result.Created(new Models.Authorize(authorizeCollection));
                }

            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
    }
}