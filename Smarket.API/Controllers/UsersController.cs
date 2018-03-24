using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// UsersController Class
    /// </summary>
    public class UsersController : BaseController
    {

        private readonly IServiceUser _serviceUser;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// UsersController Constructor
        /// </summary>
        public UsersController(IServiceUser serviceUser, IServiceLog serviceLog)
        {
            _serviceUser = serviceUser;
            _serviceLog  = serviceLog;
        }

        /// <summary>
        /// List all Users in database
        /// </summary>
        /// <remarks>Return a list of users</remarks>
        [HttpGet]
        [ResponseType(typeof(UserReturn))]
        public IHttpActionResult GetUsers()
        {
            var returnModel = new UserReturn();

            try
            {
                returnModel = _serviceUser.GetUsers();
                returnModel.Message = GeneralMessages.GetUsersSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetUsersError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);

                return new ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode.BadRequest),
                        new HttpError(returnModel.Message)
                    )
                );
            }
            
            return Ok(returnModel);
        }

        /// <summary>
        /// Save a User
        /// </summary>
        /// <param name="command">Users data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult SaveUser(SaveUserCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var user = Mapper.Map<SaveUserCommand, Users>(command);

                returnModel = _serviceUser.SaveUser(user);

            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveUserError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);

                return new ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode.BadRequest),
                        new HttpError(returnModel.Message)
                    )
                );
            }

            return Ok(returnModel);
        }
    }
}