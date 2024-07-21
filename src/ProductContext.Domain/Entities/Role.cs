using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Entities
{
    public class Role : BaseEntity
    {
            public string Title { get; private set; }
            public IList<User> Users { get; private set; }
    };
}
