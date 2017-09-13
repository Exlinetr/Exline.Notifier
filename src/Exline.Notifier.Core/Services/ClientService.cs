using System;
namespace Exline.Notifier.Core.Services
{
    public sealed class ClientService : BaseService
    {
        public ClientService(Config config)
            : base(config)
        {

        }

        public Result<Models.Client> Create(string token, DeviceType deviceType)
        {
            Result<Models.Client> result = new Result<Models.Client>();
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    result.SetErr("$gecersiz_token");
                    return result;
                }
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                if (!clientData.ExistsByToken(token))
                {
                    Data.Collections.ClientCollection clientCollection = new Data.Collections.ClientCollection(token, deviceType);
                    result = new Result<Models.Client>(clientData.Create(clientCollection));
                    if (result)
                        result.OK(new Models.Client(clientCollection));
                }
                else
                {
                    result.SetErr("$bu_token_ile_bir_kullanici_katiyli");
                }

            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result Remove(string clientId)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                    return result;
                }
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                result = clientData.Remove(clientId);
                if (result)
                    result.OK(clientId);
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result TokenUpdate(string clientId, string token)
        {
            Result result = new Result();
            try
            {
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                    return result;
                }
                if (string.IsNullOrEmpty(token))
                {
                    result.SetErr("$gecersiz_token");
                    return result;
                }
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                result = clientData.TokenUpdate(clientId, token);
                if (result)
                {
                    result.OK(token);
                }
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }

        public Result<PaginationResult<Models.Client>> GetList(int pageIndex, int pageSize)
        {

            Result<PaginationResult<Models.Client>> result = new Result<PaginationResult<Models.Client>>();
            try
            {
                pageIndex = PageIndexControl(pageIndex);
                pageSize = PageSizeControl(pageSize);

                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                PaginationResult<Data.Collections.ClientCollection> pageResult = clientData.GetList(pageIndex, pageSize);
                result.OK(pageResult.To<Models.Client>(x => new Models.Client(x)));
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result<Models.Client> GetById(string clientId)
        {
            Result<Models.Client> result = new Result<Models.Client>();
            try
            {
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                    return result;
                }
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                Data.Collections.ClientCollection clientCollection = clientData.GetById(clientId);
                result.OK(new Models.Client(clientCollection));
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result<string> GetTokenById(string clientId)
        {
            Result<string> result = new Result<string>();
            try
            {
                if (string.IsNullOrEmpty(clientId))
                {
                    result.SetErr("$gecersiz_client_id");
                    return result;
                }
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                string token = clientData.GetTokenById(clientId);
                if (!string.IsNullOrEmpty(token))
                    result.OK(token);
                else
                    result.SetErr("$client_bulunamadi");
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
        public Result ExistsByToken(string token)
        {
            Result result = new Result();
            try
            {
                Data.IClientData clientData = new Data.DataFactory<Data.IClientData>(Config).Create();
                result.OK(clientData.ExistsByToken(token));
            }
            catch (Exception ex)
            {
                result.SetErr(ex);
                OnException(ex);
            }
            return result;
        }
    }
}
