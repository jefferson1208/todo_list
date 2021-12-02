namespace todo_list.api.Models
{
    public class Notification
    {
        public Notification(string message, int codeError)
        {
            Message = message;
            CodeError = codeError;
        }

        public string Message { get; }
        public int CodeError { get; set; }
    }
}
