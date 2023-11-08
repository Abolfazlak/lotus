using System;
using lotus.DataProvide;
using lotus.Models.Authenticate;
using lotus.Services.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lotus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
	{
		private readonly IUserManagerService _userManagerService;
        private readonly IConfiguration _configuration;


        public UserManagementController(IUserManagerService userManagerService, IConfiguration configuration)
		{
			_userManagerService = userManagerService;
            _configuration = configuration;
		}

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                if (!IsAdminsRequest(true))
                    return Unauthorized();

                var res = await _userManagerService.GetUsersFromService();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        private bool IsAdminsRequest(bool IsAdmin)
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user_role");
            if (claim == null)
                return false;
            return claim.Value == IsAdmin.ToString();
        }

        private string GetUserId()
        {
            var claim = HttpContext.User.Claims.Where(x => x.Type == "user_id").FirstOrDefault();
            if (claim == null)
                return "";
            return claim.Value;
        }

    }




}

