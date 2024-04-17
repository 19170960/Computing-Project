using System.Web.Http;
using System.Net.Http;
using Twilio.AspNet.Common;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;


namespace WebApplication2.Controllers
{
    [ApiController]
    [System.Web.Http.RoutePrefix("api")]
    public class WebhookController : ApiController
    {

        public WebhookController()
        {
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Smsrequest")]
        // Specific interface to be used (by the webhook)

        public HttpResponseMessage Post([System.Web.Http.FromBody] SmsRequest receivedSMS)
        // POST method (executed when a message is received)
        {
            NamedPipeClientStream pipeSendSMS = new NamedPipeClientStream(".", "pipeReceive", PipeDirection.InOut);
            // Configure pipe in order to transmit received SMS to application
            pipeSendSMS.Connect();
            // Connnect to pipe
            StreamWriter sendSMS = new StreamWriter(pipeSendSMS);
            // Provide a method of using the pipe (as a form of IPC)
            sendSMS.WriteLine(receivedSMS.Body);
            // Transmit the message data
            sendSMS.Flush();
            // Message will be displayed as empty, unless flush function is executed

            return null;

        }

    }



}

