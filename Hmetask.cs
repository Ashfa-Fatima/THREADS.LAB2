using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerApp
{
    internal class Program
    {
        private static TcpListener server;
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            int port = 5000;
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine(" Server is running on port " + port);

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread t = new Thread(HandleClient);
                t.Start(client);
            }
        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string response = ProcessRequest(request);
                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
                }
            }
            catch
            {
                Console.WriteLine("⚠️ Client disconnected unexpectedly");
            }
            finally
            {
                client.Close();
            }
        }

        private static string ProcessRequest(string request)
        {
            string[] parts = request.Split('|');
            if (parts.Length != 3)
                return "ERROR|Invalid request format";

            string action = parts[0];
            string username = parts[1];
            string password = parts[2];

            lock (users)
            {
                if (action == "SIGNUP")
                {
                    if (users.ContainsKey(username))
                        return "SIGNUP_FAIL|User already exists";
                    users[username] = password;
                    return "SIGNUP_OK|Registration successful";
                }
                else if (action == "LOGIN")
                {
                    if (users.ContainsKey(username) && users[username] == password)
                        return "LOGIN_OK|Welcome " + username;
                    return "LOGIN_FAIL|Invalid credentials";
                }
                return "ERROR|Unknown action";
            }
        }
    }
}