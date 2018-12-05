using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers.Filters
{
    public class MeuResourceFilterAttribute : Attribute, IResourceFilter
    {

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var controlerActionValues = context.RouteData.Values;
            var controller = controlerActionValues["controller"].ToString();
            var action = controlerActionValues["action"].ToString() ;
            Console.Write($"controller={controller}, action={action}");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }
    }
}
