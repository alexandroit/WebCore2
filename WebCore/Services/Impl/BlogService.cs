using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Data;
using WebCore.Models;
using WebCore.Models.ManageBlog;
using WebCore.Services.Spec;

namespace WebCore.Services.Impl
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;
        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD

        //Salvar (Incluir ou Atualizar)
        public async Task SalvarAsync(Blog blog)
        {
            if (blog.ID > 0)
            {
                _context.Blogs.Attach(blog);
                _context.Entry(blog).State = EntityState.Modified;
            }
            else
                _context.Blogs.Add(blog);

           await _context.SaveChangesAsync();
        }
        //Obter
        public async Task<Blog> ObterAsync(int id)
        {
            return await _context.Blogs.SingleOrDefaultAsync(b => b.ID == id);
        }
        //Listar
        public async Task<IEnumerable<Blog>> ListarAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
        //Deletar
        public async Task DeletarAsync(int id)
        {
            var b = new Blog() { ID = id }; //_context.Blog.Where(b => b.ID == id).FirstOrDefault();
            _context.Blogs.Attach(b);
            _context.Blogs.Remove(b);
            await _context.SaveChangesAsync();
        }       
    }
}
