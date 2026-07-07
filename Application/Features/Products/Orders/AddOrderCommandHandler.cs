using Application.Application_DTO;
using Application.Features.Products.Orders.Event;
using Domain.Event;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.User;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace Application.Features.Products.Orders
{
    internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly UserManager<User> _userManager;
        public AddOrderCommandHandler(ICustomerRepository customerRepository, IOrdersRepository orderRepository, IMediator mediator, UserManager<User> userManager)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {


            var customer = new Customer(request.Email, request.Email, request.UserId);
            var address = new Address("request.Street", "request.City", "request.ZipCode");
            customer.SetAddress(address);



            await _customerRepository.AddAsync(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var order = new Order()
            {
                CustomerId = customer.Id,
                Status = Status.Success,
                Date = DateTime.Now
            };
       
            await _orderRepository.AddAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
