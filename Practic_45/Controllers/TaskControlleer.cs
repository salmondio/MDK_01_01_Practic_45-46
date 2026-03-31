using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;

namespace Practic_45.Controllers
{
    [Route("api/TaskControlleer")]
    public class TaskControlleer : Controller
    {
        ///<summary>
        ///Получение списка задач
        /// </summary>
        /// <remarks>
        /// Данный метод получает список задач, находящийся в базе данных
        /// </remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        /// 
        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Task>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Task> tasks = new TaskContext().Tasks;
                return Json(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        ///Получение задачи
        /// </summary>
        /// <remarks>
        /// Метод получает задачу, находящуюся в базе данных
        /// </remarks>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        ///
        [Route("Item")]
        [HttpGet]
        [ProducesResponseType(typeof(Task), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Task task = new TaskContext().Tasks.Where(x => x.Id == Id).First();
                return Json(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
