using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambaForum.Data;
using Microsoft.AspNetCore.Mvc;

namespace LambaForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
        }
        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}