using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement_WebAPI.Models;
using UserManagement_WebAPI.Repository;

namespace UserManagement_WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;

        public UserController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userRepo.GetUsers().ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepo.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserDto user)
        {
            var newUser = new User() {UserId=id, Email=user.Email, Password=user.Password, UserName = user.UserName, FullName = user.FullName };

            _userRepo.UpdateUser(newUser);

            try
            {
                _userRepo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_userRepo.ExistUser(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<User> PostUser(UserDto user)
        {
            
            _userRepo.InsertUser(user);
            try
            {
                _userRepo.Save();
            }
            catch (DbUpdateException)
            {
                if (_userRepo.ExistUser(user.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepo.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepo.DeleteUser(id);
            _userRepo.Save();

            return NoContent();
        }

        //private bool UserExists(int id)
        //{
        //    return _userRepo.(e => e.UserId == id);
        //}
    }
}
