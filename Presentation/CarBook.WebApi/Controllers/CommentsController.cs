using CarBook.Application.Features.RepositoryPattern.CommentRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Repositories.CommentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values=_commentRepository.GetAll();
            return Ok(values);
        }
        //[HttpPost]
        //public IActionResult CreateComment(Comment comment)
        //{

        //    _commentRepository.Create(comment);
        //    return Ok("Yorum başarıyla eklendi");
        //}
        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateCommentDtoRepository commentDtoRepository)
        {
            if (commentDtoRepository == null)
            {
                return BadRequest("Invalid comment data.");
            }

            var comment = new Comment
            {
                Name = commentDtoRepository.Name,
                CreatedDate = commentDtoRepository.CreatedDate,
                Description = commentDtoRepository.Description,
                BlogId = commentDtoRepository.BlogId
            };

            _commentRepository.Create(comment);

            return Ok("Yorum Başarıyla Eklendi");
        }
    

    [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
           var value= _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum başarıyla silindi");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, UpdateCommentDtoRepository updateCommentDto)
        {
            if (id != updateCommentDto.CommentId)
            {
                return BadRequest("Geçersiz yorum ID'si");
            }

            // UpdateCommentDtoRepository'yi Comment sınıfına dönüştürme
            var commentToUpdate = new Comment
            {
                CommentId=updateCommentDto.CommentId,
                Name = updateCommentDto.Name,
                CreatedDate = updateCommentDto.CreatedDate,
                Description = updateCommentDto.Description,
                BlogId = updateCommentDto.BlogId
            };

            try
            {
                _commentRepository.Update(commentToUpdate); // Comment sınıfını kullanarak güncelleme işlemini yapın
                return Ok("Yorum başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Güncelleme işlemi sırasında bir hata oluştu: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value=_commentRepository.GetById(id);
            return Ok("value");
        }

        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _commentRepository.GetCommentByBlogId(id)
                                            .Select(c => new
                                            {
                                                c.CommentId,
                                                c.Name,
                                                c.CreatedDate,
                                                c.Description,
                                                c.BlogId
                                            })
                                            .ToList();

            return Ok(values);
        }
    }
}
