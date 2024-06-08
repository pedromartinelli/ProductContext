using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace ProductContext.Domain.Dtos
{
    public class ResultDto<T>
    {
        public ResultDto(T data, IList<Notification> notifications)
        {
            Success = notifications.Count > 0 && false;
            Data = data;
            Notifications = notifications;
        }

        public ResultDto(T data)
        {
            Success = true;
            Data = data;
        }

        public ResultDto(bool success)
        {
            Success = success;
        }

        public ResultDto(Notification notification)
        {
            Notifications.Add(notification);
            Success = Notifications.Count > 0 && false;
        }

        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public IList<Notification>? Notifications { get; private set; } = new List<Notification>();
    }
}
