using Newtonsoft.Json;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Smarket.API.Filters
{
    public class APIMainFilter : ActionFilterAttribute
    {
        public APIMainFilter()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string token = string.Empty;
            bool notAuthorized = true;

            try
            {
                token = actionContext.Request.Headers.Authorization != null ? actionContext.Request.Headers.Authorization.ToString() : string.Empty;

                if (!string.IsNullOrEmpty(token))
                {
                    if (!token.StartsWith("Bearer"))
                    {
                        token = token.Replace("Basic ", string.Empty);
                        var tokenObj = JsonConvert.DeserializeObject<LoginReturnModel>(EncryptString.Decrypt(token));
                        if (tokenObj != null)
                        {
                            if (tokenObj.UserId != null && tokenObj.UserId != Guid.Empty)
                            {
                                if (tokenObj.Date.AddDays(1) > DateTime.Now)
                                {
                                    notAuthorized = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        notAuthorized = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //ServiceLog.SaveLog(ex.Message);
            }
            
            if (notAuthorized)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
        }

    }
}