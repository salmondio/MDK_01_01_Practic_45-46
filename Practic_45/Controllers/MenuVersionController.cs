using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;

namespace Practic_45.Controllers
{
    [Route("api/MenuVersionController")]
    [ApiController]
    public class MenuVersionController : ControllerBase
    {
        ///<summary>
        ///Получение списка версий меню
        /// </summary>
        /// <remarks>
        /// Данный метод получает список весий меню, находящийся в базе данных
        /// </remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        /// 
        //[Route("List")]
        [HttpGet("List")]
        //[ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(List<Models.MenuVersion>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Models.MenuVersion> menuVersions = new MenuVersionContext().MenuVersions;
                return Ok(menuVersions);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
