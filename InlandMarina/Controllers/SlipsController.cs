using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InlandMarina.Data;
using InlandMarina.Models;

// Authors: Ola & Tracy
// Date: 23-April-2023

namespace InlandMarina.Controllers
{
    public class SlipsController : Controller
    {
        private readonly InlandMarinaContext _context; // database context for inlandMarina

        // context gets  injected to the constructor
        public SlipsController(InlandMarinaContext context)
        {
            _context = context;
        }

        // GET: Slips
        // list of slips
        public IActionResult Index()
        {
            List<Slip> slips = null;
            try
            {
                List<Dock> docks = DockManager.GetDocks(_context); // gets docks to pupolate a dropdown in the view to filter by docks
                var list = new SelectList(docks, "ID", "Name").ToList();
                list.Insert(0, new SelectListItem("All", "All")); // add All as first option
                ViewBag.Docks = list;

                slips = SlipManager.GetSlips(_context);
            }
            catch
            {
                TempData["Message"] = "Database connection error try again later";
                TempData["IsError"] = true;
            }
            return View(slips);
        }

        [HttpPost]
        public ActionResult Index(string id = "All")
        {
            List<Slip> slips = null;
            try
            {
                // retain drop down docks and selected item
                List<Dock> docks = DockManager.GetDocks(_context);
                var list = new SelectList(docks, "ID", "Name").ToList();
                list.Insert(0, new SelectListItem("All", "All")); // add All as first option
                foreach (var item in list)// find selected item
                {
                    if (item.Value == id)
                    {
                        item.Selected = true;
                        break;
                    }
                }
                ViewBag.Docks = list;

                if (id == "All")
                {
                    slips = SlipManager.GetSlips(_context); // all slips
                }
                else // a dock is selected
                {
                    slips = SlipManager.GetSlipsByDock(_context, Convert.ToInt32(id)); // filtered docks
                }
            }
            catch
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return View(slips);
        }

        // GET: Slips/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Slips == null)
        //    {
        //        return NotFound();
        //    }

        //    var slip = await _context.Slips
        //        .Include(s => s.Dock)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (slip == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(slip);
        //}

        // GET: Slips/Create
        //public IActionResult Create()
        //{
        //    ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name");
        //    return View();
        //}

        //// POST: Slips/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Width,Length,DockID")] Slip slip)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(slip);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
        //    return View(slip);
        //}

        //// GET: Slips/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Slips == null)
        //    {
        //        return NotFound();
        //    }

        //    var slip = await _context.Slips.FindAsync(id);
        //    if (slip == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
        //    return View(slip);
        //}

        //// POST: Slips/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Width,Length,DockID")] Slip slip)
        //{
        //    if (id != slip.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(slip);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SlipExists(slip.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
        //    return View(slip);
        //}

        //// GET: Slips/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Slips == null)
        //    {
        //        return NotFound();
        //    }

        //    var slip = await _context.Slips
        //        .Include(s => s.Dock)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (slip == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(slip);
        //}

        //// POST: Slips/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Slips == null)
        //    {
        //        return Problem("Entity set 'InlandMarinaContext.Slips'  is null.");
        //    }
        //    var slip = await _context.Slips.FindAsync(id);
        //    if (slip != null)
        //    {
        //        _context.Slips.Remove(slip);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SlipExists(int id)
        //{
        //  return (_context.Slips?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
