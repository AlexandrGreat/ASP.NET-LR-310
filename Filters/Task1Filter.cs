using Microsoft.AspNetCore.Mvc.Filters;

namespace LR10.Filters
{
    public class Task1Filter:Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            File.AppendAllText("Task1.txt", "Executing... " + context.ActionDescriptor.DisplayName + "\n");
        }

        public void OnActionExecuted( ActionExecutedContext context) 
        {
            File.AppendAllText("Task1.txt", "EXECUTED: " + context.ActionDescriptor.DisplayName + " " + DateTime.Now + "\n");
        }
    }
}