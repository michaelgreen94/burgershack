using System.Threading.Tasks;
using burgershack.Repositories;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace burgershack.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly UserRepository _repo;

    [HttpPost("Login")]
    public async Task<UserRepository> Login([FromBody]UserLogin creds)
    {
      if (!ModelState.IsValid) { return null; }
      User user = _repo.Login(creds);
      if (user == null) { return null; }
      user.SetClaims();
      await HttpContext.SignInAsync(user._principal);
    }

    public AccountController(UserRepository repo)
    {
      _repo = repo;
    }
  }
}