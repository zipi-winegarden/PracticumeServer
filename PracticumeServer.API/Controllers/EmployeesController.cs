using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticumeServer.API.Models;
using PracticumeServer.Core.DTO_s;
using PracticumeServer.Core.Entites;
using PracticumeServer.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticumeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServise _employeesService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeServise employeesService, IMapper mapper)
        {

            this._employeesService = employeesService;
            this._mapper = mapper;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            var list = await _employeesService.GetEmployeeAsync();

            var listDTO = list.Select(d => _mapper.Map<EmployeeDTO>(d));

            return Ok(listDTO);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _employeesService.GetEmployeeByIdAsync(id);
            var resDTO = _mapper.Map<EmployeeDTO>(res);
            return resDTO != null ? Ok(resDTO) : NotFound(resDTO);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeePostModel empModel)
        {
            var emp = _mapper.Map<Employee>(empModel);
            var res = await _employeesService.AddAsync(emp);
            var resDTO = _mapper.Map<EmployeeDTO>(res);
            Console.WriteLine(resDTO.ToString());
            return res != null ? Ok(resDTO) : NotFound(resDTO);

        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel empModel)
        {

            var emp = _mapper.Map<Employee>(empModel);
            var res = await _employeesService.PutAsync(id, emp);
            var resDTO = _mapper.Map<EmployeeDTO>(res);
            return res != null ? Ok(resDTO) : NotFound(resDTO);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _employeesService.DeleteAsync(id);
            var resDto = _mapper.Map<EmployeeDTO>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }
    }
}
