namespace DatabaseLib
{
    public interface IUsersData
    {
        Task<bool> InsertUsers(Users user);
    }
}