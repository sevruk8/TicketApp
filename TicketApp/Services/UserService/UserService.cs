using Database;
using Database.Database.Entities;
using Database.Database.Enums;
using Identity.Abstractions;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using TicketApp.Service.UserService.Abstractions;
using TicketApp.Service.UserService.Abstractions.Models;
using TicketApp.Services.UserService.Models;
using Utils;

namespace TicketApp.Service.UserService
{

    /// <summary>
    /// Класс реализующий интерфейс действий пользователя
    /// </summary>
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly ITokenAuthorization _tokenAuthorizationService;

        public UserService(DatabaseContext context, ITokenAuthorization tokenAuthorizationService)
        {
            _dbContext = context;
            _tokenAuthorizationService = tokenAuthorizationService;
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        
        public async Task<Token> Authorization(AuthorizationModel authorizationModel)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(x => x.Login == authorizationModel.Login);
            if (existingUser != null)
            {
                if ((authorizationModel.Password + existingUser.PasswordSalt) == existingUser.PasswordHash)
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(authorizationModel.Login), new[] { new Claim("login", authorizationModel.Login), new Claim("email", existingUser.Email ?? string.Empty) });
                    var token = await _tokenAuthorizationService.GetToken(identity);
                    return token;
                }
                else
                {
                    throw new Exception("Неверный пароль");
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином не найден");
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        /// 
        
        public async Task Registration(RegistrationModel registrationModel)
        {
            var salt = new Random();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Type = UserType.User,
                Login = registrationModel.Login,
                Email = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                PasswordSalt = salt.GenerateSalt(),
                PasswordHash = (registrationModel.Password + salt)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Регистрация администратора
        /// </summary>
        /// <param name="registrationAdminModel"></param>
        /// <returns></returns>
        /// 

        public async Task RegistrationAdmin(RegistrationAdminModel registrationAdminModel)
        {
            var salt = Convert.ToString(Guid.NewGuid());

            User user = new User
            {
                Id = Guid.NewGuid(),
                Type = UserType.Admin,
                Login = registrationAdminModel.Login,
                Email = registrationAdminModel.Email,
                FirstName = registrationAdminModel.FirstName,
                LastName = registrationAdminModel.LastName,
                PasswordSalt = salt,
                PasswordHash = (registrationAdminModel.Password + salt)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }


        public Guid CreateUser(UserInfo userInfo)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Type = userInfo.Type
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }
        public void DeleteUser(Guid Id)
        {
            var user = _dbContext.Users.First(e => e.Id == Id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<UserShortModel> GetAllUsers()
        {
            var users = _dbContext.Users;

            var resultUsers = new List<UserShortModel>();

            foreach (var dbUser in users)
            {
                var user = new UserShortModel()
                {
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Id = dbUser.Id,
                    Type = dbUser.Type
                };
                resultUsers.Add(user);
            }

            return resultUsers;
        }

        
        public UserModel GetUser(Guid Id)
        {
            var dbUser = _dbContext.Users.First(e => e.Id == Id);

            var user = new UserModel()
            {
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Id = dbUser.Id,
                Type = dbUser.Type

            };

            return user;
        }

        
        public void UpdateUser(Guid Id, UserInfo userInfo)
        {
            var user = _dbContext.Users.First(e => e.Id == Id);

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Type = userInfo.Type;

            _dbContext.SaveChanges();
        }

    }
}
