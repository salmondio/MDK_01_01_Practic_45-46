using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;

namespace Practic_45.Controllers
{
    [Route("api/DishController")]
    [ApiController]
    public class DishController : ControllerBase
    {
        ///<summary>
        ///Получение списка блюд
        /// </summary>
        /// <remarks>
        /// Данный метод получает список блюд, находящийся в базе данных
        /// </remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        /// 
        //[Route("List")]
        [HttpGet("List")]
        //[ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(List<Models.Dish>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                List<Models.Dish> dishes = new DishContext().Dishes.ToList();
                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
