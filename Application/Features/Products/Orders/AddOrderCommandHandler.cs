using Application.Application_DTO;
using Application.Features.Products.Orders.Event;
using Domain.Event;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.User;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
namespace Application.Features.Products.Orders
{
    internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand,bool >
    {
        private readonly IMediator _mediator;
        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;


        public AddOrderCommandHandler(ICustomerRepository customerRepository, IOrdersRepository orderRepository, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Email,request.Name,request.UserId);
            var address = new Address(request.Street,request.City,request.ZipCode);
            customer.SetAddress( address);
            //var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var order = new Order()  { 
             CustomerId = customer.Id,
                Status= Status.Success,
                Date=DateTime.Now 
            };
            var createorder = new CreateOrderEvent()
            {
                Data = order.Date
            };

            var sendEmail = new UserRegisteredDomainEvent(customer.Id, request.Email);
            customer.AddDomainEvent(sendEmail);

            //await _mediator.Publish(new EmailMessage
            //{

            //    To = "ehsanfaridi1382@gmail.com",
            //    Subject = "Welcome 🎉",
            //    Body = "<h1>Welcome to our platform</h1>"
            //});



            //order.AddDomainEvent(new UserRegisteredEvent
            //{
            //    PhoneNumber = "989022797372",
            //    UserName = "Ehsan"
            //});
            //await _mediator.Publish(new UserRegisteredEvent
            //{
            //    PhoneNumber = "989022797372",
            //    UserName = "Ehsan"
            //});

            await _orderRepository.AddAsync(order);
           await  _orderRepository.UnitOfWork.SaveEntitiesAsync();
           return true;
        }
    }
}
