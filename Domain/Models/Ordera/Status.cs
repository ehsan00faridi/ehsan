using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ordera
{
    public enum Status
    {
        Cart = 0,
        Pending = 1,
        Paid = 2,
        Cancelled = 3
    }
}
