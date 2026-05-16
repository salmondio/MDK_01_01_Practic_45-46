using Practic_45.Models;
using System.Security.Cryptography;
using System.Text;

namespace Practic_45.Helpers
{
    public class HashHelper
    {
        // Создаем токен на основе ID пользователя
        public static string CreateToken(int userId)
        {
            // Превращаем ID в строку и хэшируем простым MD5 (как пример)
            // В реальности лучше использовать SHA256, но для учебной работы пойдет
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(userId.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Конвертируем байты в hex-строку (например: "9c3b7a3b42e7f1d7")
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }

        // Получаем ID из токена (обратная операция невозможна для хэша, поэтому
        // этот метод не нужен. Вместо этого мы будем сравнивать хэш от ID с токеном).

        // Проверяем, соответствует ли переданный токен данному пользователю
        public static bool ValidateToken(User user, string token)
        {
            if (user == null || string.IsNullOrEmpty(token))
                return false;

            return user.Hash == token;
        }
    }
}
