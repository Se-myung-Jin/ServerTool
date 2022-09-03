namespace DatabaseLib
{
    public interface IUsersData
    {
        Task<Users> SelectUser(Users user);
        Task<bool> InsertUsers(Users user);
    }
}