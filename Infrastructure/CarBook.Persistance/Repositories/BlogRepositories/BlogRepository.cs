﻿using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

		public List<Blog> GetAllBlogsWithAuthors()
		{
            var values = _carBookContext.Blogs.Include(x =>x.Author).Include(x => x.Category).ToList();
            return values;
		}

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).Where(y => y.BlogId == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x=>x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
