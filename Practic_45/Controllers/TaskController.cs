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
        //[ApiExplorerSettings(GroupName = "v1")]
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
        //[ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(Models.Task), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int id)
        {
            try
            {
                Models.Task task = new TaskContext().Tasks.Where(x => x.Id == id).First();
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
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromBody] Models.Task task)
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

        /// <summary>
        /// Метод изменения задачи
        /// </summary>
        /// <param name="task">Данные о задаче</param>
        /// <retrns>Статус выполнения запроса</retrns>
        /// <remarks>Данный метод изменяет задачу в базе данных</remarks>
        //[Route("Add")]
        [HttpPut("Change")]
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Change([FromBody] Models.Task task)
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                Models.Task changeableTask = taskContext.Tasks.Where(x => x.Id == task.Id).First();
                changeableTask.Name = task.Name;
                changeableTask.Priority = task.Priority;
                changeableTask.DateExecute = task.DateExecute;
                changeableTask.Comment = task.Comment;
                changeableTask.Done = task.Done;
                taskContext.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления задачи
        /// </summary>
        /// <param name="task">Данные о задаче</param>
        /// <retrns>Статус выполнения запроса</retrns>
        /// <remarks>Данный метод удаляет задачу из базы данных</remarks>
        //[Route("Add")]
        [HttpDelete("Delete")]
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                Models.Task deleteableTask = taskContext.Tasks.Where(x => x.Id == id).First();
                taskContext.Tasks.Remove(deleteableTask);
                taskContext.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Метод удаления всех задач
        /// </summary>
        /// <retrns>Статус выполнения запроса</retrns>
        /// <remarks>Данный метод удаляет все задачи из базы данных</remarks>
        //[Route("Add")]
        [HttpDelete("DeleteAll")]
        //[ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult DeleteAll()
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                List<Models.Task> tasks = taskContext.Tasks.ToList();
                taskContext.Tasks.RemoveRange(tasks);
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
