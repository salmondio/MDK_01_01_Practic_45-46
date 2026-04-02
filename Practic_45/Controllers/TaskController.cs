using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Practic_45.Contexts;

namespace Practic_45.Controllers
{
    [Route("api/TaskController")]
    [ApiController]
    public class TaskController : ControllerBase
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
        //[Route("List")]
        [HttpGet("List")]
        [ApiExplorerSettings(GroupName = "get")]
        [ProducesResponseType(typeof(List<Models.Task>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Models.Task> tasks = new TaskContext().Tasks;
                return Ok(tasks);
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
        //[Route("Item")]
        [HttpGet("Item/{id}")]
        [ApiExplorerSettings(GroupName = "get")]
        [ProducesResponseType(typeof(Models.Task), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Models.Task task = new TaskContext().Tasks.Where(x => x.Id == Id).First();
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод добавления задачи
        /// </summary>
        /// <param name="task">Данные о задаче</param>
        /// <retrns>Статус выполнения запроса</retrns>
        /// <remarks>Данный метод добавляет задачу в базу данных</remarks>
        //[Route("Add")]
        [HttpPut("Add")]
        [ApiExplorerSettings(GroupName = "post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm] Models.Task task)
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                taskContext.Tasks.Add(task);
                taskContext.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
