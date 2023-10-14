using CFA_JWT_AUTH.Models;
using Microsoft.AspNetCore.Mvc;

namespace CFA_JWT_AUTH.IRepository
{
    public interface IUser
    {
        public Task<IEnumerable<UserDetailsModel>> GetUserDetails();
        public Task<IEnumerable<UserDetailsModel>> GetUserDetailsById(int id);
        public Task PutUserDetailsModel(int id, [FromForm] UserDetailsModel userDetailsModel);
        public Task PostUserDetailsModel([FromForm] UserDetailsModel userDetailsModel);
        public Task DeleteUserDetailsModel(int id);

    }
}
