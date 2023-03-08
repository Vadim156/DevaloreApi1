using BusinessLogic.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevaloreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<UserController>
        [HttpGet("/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            if(_userRepository!=null)
            return Ok(_userRepository.GetAllUsers());
            else
                return StatusCode(500);
        }

        // GET api/<UserController>/5
        [HttpGet("/GetUser/{id}")]
        public IActionResult GetUser(Guid id)
        {
            if (_userRepository != null)
                return Ok(_userRepository.GetUser(id));
            else if (id == null)
                return BadRequest();
            else
                return StatusCode(500);
        }

        // POST api/<UserController>
        [HttpPost("/CreateNewUser")]
        public void CreateNewUser([FromBody] User user)
        {
            if (_userRepository != null && user!=null)
                _userRepository.CreateUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("/UpdateUserData/{id}")]
        public void UpdateUserData(Guid id, [FromBody] User UserValue)
        {
           User user = _userRepository.GetUser(id);
            user.BirthDate = UserValue.BirthDate;
            user.Name = UserValue.Name;
            user.Country = UserValue.Country;
            user.Email = UserValue.Email;
            user.Phone = UserValue.Phone;
            _userRepository.UpdateUser(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("/Delete/{id}")]
        public void Delete(Guid id)
        {
            User user = _userRepository.GetUser(id);
            _userRepository.DeleteUser(user);
        }
    }
}
