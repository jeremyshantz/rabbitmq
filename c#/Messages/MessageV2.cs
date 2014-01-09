
namespace Messages
{
    using System.Collections.Generic;

    public class MessageV2
    {
        public string[] To { get; set; }

        public string[] CC { get; set; }

        public string[] BCC { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<AttachmentV2> Attachments { get; set; }
    }
}
