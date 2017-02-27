using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrailerCheck.Data;
using TrailerCheck.Models;

namespace TrailerCheck.Controllers
{
    public class TrailersController : Controller
    {
        private readonly TrailerCheckContext _context;

        public TrailersController(TrailerCheckContext context)
        {
            _context = context;
        }

        // GET: Trailers
        public async Task<IActionResult> Index(string searchTrailerID)
        {
            var trailers = from t in _context.Trailers
                         select t;

            if (!string.IsNullOrWhiteSpace(searchTrailerID))
            {
                trailers = trailers.Where(m => m.TrailerID.ToString() == searchTrailerID);
            }

            return View(await trailers.ToListAsync());
        }

        // GET: Trailers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers
                .Include(t => t.Registrations)
                    .ThenInclude(r => r.Owner)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.TrailerID == id);

            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // GET: Trailers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailerID,Description,Model")] Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trailer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trailer);
        }

        // GET: Trailers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers.SingleOrDefaultAsync(m => m.TrailerID == id);
            if (trailer == null)
            {
                return NotFound();
            }
            return View(trailer);
        }

        // POST: Trailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailerID,Description,Model")] Trailer trailer)
        {
            if (id != trailer.TrailerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trailer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailerExists(trailer.TrailerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(trailer);
        }

        // GET: Trailers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers.SingleOrDefaultAsync(m => m.TrailerID == id);
            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // POST: Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trailer = await _context.Trailers.SingleOrDefaultAsync(m => m.TrailerID == id);
            _context.Trailers.Remove(trailer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrailerExists(int id)
        {
            return _context.Trailers.Any(e => e.TrailerID == id);
        }
    }
}