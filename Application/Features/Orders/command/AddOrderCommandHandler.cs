using Domain.BaseRepository;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Features.Orders.command
{
    internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IProductRepository _productRepository;
        public AddOrderCommandHandler(
            ICustomerRepository customerRepository,
            IOrdersRepository orderRepository,
            IOrderItemsRepository orderItemsRepository,
            IProductRepository productRepository)

        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _productRepository = productRepository;
        
        }

        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            Customer? customer;


                customer = await _customerRepository.GetUserIdAsync(Usrid:request.UserId);


                if (customer == null)
                {
                    var name = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName;
                    customer = new Customer(request.UserName, request.Email, request.UserId);
                    var address = new Address(city:"",street:"",zipcode:"");
                    customer.SetAddress(address);

                    await _customerRepository.AddAsync(customer);
                    await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            Order? order ;




            order = await _orderRepository.Get(i => i.CustomerId == customer.Id && i.Status==Status.Cart ).FirstOrDefaultAsync();


            if (order == null)
            {
                order=new Order
                {
                    CustomerId = customer.Id,
                    Status = Status.Cart,
                    Date = DateTime.UtcNow
                };

                await _orderRepository.AddAsync(order);
                await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            }



            var productQuery = await _productRepository.FindAsync(request.ProductId);


            bool equlQty = productQuery.Qty <  request.Qty || request.Qty <=0;

            OrderItems? orderitem;


            orderitem = await _orderItemsRepository.Get(i => i.OrderId == order.Id && i.Productid==request.ProductId).FirstOrDefaultAsync();
            if (orderitem != null && !equlQty)
            {
                orderitem.Qty=request.Qty;
               

               await _orderItemsRepository.UpdateAsync(orderitem);

            }
            else if (!equlQty)
            {

                orderitem = new OrderItems
                {
                    Qty = request.Qty,

                    Productid = request.ProductId,
                    OrderId = order.Id
                };
                await _orderItemsRepository.AddAsync(orderitem);

            }
           

           
            await _orderItemsRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
