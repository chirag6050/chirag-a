using Microsoft.AspNetCore.Identity;
using Chirag.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chirag.BookReading.Core.IRepositories;

namespace Chirag.BookReading.Infrastructure.Repository
{
    public class AccountRepository :IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(SignUp userSignUp)
        {
            var user = new IdentityUser()
            {

                UserName = userSignUp.userName,
                Email = userSignUp.email
            };

            var result = await _userManager.CreateAsync(user, userSignUp.password);
            return result;
        }

        public async Task<SignInResult> LoginUser(Login user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, true, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public string GetEmail(string organiser)
        {
            var result = _userManager.Users.FirstOrDefault(x => x.UserName == organiser).Email;
            return result;

        }

    }
}
