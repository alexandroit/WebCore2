using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Models.ManageBlog;

namespace WebCore.Services.Spec
{
    public interface IBlogService
    {
        Task SalvarAsync(Blog blog);
        Task<Blog> ObterAsync(int id);
        Task<IEnumerable<Blog>> ListarAsync();
        Task DeletarAsync(int id);
    }
}
