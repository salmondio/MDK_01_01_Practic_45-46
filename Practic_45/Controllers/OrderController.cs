using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;
using Practic_45.Helpers;
using Practic_45.Models;

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
        [AuthorizeToken]
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromBody] RequestOrder data)
        {
            //try
            //{
            OrderContext orderContext = new OrderContext();
            foreach (var dish in data.dishes)
            {
                orderContext.Orders.Add(new Order
                {
                    //Id_user = id_user,
                    Address = data.address,
                    Date = data.date,
                    Id_dish = dish.dishId,
                    Count = dish.count
                });
            }
            orderContext.SaveChanges();

            return Ok(new {message = "Заказ добавлен"});
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new {error = ex.Message});
            //}
        }

        public class RequestOrder
        {
            public string address { get; set; }
            public DateOnly date { get; set; }

            public List<RequestDish> dishes { get; set; }

            public class RequestDish
            {
                public int dishId { get; set; }
                public int count { get; set; }
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

        [HttpPost("Add2")]
        public ActionResult Add2([FromBody] RequestOrder data)
        {
            return Ok(new { message = "Заказ добавлен" });
            
        }

        

    }
}
