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
    public class PlayerProfilesController : Controller
    {
        private readonly CricMaza21Context _context;

        public PlayerProfilesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: PlayerProfiles
        public async Task<IActionResult> Index()
        {
            var cricMaza21Context = _context.PlayerProfile.Include(p => p.P).Include(p => p.T);
            return View(await cricMaza21Context.ToListAsync());
        }

        // GET: PlayerProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile
                .Include(p => p.P)
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Profileid == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }
        [Authorize]
        // GET: PlayerProfiles/Create
        public IActionResult Create()
        {
            ViewData["Pid"] = new SelectList(_context.Players, "Pid", "Img");
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname");
            return View();
        }

        // POST: PlayerProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Profileid,Country,HighestScore,Role,BestBowling,Tid,Pid")] PlayerProfile playerProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pid"] = new SelectList(_context.Players, "Pid", "Img", playerProfile.Pid);
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", playerProfile.Tid);
            return View(playerProfile);
        }
        [Authorize]
        // GET: PlayerProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile.FindAsync(id);
            if (playerProfile == null)
            {
                return NotFound();
            }
            ViewData["Pid"] = new SelectList(_context.Players, "Pid", "Img", playerProfile.Pid);
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", playerProfile.Tid);
            return View(playerProfile);
        }

        // POST: PlayerProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Profileid,Country,HighestScore,Role,BestBowling,Tid,Pid")] PlayerProfile playerProfile)
        {
            if (id != playerProfile.Profileid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerProfileExists(playerProfile.Profileid))
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
            ViewData["Pid"] = new SelectList(_context.Players, "Pid", "Img", playerProfile.Pid);
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", playerProfile.Tid);
            return View(playerProfile);
        }
        [Authorize]
        // GET: PlayerProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile
                .Include(p => p.P)
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Profileid == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }

        // POST: PlayerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerProfile = await _context.PlayerProfile.FindAsync(id);
            _context.PlayerProfile.Remove(playerProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerProfileExists(int id)
        {
            return _context.PlayerProfile.Any(e => e.Profileid == id);
        }
    }
}
