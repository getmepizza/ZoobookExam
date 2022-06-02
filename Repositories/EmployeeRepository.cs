using Dapper;

namespace ZoobookExam.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            string selectQuery = "SELECT * FROM EMPLOYEES WHERE EMPLOYEEID = @employeeId";

            using (var connection = _context.CreateConnection)
            {
                var result = await connection.QuerySingleOrDefaultAsync(selectQuery, new { employeeId = id });
                return result;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            string query = "SELECT * FROM EMPLOYEES";

            using (var connection = _context.CreateConnection)
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<int> AddAsync(Employee entity)
        {
            string query = "INSERT INTO EMPLOYEES (FIRSTNAME,MIDDLENAME,LASTNAME) VALUES (@FIRSTNAME,@MIDDLENAME,@LASTNAME)";
            using (var connection = _context.CreateConnection)
            {
                var queryResult = await connection.ExecuteAsync(query, entity);
                return queryResult;
            }
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            string updateQuery = "UPDATE EMPLOYEES SET FIRSTNAME = @FIRSTNAME, MIDDLENAME = @MIDDLENAME, LASTNAME = @LASTNAME " +
                "WHERE EMPLOYEEID = @EMPLOYEEID";

            using (var connection = _context.CreateConnection)
            {
                var result = await connection.ExecuteAsync(updateQuery, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int employeeId)
        {
            string deleteQuery = "DELETE FROM EMPLOYEES WHERE EMPLOYEEID = @employeeId";

            using (var connection = _context.CreateConnection)
            {
                var result = await connection.ExecuteAsync(deleteQuery, new { employeeId = employeeId });
                return result;
            }
        }



    }
}
