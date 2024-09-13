namespace mvcdemo.Repository
{
    public interface IMembersRepository
    {
        Task<MemberDataModel?> GetByUsername(string username);
        Task<MemberDataModel?> GetMember(Guid id);
        Task SaveMember(MemberDataModel member);
    }
}