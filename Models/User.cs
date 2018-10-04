using System;
using System.ComponentModel.DataAnnotations;

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

    public User() { }
  }
}