using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
  public class User
  {
    public Guid UserId { get; private set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [MinLength(6)]
    private string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public User()
    {
      new User() { };
    }
  }
}