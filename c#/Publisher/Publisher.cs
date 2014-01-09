
namespace RabbitTest
{
    using EasyNetQ;
    using Messages;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Publisher
    {
        private string _host;
        private string _imagespath;

        public Publisher(string host, string imagespath)
        {
            this._host = host;
            this._imagespath = imagespath;
        }

        public void Run()
        {
            using (var bus = RabbitHutch.CreateBus("host=" + _host))
            {
                Parallel.ForEach(Enumerable.Range(0, 10), (x) =>
                {
                    foreach (var file in Directory.GetFiles(_imagespath, "*.jpg"))
                    {
                        bus.Publish<MessageV2>(new MessageV2
                        {
                            To = new string[] { "jeremy@shantz.io" },
                            Subject = "RabbitMQ",
                            Body = "Testing RabbitMQ",
                            Attachments = new List<AttachmentV2> { AttachmentV2.FromFile(file) }
                        });
                    }
                });
            }
        }
    }
}
