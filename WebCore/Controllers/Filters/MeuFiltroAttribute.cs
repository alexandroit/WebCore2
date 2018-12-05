using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers
{
    public class MeuActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.Write(context.Result);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.Write(context.Result);
        }
    }
}
