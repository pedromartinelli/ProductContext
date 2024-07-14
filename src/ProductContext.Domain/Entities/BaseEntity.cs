using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public void CreateRecord()
        {
            CreateDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
        }

        public void UpdateRecord()
        {
            LastUpdateDate = DateTime.UtcNow;
        }

    }
}
