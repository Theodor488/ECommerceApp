using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;
using ECommerceAPI.Services;

namespace ECommerceAPI.Controllers;

// Receives login requests (POST /login).
// Uses LoginService to authenticate the user.
// Sends the appropriate response (success or failure, with messages or tokens).

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    public LoginController()
    {
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        LoginService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(Guid id)
    {
        var user = LoginService.Get(id);

        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {            
        LoginService.Register(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPost("{input_username}")]
    public IActionResult AuthenticateUser(string input_username, User user)
    {            
        if (input_username != user.Username)
            return BadRequest();
        
        var existingUser = LoginService.Get(user.Id);
        if (existingUser is null)
            return NotFound();

        string input_password = user.Password;

        LoginService.AuthenticateLoginCredentials(input_username, input_password, user);           
    
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, User user)
    {
        if (id != user.Id)
            return BadRequest();
            
        var existingUser = LoginService.Get(id);
        if (existingUser is null)
            return NotFound();
    
        LoginService.Update(user);           
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var user = LoginService.Get(id);
    
        if (user is null)
            return NotFound();
        
        LoginService.Delete(id);
    
        return NoContent();
    }
}
