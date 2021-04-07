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
    public class PointsTablesController : Controller
    {
        private readonly CricMaza21Context _context;

        public PointsTablesController(CricMaza21Context context)
        {
            _context = context;
        }

        // GET: PointsTables
        public async Task<IActionResult> Index()
        {
            var cricMaza21Context = _context.PointsTable.Include(p => p.T);
            return View(await cricMaza21Context.ToListAsync());
        }

        // GET: PointsTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTable
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Ptid == id);
            if (pointsTable == null)
            {
                return NotFound();
            }

            return View(pointsTable);
        }
        [Authorize]
        // GET: PointsTables/Create
        public IActionResult Create()
        {
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname");
            return View();
        }

        // POST: PointsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ptid,Tid,Played,NetRate,Win,Loss,Points")] PointsTable pointsTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointsTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", pointsTable.Tid);
            return View(pointsTable);
        }
        [Authorize]
        // GET: PointsTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTable.FindAsync(id);
            if (pointsTable == null)
            {
                return NotFound();
            }
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", pointsTable.Tid);
            return View(pointsTable);
        }

        // POST: PointsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ptid,Tid,Played,NetRate,Win,Loss,Points")] PointsTable pointsTable)
        {
            if (id != pointsTable.Ptid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointsTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointsTableExists(pointsTable.Ptid))
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
            ViewData["Tid"] = new SelectList(_context.Teams, "Tid", "Tname", pointsTable.Tid);
            return View(pointsTable);
        }
        [Authorize]
        // GET: PointsTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTable
                .Include(p => p.T)
                .FirstOrDefaultAsync(m => m.Ptid == id);
            if (pointsTable == null)
            {
                return NotFound();
            }

            return View(pointsTable);
        }

        // POST: PointsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointsTable = await _context.PointsTable.FindAsync(id);
            _context.PointsTable.Remove(pointsTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointsTableExists(int id)
        {
            return _context.PointsTable.Any(e => e.Ptid == id);
        }
    }
}
