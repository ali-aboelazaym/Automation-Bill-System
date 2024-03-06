namespace Automation_System.Entities
{
    public class AccessTokenResponse
    {
        public bool isValid { get; set; }
        public string errorKey { get; set; }
        public ResponseAcceTok response { get; set; }
    }
}
