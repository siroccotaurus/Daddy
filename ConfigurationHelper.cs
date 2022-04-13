﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb
{
    public static class ConfigurationHelper
    {
        static IConfiguration Configuration { get; set; }

        public static void SetConfigFile(IConfiguration configuration) { Configuration = configuration; }
        public static string GetMySQLConnectionString()
        {
            List<IConfigurationSection> children = Configuration.GetSection("MySqlConnection").GetChildren().ToList();
            string s = children.Find(c => c.Key == "Server").Value;
            string u = children.Find(c => c.Key == "Username").Value;
            string d = children.Find(c => c.Key == "Database").Value;
            string p = children.Find(c => c.Key == "Port").Value;
            string x = children.Find(c => c.Key == "Password").Value;
            return "server=" + s + ";user=" + u + ";database=" + d + ";port=" + p + ";password=" + x;
        }
        //public static MailHelper GetMailConnection()
        //{
        //    List<IConfigurationSection> children = Configuration.GetSection("Smtp").GetChildren().ToList();
        //    return new MailHelper(children[0].Value, Convert.ToInt32(children[2].Value), children[3].Value, children[1].Value);
        //}
    }

    //public class MailHelper
    //{
    //    public string Host { get; private set; }
    //    public int Port { get; private set; }
    //    public string Username { get; private set; }
    //    public string Password { get; private set; }

    //    public MailHelper(string host, int port, string username, string password)
    //    {
    //        Host = host;
    //        Port = port;
    //        Username = username;
    //        Password = password;
    //    }

    //    public bool Send(MimeKit.MimeMessage msg)
    //    {
    //        try
    //        {
    //            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
    //            {
    //                smtpClient.Connect(Host, Port, false);
    //                smtpClient.Authenticate(Username, Password);
    //                smtpClient.Send(msg);
    //                smtpClient.Disconnect(true);
    //            }
    //            return true;
    //        }
    //        catch (Exception) { return false; }
    //    }
    //}
}