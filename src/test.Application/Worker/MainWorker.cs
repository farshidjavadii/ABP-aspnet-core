using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;
namespace test.Worker
{
    public class MainWorker : BackgroundService
    {
        public static string data = null;
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("MainWorker message example", EventLogEntryType.Information, 101, 1);
            }

            Thread thread = new Thread(() => StartListening());
            thread.Start();
            return Task.CompletedTask;
        }
        public static void StartListening()
        {

            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];


            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);


            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.
                    //while (true)
                    //{
                    bytes = new byte[50 * 1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    CommonObjects.Request obj = (CommonObjects.Request)Utility.DeserializeBinary_Memory(bytes);
                    //    if (data.IndexOf("<EOF>") > -1)
                    //    {
                    //        break;
                    //    }

                    //}

                    // Show the data on the console.
                    Console.WriteLine("Text received : {0}", data);


                    MainWorker methods= new MainWorker();
                    MethodInfo addMethod = methods.GetType().GetMethod(obj.Command);
                    object response = addMethod.Invoke(methods, new object[] { obj });

                    // Echo the data back to the client.
                    byte[] msg = ObjectToByteArray(response); //Encoding.ASCII.GetBytes("server : data recived ");

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(e.ToString(), EventLogEntryType.Information, 101, 1);
                }
            }

        }
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public CommonObjects.Response POLServiceApiHandler(CommonObjects.Request request)
        {
            CommonObjects.Response response = new CommonObjects.Response();
            response.Message = "pol service api handler called successfully";
            return response;
        }
    }
}
