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
	public class SupportController : Controller
	{
		private readonly ProjectSupportSystemContext _context;

		public SupportController(ProjectSupportSystemContext context)
		{
			_context = context;
		}

		// GET: Support
		public async Task<IActionResult> Index()
		{
			return View(await _context.Supports.ToListAsync());
		}

		// GET: Support/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var support = await _context.Supports
				.FirstOrDefaultAsync(m => m.ID == id);
			if (support == null)
			{
				return NotFound();
			}

			return View(support);
		}

		// GET: Support/Create
		public IActionResult Create()
		{
			var SupportElements = _context.SupportElements.ToListAsync();

			if (SupportElements != null)
			{
				ViewBag.SupportElements = SupportElements;
			}
			else
			{
				ViewBag.SupportElements = "Boş ya da null geldi!";
			}

			return View();
		}

		// POST: Support/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SupportType,SupportName,WhoApply,Goal,ApplicationProcessAndCondition,SupportDuration,SupportPercentage,SupportAmount,Code,SupportSupElementID,ID,Description")] Support support)
		{
			if (ModelState.IsValid)
			{
				_context.Add(support);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(support);
		}

		// GET: Support/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var support = await _context.Supports.FindAsync(id);
			if (support == null)
			{
				return NotFound();
			}
			return View(support);
		}

		// POST: Support/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("SupportType,SupportName,WhoApply,Goal,ApplicationProcessAndCondition,SupportDuration,SupportPercentage,SupportAmount,Code,SupportSupElementID,ID,Description")] Support support)
		{
			if (id != support.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(support);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!SupportExists(support.ID))
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
			return View(support);
		}

		// GET: Support/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var support = await _context.Supports
				.FirstOrDefaultAsync(m => m.ID == id);
			if (support == null)
			{
				return NotFound();
			}

			return View(support);
		}

		// POST: Support/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var support = await _context.Supports.FindAsync(id);
			_context.Supports.Remove(support);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool SupportExists(int id)
		{
			return _context.Supports.Any(e => e.ID == id);
		}
	}
}
