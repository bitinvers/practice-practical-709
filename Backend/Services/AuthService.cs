using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services
{
  public class AuthService
  {
    private readonly IConfiguration config;
    private readonly AppDbContext db;

    public AuthService(IConfiguration config, AppDbContext db)
    {
      this.config = config;
      this.db = db;
    }

    public LoginResponse Login(LoginRequest request)
    {
      var response = new LoginResponse();
      // TODO: Implement login validation logic here.
      var user = db.AppUsers.SingleOrDefault(u => u.Username == request.Username);
      if (user == null)
      {
        response.Message = "Invalid username or password";
        return response;
      }
      if (user.Password != request.Password)
      {
        response.Message = "Invalid username or password";
        return response;
      }

      var token = GenerateUserToken(user);

      response.Token = token;
      response.Message = "Success";
      response.UserGroup = user.GroupId.ToString();

      return response;
    }

    private string GenerateUserToken(AppUser user)
    {
      var issuer = config["JwtSettings:Issuer"];
      var audience = config["JwtSettings:Audience"];

      var notBefore = DateTime.Now;
      var expires = DateTime.Now.AddHours(2);
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!));
      var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>
      {
        new Claim("group", user.GroupId.ToString())
      };
      //   TODO: Add appropriate claims to the 'claims' list above.

      var jwt = new JwtSecurityToken(
        issuer,
        audience,
        claims,
        notBefore,
        expires,
        signingCredentials);

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      return encodedJwt;
    }
  }
}