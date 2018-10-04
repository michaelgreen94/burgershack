using System.Threading.Tasks;
using burgershack.Repositories;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace burgershack.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly UserRepository _repo;

    [HttpPost("Login")]
    public async Task<User> Login([FromBody]UserLogin creds)
    {
      if (!ModelState.IsValid) { return null; }
      User user = _repo.Login(creds);
      if (user == null) { return null; }
      user.SetClaims();
      await HttpContext.SignInAsync(user._principal);
      return user;
    }

    [HttpPost("Register")]
    public async Task<User> Register([FromBody]UserRegistration creds)
    {
      if (!ModelState.IsValid) { return null; }
      User user = _repo.Register(creds);
      if (user == null) { return null; }
      user.SetClaims();
      await HttpContext.SignInAsync(user._principal);
      return user;
    }

    [HttpDelete("Logout")]
    public async Task<bool> Logout()
    {
      await HttpContext.SignOutAsync();
      return true;
    }
    [Authorize]
    [HttpGet("Authenticate")]
    public User Authenticate()
    {
      var Id = HttpContext.User.Identity.Name;
      return _repo.GetUserById(Id);
    }

    public AccountController(UserRepository repo)
    {
      _repo = repo;
    }
  }
}