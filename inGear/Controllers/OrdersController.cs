﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inGear.Data;
using inGear.Models;
using Microsoft.AspNetCore.Identity;
using inGear.Models.ViewModels;

namespace inGear.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Borrower).Include(o => o.Gear).Include(o => o.Renter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Borrower)
                .Include(o => o.Gear)
                .Include(o => o.Renter)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create(int ReservedGearId)
        {
            ViewData["BorrowerId"] = new SelectList(_context.ApplicationUsers, "Id", "FirstName");
            //ViewBag.gear = _context.Gears.FirstOrDefaultAsync(m => m.GearId == ReservedGearId);



            GearOrderViewModel ViewModel = new GearOrderViewModel();
            ViewModel.Order = new Order();
            ViewModel.Gear = new Gear();

            var gear = await _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Condition)
                .SingleOrDefaultAsync(m => m.GearId == ReservedGearId);

            ViewModel.Gear = gear;
            ViewModel.Order.GearId = ReservedGearId;
            ViewModel.Order.PickupDate = DateTime.Now;
            ViewModel.Order.ReturnDate = DateTime.Now;
            return View(ViewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GearOrderViewModel ViewModel)

        {

            ModelState.Remove("Order.RenterId");
            var user = await GetCurrentUserAsync();
            ViewModel.Order.RenterId = user.Id;
            //order.GearId = ReservedGearId;
            ViewModel.Order.DateCreated = DateTime.Now;


            if (ModelState.IsValid)
            {
                _context.Add(ViewModel.Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BorrowerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", ViewModel.Order.BorrowerId);
            //ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "Make", order.GearId);
            return View(ViewModel);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["BorrowerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.BorrowerId);
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "Make", order.GearId);
            ViewData["RenterId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.RenterId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,BorrowerId,RenterId,GearId,DateCreated,PickupDate,ReturnDate,Completed")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["BorrowerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.BorrowerId);
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "Make", order.GearId);
            ViewData["RenterId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.RenterId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Borrower)
                .Include(o => o.Gear)
                .Include(o => o.Renter)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
