namespace ExampleWebApi.Models
{
    public class CommentCandidate
    {
        public const string Success = "Success";
        public const string InternalServiceError = "InternalServiceError";
        public const string BadRequest = "BadRequest";
        
        public string Result { get; set; }
    }
}