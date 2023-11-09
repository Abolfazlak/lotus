using System;
using JWTRefreshToken.NET6._0.Controllers;
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
        private readonly ILogger<UserManagementController> _logger;


        public UserManagementController(IUserManagerService userManagerService, IConfiguration configuration
                                        , ILogger<UserManagementController> logger)
		{
			_userManagerService = userManagerService;
            _configuration = configuration;
            _logger = logger;
		}

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                if (!IsAdminsRequest(true))
                {
                    _logger.LogError("user does not have a permission to get all users");

                    return Unauthorized();
                }

                var res = await _userManagerService.GetUsersFromService();

                _logger.LogInformation($"Admin get all users list");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in GetAllUsers: {ex.Message}");
                return Problem(ex.Message);
            }
        }



        private bool IsAdminsRequest(bool IsAdmin)
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user_role");
            if (claim == null)
                return false;
            return claim.Value == IsAdmin.ToString();
        }

    }
}

