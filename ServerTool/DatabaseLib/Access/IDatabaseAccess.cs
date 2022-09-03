namespace DatabaseLib
{
    public interface IDatabaseAccess
    {
        string ConnectionString { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<bool> SaveData<T>(string sql, T parameters);
    }
}