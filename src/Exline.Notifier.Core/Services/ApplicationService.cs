namespace Exline.Notifier.Core.Services
{
    public class ApplicationService : BaseService
    {
        public ApplicationService(string id, Config config)
            : base(id, config)
        {

        }
        public ApplicationService(Config config)
            : this(string.Empty, config)
        {

        }

        public Result<Models.Application> Create(string name)
        {
            Result<Models.Application> result = new Result<Models.Application>();
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    result.SetErr("$uygulama_adi_girmelisiniz");
                    return result;
                }
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                if (applicationData.ExistsByName(name))
                {
                    result.SetErr("$farkli_bir_uygulama_adi_giriniz");
                    return result;
                }
                Data.Collections.ApplicationCollection applicationCollection = new Data.Collections.ApplicationCollection(name);
                result = new Result<Models.Application>(applicationData.Create(applicationCollection));
                if (result)
                    result.OK(new Models.Application(applicationCollection));

            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result<PaginationResult<Models.Application>> GetList(int pageIndex, int pageSize)
        {
            Result<PaginationResult<Models.Application>> result = new Result<PaginationResult<Models.Application>>();
            try
            {
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                PaginationResult<Data.Collections.ApplicationCollection> pageResult = applicationData.GetList(pageIndex, pageSize);
                pageResult.SetPageInfo(pageIndex, pageSize);
                result.OK(pageResult.To<Models.Application>(x => new Models.Application(x)));
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result<Models.Application> GetById(string applicationId)
        {
            Result<Models.Application> result = new Result<Models.Application>();
            try
            {
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                Data.Collections.ApplicationCollection applicationCollection = applicationData.GetById(applicationId);
                result.OK(new Models.Application(applicationCollection));
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result<string> GetApplicationIdByApiKey(string apiKey)
        {
            Result<string> result = new Result<string>();
            try
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    result.SetErr("$gecersiz_api_key");
                    return result;
                }

                Data.IAuthorizationData authorizationData = new Data.DataFactory<Data.IAuthorizationData>(Config).Create();
                string apiKeyId = authorizationData.GetApplicationIdByApiKey(apiKey);
                if (string.IsNullOrEmpty(apiKeyId))
                {
                    result.SetErr("$gecersiz_api_key");
                    return result;
                }

                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                string applicationId = applicationData.GetApplicationIdByApiKeyId(apiKey);
                if (string.IsNullOrEmpty(applicationId))
                {
                    result.SetErr("$api_keyine_bagli_bir_uygulama_bulunmamaktadir");
                    return result;
                }

                result.OK(applicationId);
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result Remove(string applicationId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(applicationId))
                {
                    result.SetErr("$gecersiz_uygulama_id");
                    return result;
                }
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                result = applicationData.Remove(applicationId);
                if (result)
                {
                    result.OK();
                }
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result TotalSendingNotificationCountIncrement(int value)
        {
            Result result = new Result();
            try
            {
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                result = applicationData.TotalSendNotificationCountIncrement(ApplicationId, value);
                if (result)
                {
                    result.OK();
                }
            }
            catch (System.Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result TotalClientCountIncrement(int value)
        {
            Result result = new Result();
            try
            {
                Data.IApplicationData applicationData = new Data.DataFactory<Data.IApplicationData>(Config).Create();
                result = applicationData.TotalClientCountIncrement(ApplicationId, value);
                if (result)
                {
                    result.OK();
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