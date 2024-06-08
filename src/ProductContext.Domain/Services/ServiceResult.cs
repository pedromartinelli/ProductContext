using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using ProductContext.Domain.Interfaces.Services;

namespace ProductContext.Domain.Services
{
    public class ServiceResult : IServiceResult
    {
        private readonly ICollection<string> _errors = new List<string>();

        public ServiceResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ServiceResult(string message, ICollection<Notification> errors)
        {
            Success = errors.Any() != true;
            Message = message;
            _errors = errors.Select(e => e.Message).ToList();
        }


        public bool Success { get; private set; }
        public string Message { get; private set; }
        public IReadOnlyCollection<string> Errors => _errors.ToList();
    }
}
