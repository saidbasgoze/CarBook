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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<TestiMonial> _repository;

        public UpdateServiceCommandHandler(IRepository<TestiMonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestiMonialId);
            values.Comment = request.Comment;
            values.Title = request.Title;
            values.TestiMonialId = request.TestiMonialId;
            values.ImageUrl= request.ImageUrl;
            values.Name = request.Name;

            await _repository.UpdateAsync(values);
        }
    }
}
