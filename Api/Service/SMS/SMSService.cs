using Api.Interface.IService;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Api.Service.SMS
{
    public class SMSService : ISMS
    {
        private readonly IConfiguration _config;

        public SMSService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendSMS(SMSRequest model)
        {
            string accountSid = _config.GetSection("AccountSid").Value!;
            string authToken = _config.GetSection("AuthToken").Value!;
            string phone = _config.GetSection("TwilioPhoneNum").Value!;

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(

                body: model.Body,
                from: new Twilio.Types.PhoneNumber(phone),
                to: new Twilio.Types.PhoneNumber(model.To)

                );

            if (!(message.Status == MessageResource.StatusEnum.Sent))
            {
            return false;
            }
                return true;
        }
    }
}
