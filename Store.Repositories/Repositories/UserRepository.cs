using Microsoft.AspNetCore.Identity;
using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Enums;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repositories.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRepository(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public IQueryable GetUsers()
		{
			return _userManager.GetUsersInRoleAsync("User").Result.AsQueryable();
		}

		public List<User> GetCustomers()
		{
			var customers = _userManager.GetUsersInRoleAsync("Customer").Result;
			var guests = _userManager.GetUsersInRoleAsync("Guest").Result;
			return customers.Concat(guests).ToList();
		}

		public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
		{
			return await _signInManager.CheckPasswordSignInAsync(
				user,
				password,
				false);
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password, UserType userType)
		{
			IdentityResult result = await _userManager.CreateAsync(user, password);
			if (result != IdentityResult.Success)
			{
				return null;
			}
			User newUser = await GetUserByEmailAsync(user.Email);
			await AddUserToRoleAsync(newUser, userType.ToString());
			return result;
		}

		public async Task<User> GetUserByUserNameAsync(string userName)
		{
			return await _userManager.FindByNameAsync(userName);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<User> GetUserByIdAsync(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe)
		{
			return await _signInManager.PasswordSignInAsync(
				userName,
				password,
				rememberMe,
				false);
		}

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<IdentityResult> UpdateUserAsync(User user)
		{
			return await _userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> UpdateSecurityStampAsync(User user)
		{
			return await _userManager.UpdateSecurityStampAsync(user);
		}

		public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
		{
			return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
		}

		public async Task CheckRoleAsync(string roleName)
		{
			var roleExists = await _roleManager.RoleExistsAsync(roleName);
			if (!roleExists)
			{
				await _roleManager.CreateAsync(new IdentityRole
				{
					Name = roleName
				});
			}
		}

		public async Task AddUserToRoleAsync(User user, string roleName)
		{
			await _userManager.AddToRoleAsync(user, roleName);
		}

		public async Task<bool> IsUserInRoleAsync(User user, string roleName)
		{
			return await _userManager.IsInRoleAsync(user, roleName);
		}

		public async Task RemoveUserFromRoleAsync(User user, string roleName)
		{
			await _userManager.RemoveFromRoleAsync(user, roleName);
		}

		public async Task<string> GeneratePasswordResetTokenAsync(User user)
		{
			return await _userManager.GeneratePasswordResetTokenAsync(user);
		}

		public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
		{
			return await _userManager.ResetPasswordAsync(user, token, password);
		}

		public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
		{
			return await _userManager.ConfirmEmailAsync(user, token);
		}

		public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
		{
			return await _userManager.GenerateEmailConfirmationTokenAsync(user);
		}

	}
}

