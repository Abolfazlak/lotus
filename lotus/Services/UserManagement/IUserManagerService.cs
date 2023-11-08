using System;
using lotus.Models.UserManagement;

namespace lotus.Services.UserManagement
{
	public interface IUserManagerService
	{
        public Task<List<UsersDto>> GetUsersFromService();
    }
}

