using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class PhoneService : BaseService
    {

        public BaseReturn SavePhone(SavePhoneCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                using(var transaction = new TransactionScope())
                {
                    db.Phones.Add(new Phones
                    {
                        PhoneId     = Guid.NewGuid(),
                        TypePhoneId = command.TypePhoneId,
                        Number      = command.PhoneNumber
                    });

                    db.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessages.SavePhoneSuccess;
            }
            catch (TransactionAbortedException tex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SavePhoneError + " : " + tex.Message;
                LogService.SaveLog(returnModel.Message);
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SavePhoneError + " : " + ex.Message;
                LogService.SaveLog(returnModel.Message);
            }

            return returnModel;

        }

    }
}
