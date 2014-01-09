using EasyNetQ;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client : IDisposable
    {
        private IBus _bus;
        private string _host;
        private string _imagespath;

        public Client(string host, string imagespath)
        {
            this._host = host;
            this._imagespath = imagespath;
        }

        public void Run()
        {
            int message_count = 1;

            _bus = RabbitHutch.CreateBus("host=" + _host);
            
            _bus.Subscribe<MessageV2>("C#_EasyNetQ",

                msg =>
                {
                    if (msg.Attachments != null)
                    {
                        msg.Attachments.ForEach(attachment =>
                        {
                            attachment.FileName = string.Format("C#_EasyNetQ{0}_{1}", message_count, attachment.FileName);
                            attachment.Save(_imagespath);
                        });
                    }

                    Console.WriteLine(string.Format(""));
                    message_count++;
                });
        }

        public void Dispose()
        {
            if (this._bus != null)
            {
                this._bus.Dispose();
            }
        }
    }
}
