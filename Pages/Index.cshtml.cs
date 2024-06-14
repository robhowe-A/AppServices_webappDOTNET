using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppDOTNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public string exceptionMessage = "";
        public static int currentCount = 0;

        public void IncrementCount()
        {
            currentCount++;
            if (currentCount == 3)
            {
                throw new ApplicationException("Reached the count of 3 for this Application Exception Test.");
            }
        }
        public void ThrowException()
        {
            Console.WriteLine("The next statement executes a throw application exception.");
            WebException();
            //throw new ApplicationException("This is a test exception inside a component.");
        }
        public void OnPostButtonClick()
        {
            // Your code here
            ThrowException();
        }

        public void WebException()
        {
            _logger.LogCritical("Test critical log (LogCritical) within exception function WebException.");
            _logger.LogDebug("Test debug log (LogDebug) within exception function WebException.");
            _logger.LogError("Test error log (LogError) within exception function WebException.");
            _logger.LogInformation("Test information log (LogInformation) within exception function WebException.");
            _logger.LogTrace("Test trace log (LogTrace) within exception function WebException.");
            _logger.LogWarning("Test warning log (LogWarning) within exception function WebException.");
            throw new System.Net.WebException("This message is to show a send failure.", new ArgumentException("pretend inner error on send"), System.Net.WebExceptionStatus.SendFailure, null);
        }
    }
}
