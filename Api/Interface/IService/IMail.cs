using Api.Service.Mail;

namespace Api.Interface.IService
{
    public interface IMail
    {
        public bool SendEmail(EmailRequest request);
    }
}
