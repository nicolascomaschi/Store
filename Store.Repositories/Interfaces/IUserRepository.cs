using Microsoft.AspNetCore.Identity;
using Store.Common.Data.Entities;
using Store.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable GetUsers();

        List<User> GetCustomers();

        Task RemoveUserFromRoleAsync(User user, string roleName);

        Task<User> GetUserByUserNameAsync(string userName);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByIdAsync(string id);

        Task<IdentityResult> AddUserAsync(User user, string password, UserType userType);

        Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> UpdateSecurityStampAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

    }
}
