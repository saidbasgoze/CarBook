using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<TestiMonial> _repository;
        public CreateServiceCommandHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TestiMonial
            {
                 Name= request.Name,
                 Comment= request.Comment,
                 ImageUrl= request.ImageUrl,
                 Title= request.Title
                 
            });
        }
    }
}
