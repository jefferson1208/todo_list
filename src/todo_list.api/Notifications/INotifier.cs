using System.Collections.Generic;
using todo_list.api.Models;

namespace todo_list.api.Notifications
{
    public interface INotifier
    {
        bool CheckNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
