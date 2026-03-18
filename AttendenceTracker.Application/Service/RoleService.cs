using AttendanceTracker.Application.DTO.RoleDTO;
using AttendanceTracker.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Service
{
    public class RoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RoleReadDTO>> GetAllRoles()
        {
            var roles = await _repository.GetAllRolesAsync();
            return roles.Select(r => new RoleReadDTO
            {
                Id = r.RoleID,
                RoleName = r.RoleName,
            });
        }
        public async Task<RoleReadDTO> GetRoleById(int id)
        {
            var role = await _repository.GetRolesAsync(id);
            if (role == null) return null;

            return new RoleReadDTO
            {
                Id = role.RoleID,
                RoleName = role.RoleName,
            };
        }
        public async Task CreateRole(RoleReadDTO DTO)
        {
            var role = new Role
            {
                RoleName = dto.RoleName,
            };
            await _repository.AddRoleAsync(role);
        }

        public async Task UpdateRole(RoleReadDTO DTO)
        {
            var role = new Role
            {
                Id = DTO.Id,
                RoleName = DTO.RoleName
            };
            await _repository.UpdateRoleAsync(role);
        }
        public async Task DeleteRole(int id)
        {
            await _repository.DeleteRoleAsync(id);

        }
    }
}
