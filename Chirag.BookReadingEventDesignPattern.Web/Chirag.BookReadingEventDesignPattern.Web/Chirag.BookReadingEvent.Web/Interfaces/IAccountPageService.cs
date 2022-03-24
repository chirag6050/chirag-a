using Chirag.BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirag.BookReadingEvent.Web.Interfaces
{
    public interface IAccountPageService
    {
        Task<IdentityResult> CreateUser(SignUpViewModel signUpViewModel);

        Task<SignInResult> LoginUser(LoginViewModel loginViewModel);

        Task SignOut();
        string GetEmail(string organiser);
    }
}
