using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practic_45.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practic_45.Contexts;
using Practic_45.Helpers;

namespace Practic_45.Helpers
{
    public class AuthorizeTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 1. Пытаемся получить токен из заголовка "Authorization"
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                context.Result = new UnauthorizedObjectResult(new { error = "Токен отсутствует" });
                return;
            }

            string token = authHeader.ToString();

            // Убираем "Bearer " если он есть (для совместимости со стандартами)
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            // 2. Из тела запроса нужно получить UserId (или объект с UserId)
            // Самый простой способ: клиент передает userId в теле запроса
            // Или можно из токена расшифровать, но мы выбрали хэш, поэтому просим userId


            // 3. Находим пользователя в базе
            using (var userContext = new UserContext())
            {
                var user = userContext.Users.Find(token);
                if (user == null)
                {
                    context.Result = new UnauthorizedObjectResult(new { error = "Пользователь не найден" });
                    return;
                }

                // 4. Проверяем токен
                if (!HashHelper.ValidateToken(user, token))
                {
                    context.Result = new UnauthorizedObjectResult(new { error = "Неверный токен" });
                    return;
                }
            }

            // Если всё ок, продолжаем выполнение метода
            base.OnActionExecuting(context);
        }
    }
}
