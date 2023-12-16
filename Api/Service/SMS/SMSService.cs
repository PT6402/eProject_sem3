using Api.Interface.IService;
using Lib.Dto;
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

        public async Task<DtoResult<MessageResource>> SendSMS(SMSRequest model)
        {
            try {
            
            string accountSid = _config.GetSection("AccountSid").Value!;
            string authToken = _config.GetSection("AuthToken").Value!;
            string phone = _config.GetSection("TwilioPhoneNum").Value!;

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: model.Body,
                from: new Twilio.Types.PhoneNumber(phone),
                to: new Twilio.Types.PhoneNumber(model.To)
                );
                return new()
                {
                    Status = true,
                    Message = "send sms successfully",
                    Model = message
                };
            } catch (Exception e) {
                return new() { 
                Status= false, Message = e.Message  
                };
            }

        }
    }
}
