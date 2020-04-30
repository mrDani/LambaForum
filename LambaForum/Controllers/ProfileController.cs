using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambaForum.Data;
using LambaForum.Data.Models;
using LambaForum.Models.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LambaForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService; 

        public ProfileController(UserManager<ApplicationUser> userManager,
            IApplicationUser userService,
            IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }

        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel()
            {
                UserId =user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                MemberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadProfileImage(IFormFile file)
        //{
        //    var userId = _userManager.GetUserId(User);

        //    // Connect to an Azure Storage Container
        //    //Get Blob Container
        //    //Parse the content Disposition header
        //    // Get a filename
        //    // Get a reference to a Block Blob
        //    //On that Block Blob Upload our file ...file uploaded to the cloud
        //    // Set the User Profile to the Uri
        //    // Redirect to the User Profile Page
        //}
    }
}