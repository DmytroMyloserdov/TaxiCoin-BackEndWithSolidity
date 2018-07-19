namespace App.RequestObjectPatterns
{
    public class DefaultControllerPattern : IControllerPattern
    {
        public string Sender { get; set; }
        public string Password { get; set; }
        public string PassPhrase { get; set; }
    }
}
