

namespace ZoobookExam.Controllers
{
    public class EmployeeController : BaseController
    {
        public IEmployeeRepository _employeeRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeRepository.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound("Record not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeeDto)
        {
            var result = await _employeeRepository.AddAsync(
                new Employee {
                    FirstName = employeeDto.FirstName,
                    MiddleName = employeeDto.MiddleName,
                    LastName = employeeDto.LastName
                });
            if (result == 0)
            {
                return BadRequest("An error occured");
            }

            return Ok("Record inserted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            var result = await _employeeRepository.UpdateAsync(
                new Employee
                {
                    employeeId = employeeDto.Id,
                    FirstName = employeeDto.FirstName,
                    MiddleName = employeeDto.MiddleName,
                    LastName = employeeDto.LastName
                });

            if (result == 0)
            {
                return BadRequest("Record not exist");
            }

            return Ok("Record updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeRepository.DeleteAsync(id);

            if (result == 0)
            {
                return BadRequest("An error occured");
            }

            return Ok("Record deleted");
        }
    }
}
