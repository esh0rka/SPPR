using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.API.Data;
using WEB_153504_Gaikevich.Domain.Entities;

namespace WEB_153504_Gaikevich.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AutoPart.Include(a => a.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AutoPart == null)
            {
                return NotFound();
            }

            var autoPart = await _context.AutoPart
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoPart == null)
            {
                return NotFound();
            }

            return View(autoPart);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NormalizedName");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CategoryId,Price,Image,mimeType")] AutoPart autoPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NormalizedName", autoPart.CategoryId);
            return View(autoPart);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AutoPart == null)
            {
                return NotFound();
            }

            var autoPart = await _context.AutoPart.FindAsync(id);
            if (autoPart == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NormalizedName", autoPart.CategoryId);
            return View(autoPart);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CategoryId,Price,Image,mimeType")] AutoPart autoPart)
        {
            if (id != autoPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoPartExists(autoPart.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "NormalizedName", autoPart.CategoryId);
            return View(autoPart);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AutoPart == null)
            {
                return NotFound();
            }

            var autoPart = await _context.AutoPart
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoPart == null)
            {
                return NotFound();
            }

            return View(autoPart);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AutoPart == null)
            {
                return Problem("Entity set 'AppDbContext.AutoPart'  is null.");
            }
            var autoPart = await _context.AutoPart.FindAsync(id);
            if (autoPart != null)
            {
                _context.AutoPart.Remove(autoPart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoPartExists(int id)
        {
          return (_context.AutoPart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
