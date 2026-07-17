using Domain.Models.Customers;
using Domain.Models.Ordera;
using MediatR;

namespace Application.Features.Products.Orders
{
    internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public AddOrderCommandHandler(
            ICustomerRepository customerRepository,
            IOrdersRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            Customer customer;

            if (request.UserId.HasValue)
            {
                customer = await _customerRepository.FindAsync(request.UserId.Value);

                if (customer is null)
                {
                    var name = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName;
                    customer = new Customer(name, request.Email, request.UserId.Value);

                    await _customerRepository.AddAsync(customer);
                    await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
            }
            else
            {
                var name = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName;
                customer = new Customer(name, request.Email,request.UserId);

                await _customerRepository.AddAsync(customer);
                await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }

            var order = new Order
            {
                CustomerId = customer.Id,
                Status = Status.Cart,
                Date = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
