using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorsQuery, List<GetAllBlogsWithAuthorsQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorsQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{

			var values = _repository.GetAllBlogsWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorsQueryResult
			{
				AuthorId = x.AuthorId,
				BlogId = x.BlogId,
				CategoryId = x.CategoryId,
				CoverImageUrl = x.CoverImageUrl,
				Title = x.Title,
				CreateDate = x.CreateDate,
				AuthorName = x.Author.Name,
				Description=x.Description,
				AuthorImageUrl=x.Author.ImageUrl,
				AuthorDescription=x.Author.Description
				//CategoryName=x.Category.Name
			}).ToList();
		}
	}
	}

