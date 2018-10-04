using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models
{
  public class UserLogin //Helper Model
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }

  public class UserRegistration //Helper Model
  {
    [Required]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }

  public class User
  {
    public string UserId { get; set; }
    public bool Active { get; set; } = true;
    public string Username { get; set; }
    [Required]
    internal string Hash { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public ClaimsPrincipal _principal { get; private set; }


    // public User() { }
    internal void SetClaims()
    {
      var claims = new List<Claim> {
        new Claim(ClaimTypes.Email, Email),
        new Claim(ClaimTypes.Thumbprint, UserId) //req.sessions.uid = id
      };
      var UserIdentity = new ClaimsIdentity(claims, "login");
      _principal = new ClaimsPrincipal(UserIdentity);
    }
  }
}