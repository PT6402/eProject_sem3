using Api.Service.SMS;
using Lib.Dto;
using Twilio.Rest.Api.V2010.Account;

namespace Api.Interface.IService
{
    public interface ISMS
    {
        Task<DtoResult<MessageResource>> SendSMS(SMSRequest model);
    }
}
