using UserManagement.Data.Models;

namespace UserManagement.Data.IRepository
{
    public interface IUser
    {
        public Task<IEnumerable<UserDetailsModel>> GetUserDetails();
        public Task<IEnumerable<UserDetailsModel>> GetUserDetailsById(int id);
        public Task PutUserDetailsModel(int id, UserDetailsModel userDetailsModel);
        public Task PostUserDetailsModel( UserDetailsModel userDetailsModel);
        public Task DeleteUserDetailsModel(int id);

    }
}
