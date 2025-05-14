using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// [ApiController]
// [Route("api/[Controller]")] // /api/users
public class UsersController:BaseApiController
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }
[HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>>GetUserS()
{
    var users = await _context.Users.ToListAsync();

    return Ok(users);
}

[HttpGet("{id:int}")]  //api/users/3
public async Task<ActionResult<AppUser>>GetUsers(int id)
{
    var user = await _context.Users.FindAsync(id);

     if(user == null) return NotFound();  //404 error

        return user;
}
}
