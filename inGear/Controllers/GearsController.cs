using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inGear.Data;
using inGear.Models;

namespace inGear.Controllers
{
    public class GearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gears
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gears.Include(g => g.Category).Include(g => g.Condition).Include(g => g.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Condition)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gears/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Label");
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "Label");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Gears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GearId,UserId,Description,Make,Model,ConditionId,SerialNumber,ImagePath,Value,RentalPrice,Quantity,CategoryId,Insurance,Rentable,Rented")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Label", gear.CategoryId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "Label", gear.ConditionId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", gear.UserId);
            return View(gear);
        }

        // GET: Gears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears.FindAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Label", gear.CategoryId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "Label", gear.ConditionId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", gear.UserId);
            return View(gear);
        }

        // POST: Gears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GearId,UserId,Description,Make,Model,ConditionId,SerialNumber,ImagePath,Value,RentalPrice,Quantity,CategoryId,Insurance,Rentable,Rented")] Gear gear)
        {
            if (id != gear.GearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.GearId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Label", gear.CategoryId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "Label", gear.ConditionId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", gear.UserId);
            return View(gear);
        }

        // GET: Gears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Condition)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gear = await _context.Gears.FindAsync(id);
            _context.Gears.Remove(gear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearExists(int id)
        {
            return _context.Gears.Any(e => e.GearId == id);
        }
    }
}
