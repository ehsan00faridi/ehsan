using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Command
{
    public record UpdateProductCommand(int id,
        string name,
        decimal price,
        int qty,
        string weight,
        string material
        ):IRequest<bool>;
}
