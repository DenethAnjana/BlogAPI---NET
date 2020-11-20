using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.DatabaseContext;
using BlogAPI.Entity;
using BlogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPostService _postService;

        public PostController(DataContext dataContext, IPostService postService)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var allPosts = _dataContext.Posts.ToList();
            return Ok(allPosts);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPost(int id)
        {
            var post = _dataContext.Posts.Where(s => s.Id == id).SingleOrDefault();

            if (post == null)
                return NotFound($"No Post Found for Id {id}");
            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody]Post newPost)
        {
            newPost = _postService.CreatePost(newPost);
            return Ok(newPost);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdatePost(int id, [FromBody]Post updatedPost)
        {
            var post = _dataContext.Posts.Where(s => s.Id == id).SingleOrDefault();

            if (post == null)
                return NotFound($"No Post Found for Id {id}");

            post.Content = updatedPost.Content;
            post.Title = updatedPost.Title;
            post.ImageUrl = updatedPost.ImageUrl;

            _dataContext.Posts.Update(post);
            _dataContext.SaveChanges();

            return Ok(post);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            var post = _dataContext.Posts.Where(s => s.Id == id).SingleOrDefault();

            if (post == null)
                return NotFound($"No Post Found for Id {id}");

            _dataContext.Posts.Remove(post);
            _dataContext.SaveChanges();

            return Ok(post);
        }
    }
}
