using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Domain.SeedWorks.Classes
{
    public class Notification
    {
        public string Message { get; }
        public Notification(string message)
        {
            Message = message;
        }
    }
}
