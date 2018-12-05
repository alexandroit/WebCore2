using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.Models;
using WebCore.Models.ManageBlog;
using WebCore.Services.Spec;
using WebCore.ViewsModel;

namespace WebCore.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blog;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blog, IMapper mapper)
        {
            _mapper = mapper;
            _blog = blog;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _blog.ListarAsync());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var blog = await _blog.ObterAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tilulo,Resumo,Url,Autor,Captcha")] BlogViewModel blog)
        {
            if (ModelState.IsValid)
            {
                if (TryValidateModel(blog))
                {
                    var b = _mapper.Map<Blog>(blog);
                    await _blog.SalvarAsync(b);
                    return RedirectToAction(nameof(Index),new{ID = b.ID });
                }
            }
            return View(blog);
        }
        /*
        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blog.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tilulo,Resumo,Url,Autor")] Blog blog)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _blog.Update(blog);
                    await _blog.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blog.Blog
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _blog.Blog.FindAsync(id);
            _blog.Blog.Remove(blog);
            await _blog.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _blog.Blog.Any(e => e.ID == id);
        }*/
    }
}
