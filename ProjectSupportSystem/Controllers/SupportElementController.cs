using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSupportSystem.Models;

namespace ProjectSupportSystem.Controllers
{
    public class SupportElementController : Controller
    {
        private readonly ProjectSupportSystemContext _context;

        public SupportElementController(ProjectSupportSystemContext context)
        {
            _context = context;
        }

        // GET: SupportElement
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportElements.ToListAsync());
        }

        // GET: SupportElement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportElement = await _context.SupportElements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (supportElement == null)
            {
                return NotFound();
            }

            return View(supportElement);
        }

        // GET: SupportElement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportElement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupportElementName,SupportElementPercentage,SupportElementAmount,SupportSupElementID,ID,Description")] SupportElement supportElement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportElement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportElement);
        }

        // GET: SupportElement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportElement = await _context.SupportElements.FindAsync(id);
            if (supportElement == null)
            {
                return NotFound();
            }
            return View(supportElement);
        }

        // POST: SupportElement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupportElementName,SupportElementPercentage,SupportElementAmount,SupportSupElementID,ID,Description")] SupportElement supportElement)
        {
            if (id != supportElement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportElement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportElementExists(supportElement.ID))
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
            return View(supportElement);
        }

        // GET: SupportElement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportElement = await _context.SupportElements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (supportElement == null)
            {
                return NotFound();
            }

            return View(supportElement);
        }

        // POST: SupportElement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportElement = await _context.SupportElements.FindAsync(id);
            _context.SupportElements.Remove(supportElement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportElementExists(int id)
        {
            return _context.SupportElements.Any(e => e.ID == id);
        }
    }
}
