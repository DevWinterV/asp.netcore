namespace WEB_API.Models
{
    public class ServerBaseReponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty; 
    }
}
