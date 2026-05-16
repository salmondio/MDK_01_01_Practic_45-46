using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Practic_45.Contexts;
using Practic_45.Models;

namespace Practic_45.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ///<summary>
        ///Регистрация пользователя
        /// </summary>
        /// <returns>Данный метод нужен для регистрации пользователя на сайте</returns>
        /// /// <response code="200">Пользователь успешно зарегестрирован</response>
        /// /// <response code="403">Ошибка запроса. Данные не указаны.</response>
        /// /// <response code="402">Ошибка запроса. Логин уже используется.</response>
        /// /// <response code="500">При выполнении запроса возникла ошибка</response>
        //[Route("SignIn")]
        [HttpPost("Registration")]
        //[ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult Registration([FromBody] Models.User user)
        {
            if (user.Login == null && user.Password == null)
                return StatusCode(403);

            UserContext userContext = new UserContext();
            if (userContext.Users.Any(x => x.Login == user.Login))
                return StatusCode(402);

            try
            {
                Models.User newUser = new Models.User()
                {
                    Login = user.Login, Password = user.Password
                };
                userContext.Users.Add(newUser);
                userContext.SaveChanges();

                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        ///Авторизация пользователя
        /// </summary>
        /// <returns>Данный метод нужен для авторизации пользователя на сайте</returns>
        /// /// <response code="200">Пользователь успешно авторизован</response>
        /// /// <response code="403">Ошибка запроса. Данные не указаны.</response>
        /// /// <response code="500">При выполнении запроса возникла ошибка</response>
        //[Route("SignIn")]
        [HttpPost("SignIn")]
        //[ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult SignIn([FromBody] Models.User user)
        {
            if(user.Login == null && user.Password == null)
            {
                return StatusCode(403);
            }
            try
            {
                UserContext userContext = new UserContext();
                User? foundUser = userContext.Users.Where(x => x.Login == user.Login && x.Password == user.Password).First();

                if (foundUser == null)
                    return Unauthorized(new { message = "Неверный логин или пароль" });

                if (foundUser.Hash.IsNullOrEmpty())
                {
                    foundUser.Hash = Helpers.HashHelper.CreateToken(foundUser.Id);
                    userContext.SaveChanges();
                }

                return Ok(new
                {
                    user = foundUser,
                    message = "Авторизация успешна"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {error = ex.Message});
            }
        }

        [HttpPut("ChangeUser")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult ChangeUser([FromBody] Models.User user)
        {
            try
            {
                UserContext uContext = new UserContext();
                User previousUser = uContext.Users.Where(u => u.Id == user.Id).First();

                if(previousUser != null)
                {
                    previousUser.Login = user.Login;
                    previousUser.Password = user.Password;

                    uContext.SaveChanges();

                    return Ok(previousUser);
                }
                else
                {
                    User newUser = new User()
                    {
                        Login = user.Login,
                        Password = user.Password
                    };

                    uContext.Users.Add(newUser);

                    return Ok(newUser);
                }
            }
            catch {  return StatusCode(500); }
        }
    }
}
