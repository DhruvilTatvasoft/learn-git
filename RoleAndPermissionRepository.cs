using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;

namespace DAL.Implementations
{
    public class RoleAndPermissionRepository : IRoleAndPermissionRepository
    {
        private readonly PizzashopCContext _context;

        public RoleAndPermissionRepository(PizzashopCContext context)
        {
            _context = context;
        }

        public void AddPermission(Rolesandpermission permission)
        {
            var exists = _context.Rolesandpermissions
                .Any(p => p.Permissionid == permission.Permissionid && p.Roleid == permission.Roleid);

            if (!exists)
            {
                _context.Rolesandpermissions.Add(permission);
                _context.SaveChanges();
            }
        }

        public void UpdatePermission(Rolesandpermission permission)
        {
            _context.Rolesandpermissions.Update(permission);
            _context.SaveChanges();
        }

        public void RemovePermission(int permissionId, int roleId)
        {
            var permission = _context.Rolesandpermissions.FirstOrDefault(p => p.Permissionid == permissionId && p.Roleid == roleId);
            if (permission != null)
            {
                _context.Rolesandpermissions.Remove(permission);
                _context.SaveChanges();
            }
        }

        public Rolesandpermission GetPermission(int permissionId, int roleId)
        {
            return _context.Rolesandpermissions.FirstOrDefault(p => p.Permissionid == permissionId && p.Roleid == roleId);
        }
    }
}