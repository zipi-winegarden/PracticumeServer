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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {

            this._roleService = roleService;
            this._mapper = mapper;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            var list = await _roleService.GetRoleAsync();

            var listDTO = list.Select(d => _mapper.Map<RoleDTO>(d));

            return Ok(listDTO);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _roleService.GetRoleByIdAsync(id);
            var resDTO = _mapper.Map<RoleDTO>(res);
            return resDTO != null ? Ok(resDTO) : NotFound(resDTO);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel rlModel)
        {
            var role = _mapper.Map<Role>(rlModel);
            var res = await _roleService.AddAsync(role);
            var resDTO = _mapper.Map<RoleDTO>(res);
            return res != null ? Ok(resDTO) : NotFound(resDTO);

        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RolePostModel rlModel)
        {
            var role = _mapper.Map<Role>(rlModel);
            var res = await _roleService.PutAsync(id, role);
            var resDTO = _mapper.Map<RoleDTO>(res);
            return res != null ? Ok(resDTO) : NotFound(resDTO);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _roleService.DeleteAsync(id);
            var resDto = _mapper.Map<RoleDTO>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }
    }
}
