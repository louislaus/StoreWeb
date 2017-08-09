using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using StoreWeb.Core.Log;

namespace StoreWeb.Core
{
    public class WebHelper
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(int dest, int host, ref long mac, ref int length);
        [DllImport("Ws2_32.dll")]
        private static extern int inet_addr(string ip);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetClientMacAddress()
        {
            string mac_dest = string.Empty;
            try
            {
                string strClientIP = HttpContext.Current.Request.UserHostAddress.Trim();
                int ldest = inet_addr(strClientIP);
                inet_addr("");
                long macinfo = new long();
                int len = 6;
                SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                if (mac_src != "0")
                {
                    while (mac_src.Length < 12)
                    {
                        mac_src = mac_src.Insert(0, "0");
                    }
                    for(int i = 0; i < 11; i++)
                    {
                        if (0 == (i % 2))
                        {
                            mac_dest = i == 10 ? mac_dest.Insert(0, mac_src.Substring(i, 2)) : "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch
            {

            }
            return mac_dest;
        }

        public static bool IsXHR(HttpRequestBase request)
        {
            bool ret = false;
            if (request != null)
            {
                if (request.Headers["X-Requested-With"] != null && request.Headers["X-Requested-With"].Trim().Length > 0)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public static bool Send(string host,string address,string pwd,MailAddress MessageFrom,string MessageTo,string MessageSubject,string MessageBody)
        {
            MailMessage message = new MailMessage();
            string Host = host;
            string Mail_Address = address;
            string Mail_Pwd = pwd;
            message.From = MessageFrom;
            message.To.Add(MessageTo);
            message.Subject = MessageSubject;
            message.Body = MessageBody;
            message.IsBodyHtml = false;
            message.Priority = MailPriority.High;
            SmtpClient sc = new SmtpClient
            {
                Host = Host,
                Port = 25,
                Credentials = new NetworkCredential(Mail_Address, Mail_Pwd)
            };
            try
            {
                sc.Send(message);
            }catch(Exception ex)
            {
                Logger.Log("发送邮件失败", ex);
                return false;
            }
            return true;
        }
        public static string BuildForm(string formName,string actionUrl,string formType, IDictionary<string, string> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<form id=\"{0}\" name=\"{0}\" action=\"{1}\" method=\"{2}\">", formName, actionUrl, formType);
            foreach (KeyValuePair<string, string> kp in keyValues)
            {
                sb.AppendFormat("<input type=\"hidden\" name=\"{0}\"  id=\"{0}\" value=\"{1}\"  />", kp.Key, kp.Value);
            }
            sb.AppendFormat("</form>");
            sb.AppendFormat("<script>document.forms['{0}'].submit();</script>", formName);
            return sb.ToString();
        }
    }
}
