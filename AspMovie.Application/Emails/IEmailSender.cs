

namespace AspMovie.Application.Emails
{
    public interface IEmailSender
    {
        void Sand(MessageDto messageDto);
    }

    public class MessageDto
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
