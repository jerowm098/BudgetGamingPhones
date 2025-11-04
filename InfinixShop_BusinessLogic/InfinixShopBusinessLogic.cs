using System.Collections.Generic;
using System.Linq;
using InfinixShop_Common;
using InfinixShop_DataLogic;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;
using System.Text.Json;

namespace InfinixShop_BusinessLogic
{
    public static class InfinixShopLogic
    {
        // private static IPhoneDataService dataService = new SqlPhoneDataService();
        // private static IPhoneDataService dataService = new InMemoryPhoneDataService();
        // private static IPhoneDataService dataService = new TextFilePhoneDataService();
        private static IPhoneDataService dataService = new JsonFilePhoneDataService();

        private static EmailSettings emailSettings = new EmailSettings
        {
            FromName = "BudgetGamingPhones",
            FromAddress = "do-not-reply@infinix.com",
            ToName = "Jerome Mallari",
            ToAddress = "jerome0123@example.com",
            SmtpHost = "sandbox.smtp.mailtrap.io",
            SmtpPort = 2525,
            SmtpUsername = "91e9b325c13ccf",
            SmtpPassword = "21bd1f4b37b520",
            EnableTls = true
        };

        private static void SendEmail(string accountNumber)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailSettings.FromName, emailSettings.FromAddress));
            message.To.Add(new MailboxAddress(emailSettings.ToName, emailSettings.ToAddress));
            message.Subject = "Account Transaction";

            message.Body = new TextPart("plain")
            {
                Text = $"Account {accountNumber}\n\nA transaction was made to your account\n\n"
            };

            using (var client = new SmtpClient())
            {
                var tlsOption = emailSettings.EnableTls
                    ? MailKit.Security.SecureSocketOptions.StartTls
                    : MailKit.Security.SecureSocketOptions.None;

                client.Connect(emailSettings.SmtpHost, emailSettings.SmtpPort, tlsOption);
                client.Authenticate(emailSettings.SmtpUsername, emailSettings.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        public static PhoneItem AddToCart(string phoneName)
        {
            var existingItem = dataService.SearchItemByName(phoneName);
            if (existingItem != null) return null;

            bool addedSuccessfully = dataService.AddItem(phoneName);
            if (addedSuccessfully)
            {
                SendEmail("Jerome account");
                return dataService.SearchItemByName(phoneName);
            }
            return null;
        }

        public static PhoneItem RemoveFromCart(string phoneName)
        {
            var itemToRemove = dataService.SearchItemByName(phoneName);
            if (itemToRemove != null)
            {
                bool deleted = dataService.DeleteItem(itemToRemove.Id);
                if (deleted)
                {
                    return itemToRemove;
                }
            }
            return null;
        }

        public static List<string> GetCartItemNames()
        {
            return dataService.GetAllItems().Select(p => p.Name).ToList();
        }

        public static List<PhoneItem> GetAllItemsInCart()
        {
            return dataService.GetAllItems();
        }

        public static PhoneItem SearchPhoneByName(string name)
        {
            return dataService.SearchItemByName(name);
        }

        public static PhoneItem UpdatePhoneName(int id, string newName)
        {
            bool updated = dataService.UpdateItem(id, newName);
            if (updated)
            {
                return dataService.SearchItemByName(newName);
            }
            return null;
        }
    }
}