//namespace UserManagement.Business
//{
//    public abstract class UserManager
//    {
//        public async Task<IEnumerable<UserDetailsModel>> GetUserDetails()
//        {
//            return await _context.UserDetails.ToListAsync();
//        }
//        public async Task<IEnumerable<UserDetailsModel>> GetUserDetailsById(int id)
//        {
//            var userDetailsModel = await _context.UserDetails.FindAsync(id);
//            if (userDetailsModel != null)
//            {
//                return new List<UserDetailsModel> { userDetailsModel };
//            }
//            return new List<UserDetailsModel>();
//        }
//        public async Task PutUserDetailsModel(int id, [FromForm] UserDetailsModel userDetailsModel)
//        {
//            _context.Entry(userDetailsModel).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//        }
//        public async Task PostUserDetailsModel([FromForm] UserDetailsModel userDetailsModel)
//        {
//            _context.UserDetails.Add(userDetailsModel);
//            await _context.SaveChangesAsync();
//        }
//        public async Task DeleteUserDetailsModel(int id)
//        {
//            var delete = await _context.UserDetails.FindAsync(id);
//            _context.UserDetails.Remove(delete);
//            await _context.SaveChangesAsync();
//        }
//    }
//}