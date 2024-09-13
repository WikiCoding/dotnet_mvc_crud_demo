using Microsoft.EntityFrameworkCore;

namespace mvcdemo.Repository
{
    public class MembersRepository : IMembersRepository
    {
        private readonly AppDbContext _appDbContext;

        public MembersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MemberDataModel?> GetByUsername(string username)
        {
            return await _appDbContext.Members.Where(member => member.Username == username).FirstOrDefaultAsync();
        }

        public async Task<MemberDataModel?> GetMember(Guid id)
        {
            return await _appDbContext.Members.Where(member => member.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveMember(MemberDataModel member)
        {
            _appDbContext.Add(member);
            await _appDbContext.SaveChangesAsync();
        }
    }
}