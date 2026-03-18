using AttendanceTracker.Application.DTO.RoleDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Interface.IService
{
    public interface IServiceRole
    {
        Task<IEnumerable<RoleReadDTO>> GetAllRoles();
        Task<RoleReadDTO> GetRoleById(int id);
        Task CreateRole(RoleCreateDTO role);
        Task UpdateRole(RoleUpdateDTO role);
        Task DeleteRole(int id);
    }
}
