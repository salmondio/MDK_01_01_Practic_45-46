using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Practic_45.Models;

namespace Practic_45.Controllers
{
    [Route("api/UserController")]
    public class UserController : Controller
    {
        ///<summary>
        ///Авторизация пользователя
        /// </summary>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns>Данный метод нужен для авторизации пользователя на сайте</returns>
        /// /// <response code="200">Пользователь успешно авторизован</response>
        /// /// <response code="403">Ошибка запроса. Данные не указаны.</response>
        /// /// <response code="500">При выполнении запроса возникла ошибка</response>
        [Route("SignIn")]
        [HttpPost]
        [ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]

        public ActionResult SignIn([FromForm] string Login, [FromForm] string Password)
        {
            if(Login == null && Password == null)
            {
                return StatusCode(403);
            }
            try
            {
                User User = new Contexts.UserContext().Users.Where(x => x.Login == Login && x.Password == Password).First();

                return Json(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
