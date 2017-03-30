using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace CommerceLib
{
    /// <summary>
    /// Mailing utilities for OrderProcessor
    /// </summary>
    public static class OrderProcessorMailer
    {
        public static void MailAdmin(int orderID, string subject,
        string message, int sourceStage)
        {
            // Send mail to administrator
            string to = ecommerceConfiguration.ErrorLogEmail;
            string from = ecommerceConfiguration.OrderProcessorEmail;
            string body = "Message: " + message
            + "\nSource: " + sourceStage.ToString()
            + "\nOrder ID: " + orderID.ToString();
            Utilities.SendMail(from, to, subject, body);
        }


        public static void MailCustomer(MembershipUser klient,
string subject, string body)
        {
            // Send mail to customer
            string to = klient.Email;
            string from = ecommerceConfiguration.CustomerServiceEmail;
            Utilities.SendMail(from, to, subject, body);
        }
        public static void MailSupplier(string subject, string body)
        {
            // Send mail to supplier
            string to = ecommerceConfiguration.SupplierEmail;
            string from = ecommerceConfiguration.OrderProcessorEmail;
            Utilities.SendMail(from, to, subject, body);
        }
    }
}