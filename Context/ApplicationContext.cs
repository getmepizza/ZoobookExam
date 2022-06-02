


namespace ZoobookExam.Context
{
    public class ApplicationContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public ApplicationContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
