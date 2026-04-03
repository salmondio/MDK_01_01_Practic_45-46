using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;
using Practic_45.Models;

namespace Practic_45.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ///<summary>
        ///Авторизация пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Данный метод нужен для авторизации пользователя на сайте</returns>
        /// /// <response code="200">Пользователь успешно авторизован</response>
        /// /// <response code="403">Ошибка запроса. Данные не указаны.</response>
        /// /// <response code="500">При выполнении запроса возникла ошибка</response>
        //[Route("SignIn")]
        [HttpPost("SignIn")]
        //[ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        public ActionResult SignIn([FromForm] string login, [FromForm] string password)
        {
            if(login == null && password == null)
            {
                return StatusCode(403);
            }
            try
            {
                User User = new Contexts.UserContext().Users.Where(x => x.Login == login && x.Password == password).First();

                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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
        }
    }
}
