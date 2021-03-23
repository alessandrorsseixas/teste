using SiteMercado.Domain.SeedWorks.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Domain.SeedWorks.Interfaces.Services
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
