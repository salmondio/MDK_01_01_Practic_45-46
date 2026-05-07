using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;

namespace Practic_45.Controllers
{
    [Route("api/OrderController")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Метод добавления заказа
        /// </summary>
        /// <param name="order">Данные о задаче</param>
        /// <retrns>Статус выполнения запроса</retrns>
        /// <remarks>Данный метод добавляет заказ в базу данных</remarks>
        //[Route("Add")]
        [HttpPost("Add")]
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromBody] Models.Order order)
        {
            try
            {
                OrderContext orderContext = new OrderContext();
                orderContext.Orders.Add(order);
                orderContext.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        ///Получение списка заказов
        /// </summary>
        /// <remarks>
        /// Данный метод получает список весий заказов, находящийся в базе данных
        /// </remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        /// 
        //[Route("List")]
        [HttpGet("List")]
        //[ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(List<Models.Order>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Models.Order> orders = new OrderContext().Orders;
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
