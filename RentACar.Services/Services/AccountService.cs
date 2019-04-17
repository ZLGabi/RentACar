using Microsoft.Owin.Security;
using RentACar.DataContext.Models;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RentACar.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _roleRepository = _unitOfWork.GetRepository<Role>();
        }

        public UserDTO GetUser(int id)
        {
            var user = _userRepository.GetAll().Include(p => p.Photo).FirstOrDefault(u => u.UserId == id);
            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public List<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll().Include(p => p.Photo).ToList();
            var usersDTO = AutoMapper.Mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public List<UserDTO> GetManagers()
        {
            var managers = _userRepository.GetAll().Where(u => u.Roles.Any(r => r.Name == "Manager")).Include(p => p.Photo).ToList();
            var managersDTO = AutoMapper.Mapper.Map<List<UserDTO>>(managers);
            return managersDTO;
        }

        public List<UserDTO> GetCustomers()
        {
            var customers = _userRepository.GetAll().Where(u => u.Roles.Any(r => r.Name == "Customer")).Include(p => p.Photo).ToList();
            var customersDTO = AutoMapper.Mapper.Map<List<UserDTO>>(customers);
            return customersDTO;
        }

        public void AddUser(UserDTO userDTO)
        {
            byte[] passHash, passSalt;
            CreatePasswordHash(userDTO.Password, out passHash, out passSalt);
            var user = AutoMapper.Mapper.Map<User>(userDTO);
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;
            _userRepository.Add(user);
            _unitOfWork.Commit();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }

        public bool UserExists(string username)
        {
            if (_userRepository.GetAll().Any(x => x.Username == username))
                return true;

            return false;
        }

        public void AddUserToRole(string username, string roleName)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username);
            var role = _roleRepository.GetAll().FirstOrDefault(r => r.Name == roleName);
            user.Roles = new List<Role>();
            user.Roles.Add(role);
            _userRepository.Update(user);
            _unitOfWork.Commit();

        }

        public void ClearUserRoles(int userId)
        {
            var user = _userRepository.Get(userId);
            user.Roles.Clear();
            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void Login(UserLoginDTO userLoginDTO)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == userLoginDTO.Username);
            if (user != null)
            {
                if (VerifyPasswordHash(userLoginDTO.Password, user.PasswordHash, user.PasswordSalt))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                    var userIdentity = new ClaimsIdentity("ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);
                    userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
                    userIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        user.UserId.ToString()));
                    userIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    if (user.Roles.Count > 0)
                    {
                        foreach (var role in user.Roles)
                        {
                            userIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                        }
                    }
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                }
            }
        }

        public void Logout()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}