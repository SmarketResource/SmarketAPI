using Smarket.API.Filters;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Smarket.API.Controllers
{
    [APIMainFilter]
    public class BaseController : ApiController
    {
        public BaseReturn ReturnModelError(ModelStateDictionary modelState, string msgError)
        {
            foreach (var model in modelState.Values)
            {
                var error = model.Errors.FirstOrDefault().ErrorMessage;

                if (string.IsNullOrEmpty(error))
                    error = model.Errors.FirstOrDefault().Exception.Message;

                if (string.IsNullOrEmpty(error))
                    error = msgError;

                return new BaseReturn()
                {
                    Error = true,
                    Message = error,
                };
            }

            return new BaseReturn()
            {
                Error = true,
                Message = msgError,
            };
        }
    }
}