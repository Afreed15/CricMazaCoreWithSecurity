using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication28.Models;

namespace WebApplication28.Controllers
{
    public class MatchesController : Controller
    {
        private readonly CricMaza21Context _context;

        public MatchesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var cricMaza21Context = _context.Matches.Include(m => m.Team1Navigation).Include(m => m.Team2Navigation);
            return View(await cricMaza21Context.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.Team1Navigation)
                .Include(m => m.Team2Navigation)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }
        [Authorize]
        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["Team1"] = new SelectList(_context.Teams, "Tid", "Tname");
            ViewData["Team2"] = new SelectList(_context.Teams, "Tid", "Tname");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mid,Team1,Team2,MatchList,Mdate,Mtime,Venue")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team1"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team1);
            ViewData["Team2"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team2);
            return View(matches);
        }
        [Authorize]
        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }
            ViewData["Team1"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team1);
            ViewData["Team2"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team2);
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mid,Team1,Team2,MatchList,Mdate,Mtime,Venue")] Matches matches)
        {
            if (id != matches.Mid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchesExists(matches.Mid))
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
            ViewData["Team1"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team1);
            ViewData["Team2"] = new SelectList(_context.Teams, "Tid", "Tname", matches.Team2);
            return View(matches);
        }
        [Authorize]
        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.Team1Navigation)
                .Include(m => m.Team2Navigation)
                .FirstOrDefaultAsync(m => m.Mid == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Mid == id);
        }
    }
}
