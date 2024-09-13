using mvcdemo.Repository;

namespace mvcdemo.Services
{
    public class MembersService
    {
        private readonly IMembersRepository _membersRepository;

        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public async Task<MemberDataModel?> GetMemberByUsername(string username)
        {
            return await _membersRepository.GetByUsername(username);
        }

        public async Task<MemberDataModel?> GetMemberById(Guid guid)
        {
            return await _membersRepository.GetMember(guid);
        }

        public async Task SaveMember(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("username or password must not be null or empty");
            }

            MemberDataModel memberDataModel = new()
            {
                Username = username,
                Password = password
            };

            await _membersRepository.SaveMember(memberDataModel);
        }
    }
}