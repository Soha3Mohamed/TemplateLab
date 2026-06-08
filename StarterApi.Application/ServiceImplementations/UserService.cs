using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StarterApi.Application.Common;
using StarterApi.Application.DTOs.UserDTOs;
using StarterApi.Application.ServiceInterfaces;
using StarterApi.Domain.Common;
using StarterApi.Domain.Entities;
using StarterApi.Infrastructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StarterApi.Application.ServiceImplementations
{
    internal class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(
            ILogger<UserService> logger,
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResult<string>> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !PasswordHasher.VerifyPassword(user.PasswordHash, password))
            {
                _logger.LogWarning("Authentication failed for email {Email}", email);
                return ServiceResult<string>.Fail("Invalid credentials");
            }

            var token = GenerateToken(user);

            return ServiceResult<string>.Ok(token);
        }

        public async Task<ServiceResult<string>> ChangePasswordAsync(
            int userId,
            string currentPassword,
            string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                _logger.LogWarning("User not found: {UserId}", userId);
                return ServiceResult<string>.Fail("User not found");
            }

            // FIXED: must verify CURRENT password, not new password
            if (!PasswordHasher.VerifyPassword(user.PasswordHash, currentPassword))
            {
                return ServiceResult<string>.Fail("Current password is incorrect");
            }

            if (PasswordHasher.VerifyPassword(user.PasswordHash, newPassword))
            {
                return ServiceResult<string>.Fail("New password cannot be same as old password");
            }

            user.PasswordHash = PasswordHasher.Hash(newPassword);
            user.LastUpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            _logger.LogInformation("Password changed for user {UserId}", userId);

            return ServiceResult<string>.Ok("Password changed successfully");
        }

       

        private string GenerateToken(User user)
        {
            var key = _configuration["Jwt:Key"];

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public async Task<ServiceResult<UserResponseDTO>> CreateUserAsync(UserRequestDTO userRequest)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userRequest.Email);

            if (existingUser != null)
                return ServiceResult<UserResponseDTO>.Fail("Email already exists");

            var user = _mapper.Map<User>(userRequest);

            user.PasswordHash = PasswordHasher.Hash(userRequest.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.LastUpdatedAt = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var dto = _mapper.Map<UserResponseDTO>(user);

            return ServiceResult<UserResponseDTO>.Ok(dto);
        }


        public async Task<ServiceResult<bool>> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return ServiceResult<bool>.Fail("User not found");

            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

        public async Task<ServiceResult<IEnumerable<UserResponseDTO>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null || !users.Any())
                return ServiceResult<IEnumerable<UserResponseDTO>>.Fail("No users found");

            var dto = _mapper.Map<IEnumerable<UserResponseDTO>>(users);

            return ServiceResult<IEnumerable<UserResponseDTO>>.Ok(dto);
        }

        public async Task<ServiceResult<UserResponseDTO>> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return ServiceResult<UserResponseDTO>.Fail("User not found");

            var dto = _mapper.Map<UserResponseDTO>(user);

            return ServiceResult<UserResponseDTO>.Ok(dto);
        }

        public async Task<ServiceResult<UserResponseDTO>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return ServiceResult<UserResponseDTO>.Fail("User not found");

            var dto = _mapper.Map<UserResponseDTO>(user);

            return ServiceResult<UserResponseDTO>.Ok(dto);
        }

        public async Task<ServiceResult<UserResponseDTO>> UpdateUserAsync(int id, UserUpdateDTO userRequest)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return ServiceResult<UserResponseDTO>.Fail("User not found");

            var existingEmailUser = await _userRepository.GetByEmailAsync(userRequest.Email);

            if (existingEmailUser != null && existingEmailUser.Id != id)
                return ServiceResult<UserResponseDTO>.Fail("Email already exists");

            _mapper.Map(userRequest, user);

            user.LastUpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            var dto = _mapper.Map<UserResponseDTO>(user);

            return ServiceResult<UserResponseDTO>.Ok(dto);
        }
    }
}
