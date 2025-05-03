using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GISWebApp.Filtters
{
    public class MyCustomAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           //logic Validation
           //context.re
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           //empty
        }
    }
}
