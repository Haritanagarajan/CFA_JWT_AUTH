#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.IRepository;
using UserManagement.Data.Models;

namespace UserManagement.Data.Repository
{
    public class UserManagementRepo : IUser
    {
        private readonly UserDbContext _context;

        public UserManagementRepo(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDetailsModel>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }
        public async Task<IEnumerable<UserDetailsModel>> GetUserDetailsById(int id)
        {
            var userDetailsModel = await _context.UserDetails.FindAsync(id);
            if (userDetailsModel != null)
            {
                return new List<UserDetailsModel> { userDetailsModel };
            }
            return new List<UserDetailsModel>();
        }
        public async Task PutUserDetailsModel(int id,  UserDetailsModel userDetailsModel)
        {
            _context.Entry(userDetailsModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task PostUserDetailsModel( UserDetailsModel userDetailsModel)
        {
            _context.UserDetails.Add(userDetailsModel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserDetailsModel(int id)
        {
            var delete = await _context.UserDetails.FindAsync(id);
            _context.UserDetails.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }
}

