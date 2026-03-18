using AttendanceTracker.Domain.Interface.IRepository;
using AttendanceTracker.Infrastructure.Dbcontext;
using AttendenceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Infrastructure.Repository
{
    //public class RoleRepository:IRoleRepository
    //{
    //    private readonly AttendanceDbContext _context;
    //    public RoleRepository(AttendanceDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    //    {
    //        return await _context.Roles.ToListAsync();
    //    }
    //    public async Task<Role> GetRoleAsync(int id)
    //    {
    //        return await _context.Roles.FindAsync(id);
    //    }

    //    public async Task AddAsync(Role role)
    //    {
    //        await _context.Roles.AddAsync(role);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task UpdateAsync(Role role)
    //    {
    //        _context.Roles.Update(role);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteRoleAsync(int id)
    //    {
    //        var role = await _context.Roles.FindAsync(id);
    //        if (role == null)
    //        {
    //            _context.Roles.Remove(role);
    //            await _context.SaveChangesAsync();
    //        }
    //    }

    public class RoleRepository : IRoleRepository
    {
        private readonly AttendanceDbContext _context;

        public RoleRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }

}

