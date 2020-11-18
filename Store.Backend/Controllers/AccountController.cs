//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Backend.Helpers;
using Store.Common.Data.Entities;
using Store.Common.Helpers;
using Store.Common.Resources;
using Store.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Backend.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        //private readonly IConverterHelper _converterHelper;

        public AccountController(
            IUserRepository userRepository,
            IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        //[HttpPost]
        //public async Task<IActionResult> PostUser([FromBody] User request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new Response
        //        {
        //            IsSuccess = false,
        //            Message = "Bad request",
        //            Result = ModelState
        //        });
        //    }

        //    User user = await _userRepository.GetUserByUserNameAsync(request.UserName);
        //    if (user != null)
        //    {
        //        return BadRequest(new Response
        //        {
        //            IsSuccess = false,
        //            Message = Strings.MsjUserExist
        //        });
        //    }

        //    user = new User
        //    {
        //        Address = request.Address,
        //        Email = request.Email,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        PhoneNumber = request.PhoneNumber,
        //        UserName = request.UserName,
        //    };

        //    IdentityResult result = await _userRepository.AddUserAsync(user, request.Password);
        //    if (result != IdentityResult.Success)
        //    {
        //        return BadRequest(result.Errors.FirstOrDefault().Description);
        //    }

        //    User userNew = await _userRepository.GetUserByUserNameAsync(request.UserName);
        //    await _userRepository.AddUserToRoleAsync(userNew, "Customer");

        //    return Ok(new Response
        //    {
        //        IsSuccess = true,
        //        Message = Strings.MsjUSerRegister,
        //    });
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPut]
        //public async Task<IActionResult> PutUser([FromBody] UserRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    User userEntity = await _userRepository.GetUserByUserNameAsync(request.UserName);
        //    if (userEntity == null)
        //    {
        //        return BadRequest(Strings.MsjUserDoesntExists);
        //    }

        //    userEntity.FirstName = request.FirstName;
        //    userEntity.LastName = request.LastName;
        //    userEntity.Address = request.Address;
        //    userEntity.PhoneNumber = request.PhoneNumber;
        //    userEntity.UserName = request.UserName;
        //    userEntity.Email = request.Email;

        //    IdentityResult respose = await _userRepository.UpdateUserAsync(userEntity);
        //    if (!respose.Succeeded)
        //    {
        //        return BadRequest(respose.Errors.FirstOrDefault().Description);
        //    }

        //    return NoContent();
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[Route("ChangePassword")]
        //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new Response
        //        {
        //            IsSuccess = false,
        //            Message = "Bad request",
        //            Result = ModelState
        //        });
        //    }

        //    User user = await _userRepository.GetUserByUserNameAsync(request.UserName);
        //    if (user == null)
        //    {
        //        return BadRequest(new Response
        //        {
        //            IsSuccess = false,
        //            Message = Strings.MsjUserDoesntExists
        //        });
        //    }

        //    IdentityResult result = await _userRepository.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        var message = result.Errors.FirstOrDefault().Description;
        //        return BadRequest(new Response
        //        {
        //            IsSuccess = false,
        //            Message = message.Contains("password") ? Strings.MsjIncorrectPassword : message
        //        });
        //    }

        //    return Ok(new Response
        //    {
        //        IsSuccess = true,
        //        Message = Strings.MsjPasswordChangedSuccess
        //    });
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[Route("UserByUserName")]
        //public async Task<IActionResult> UserByUserName([FromBody] UserRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    User userEntity = await _userRepository.GetUserByUserNameAsync(request.UserName);
        //    if (userEntity == null)
        //    {
        //        return NotFound(Strings.MsjUserDoesntExists);
        //    }

        //    var cart = await _orderRepository.GetCartAsync(userEntity.UserName);

        //    var user = new Common.Models.User
        //    {
        //        FirstName = userEntity.FirstName,
        //        LastName = userEntity.LastName,
        //        UserName = userEntity.UserName,
        //        Email = userEntity.Email,
        //        PhoneNumber = userEntity.PhoneNumber,
        //        Address = userEntity.Address,
        //        FullName = userEntity.FullName,
        //        Carts = cart,
        //    };

        //    return Ok(user);
        //}

    }
}
