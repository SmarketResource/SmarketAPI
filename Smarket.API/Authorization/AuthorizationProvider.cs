using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Infrastructure.Repositories;
using Smarket.API.Model.Context;
using Smarket.API.Resources.Utils;
using Smarket.API.Service.Services;


namespace Smarket.API.Authorization
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {

        private IServiceLogin _serviceAuthorization;
        private IServiceLog _serviceLog;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                _serviceAuthorization = new ServiceLogin(new RepositoryUser(new SmarketContext()));

                _serviceLog = new ServiceLog(new RepositoryLog(new SmarketContext()));

                var account = _serviceAuthorization.Authenticate(context.UserName, context.Password);

                if (account == null)
                {
                    context.SetError("user_not_found", GeneralMessages.GetUsersError);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, account.Users.FirstOrDefault().UserLogin));

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Users.FirstOrDefault().UserId.ToString()));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "Email", account.Users.FirstOrDefault().UserLogin
                    },
                    {
                        "TypeUser", account.Users.FirstOrDefault().TypeUserId.ToString()
                    }
                });
                var ticket = new AuthenticationTicket(identity, props);

                context.Validated(ticket);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", GeneralMessages.GetUsersError);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}