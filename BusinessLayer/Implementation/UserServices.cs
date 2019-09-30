using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataAccess.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly MapperProfile _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserServices(
            IUserRepository userRepository,
            MapperProfile mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            List<UserViewModel> viewUsers = new List<UserViewModel>();
            foreach (var user in users)
            {
                viewUsers.Add(_mapper.UserToUserViewModel(user));
            }
            return viewUsers;
            
        }

        public UserViewModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserById(string id)
        {
            UserExist(id : id);
            var user = _userRepository.GetById(id);

            var viewUser = _mapper.UserToUserViewModel(user);
            return viewUser;
        }

        public string LogInUser(LoginUserViewModel model)
        {
            
            SignInResult signInResult = _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false).Result;
            if (signInResult.IsNotAllowed)
            {
                throw new ArgumentException("Email or password are wrong!");
            }

            var user = _userRepository.GetByEmail(model.Email);
            return user.Id;

        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public void RegisterUser(RegisterUserViewModel model)
        {

            UserExist(email : model.Email);
            if (model.Password != model.ConfirmPassword)
                throw new ArgumentException("Passwords does not match!");
            var user = _mapper.RegisterToUserModel(model);
            IdentityResult identityResult = _userManager.CreateAsync(user, model.Password).Result;
            if (identityResult.Succeeded)
            {
                User currentUser = _userManager.FindByEmailAsync(user.Email).Result;
                _userManager.AddToRoleAsync(currentUser, "User");
            }
            else
            {
                //TODO: Find way to add password errors to the view
                throw new ArgumentException(identityResult.Errors.ToString());
            }

            LogInUser(new LoginUserViewModel { Email = model.Email, Password = model.Password });
            //_userRepository.Insert(user);

            
        }





        void UserExist(string email = null, string id = null)
        {
            User user;
            if (email != null) user = _userRepository.GetByEmail(email);
            else user = _userRepository.GetById(id);    
            
            if (user != null)
            {
                throw new ArgumentException($"user alredy exists");
            }

        }
    }
}
