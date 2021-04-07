using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication28.Models;

namespace WebApplication28.Controllers
{
    public class PlayersController : Controller
    {
        private readonly CricMaza21Context _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public PlayersController(CricMaza21Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnviroment = hostEnvironment;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var cricMaza21Context = _context.Players.Include(p => p.T);
            return View(await cricMaza21Context.ToListAsync());
        }
        public IActionResult Display(int id)
        {
            CricMaza21Context db = new CricMaza21Context();
            List<Players> cricMaza21Context = db.Players.Where(x => x.T.Tid == id).ToList();
            return View(cricMaza21Context);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }
        [Authorize]
        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Tplayer,Img,Tid,PPicFile")] Players players)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _hostEnviroment.WebRootPath;

                string fileName = Path.GetFileName(players.PPicFile.FileName);
                string pPath = Path.Combine(rootPath + "/Images/", fileName);
                players.Img = fileName;
                var filStream = new FileStream(pPath, FileMode.Create);
                await players.PPicFile.CopyToAsync(filStream);
                _context.Add(players);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", players.Tid);
            return View(players);
        }
        [Authorize]
        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players.FindAsync(id);
            if (players == null)
            {
                return NotFound();
            }
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", players.Tid);
            return View(players);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,Tplayer,Img,Tid")] Players players)
        {
            if (id != players.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(players);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayersExists(players.Pid))
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
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", players.Tid);
            return View(players);
        }
        [Authorize]
        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var players = await _context.Players
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var players = await _context.Players.FindAsync(id);
            _context.Players.Remove(players);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.Pid == id);
        }
    }
}
