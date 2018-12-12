using System.Collections.Generic;
using RentACar.RepositoryInfrastructure;
using RentACar.ServicesInfrastructure;
using RentACar.ServicesInfrastructure.DTO;
using System.Data.Entity;
using RentACar.DataContext.Models;

namespace RentACar.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }
        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.Get(id);
            var userDTO = AutoMapper.Mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll();
            var usersDTO = AutoMapper.Mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
           
            _carRepository.Add(user);
            _unitOfWork.Commit();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
           
            _carRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(UserDTO userDTO)
        {
            var user = AutoMapper.Mapper.Map<User>(userDTO);
           
            _carRepository.Delete(user);
            _unitOfWork.Commit();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
                
            return false;
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