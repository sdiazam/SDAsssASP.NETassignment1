using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SDA_ASP_Project.Data;
using SDA_ASP_Project.Models;

namespace SDA_ASP_Project.Controllers
{
    public class MangasController : Controller
    {
        private readonly SDA_ASP_ProjectContext _context;

        public MangasController(SDA_ASP_ProjectContext context)
        {
            _context = context;
        }

        // GET: Mangas
        public async Task<IActionResult> Index()
        {
            var sDA_ASP_ProjectContext = _context.Manga.Include(m => m.Genre);
            return View(await sDA_ASP_ProjectContext.ToListAsync());
        }

        // GET: Mangas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // GET: Mangas/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Id");
            return View();
        }

        // POST: Mangas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Rating,Chapters,CoverPhoto,ReleaseDate,Favorite,GenreId,AuthorId,ArtistId")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Id", manga.GenreId);
            return View(manga);
        }

        // GET: Mangas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Id", manga.GenreId);
            return View(manga);
        }

        // POST: Mangas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Rating,Chapters,CoverPhoto,ReleaseDate,Favorite,GenreId,AuthorId,ArtistId")] Manga manga)
        {
            if (id != manga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangaExists(manga.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Id", manga.GenreId);
            return View(manga);
        }

        // GET: Mangas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // POST: Mangas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manga = await _context.Manga.FindAsync(id);
            if (manga != null)
            {
                _context.Manga.Remove(manga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MangaExists(int id)
        {
            return _context.Manga.Any(e => e.Id == id);
        }
    }
}
