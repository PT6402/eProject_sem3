using Api.Service.SMS;

namespace Api.Interface.IService
{
    public interface ISMS
    {
        Task<bool> SendSMS(SMSRequest model);
    }
}
