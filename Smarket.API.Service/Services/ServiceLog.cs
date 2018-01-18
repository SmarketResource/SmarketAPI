using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Context;
using System;

namespace Smarket.API.Service.Services
{
    public class ServiceLog : ServiceBase<Logs>, IServiceLog
    {
        private readonly IRepositoryLog _repositoryLog;

        public ServiceLog(IRepositoryLog repositoryLog)
        {
            _repositoryLog = repositoryLog;
        }

        public void SaveLog(string message)
        {

            _repositoryLog.Add(new Logs
            {
                LogId = Guid.NewGuid(),
                Message = message,
                LogDate = DateTime.Now
            });

            _repositoryLog.SaveChanges();

        }

    }
}
