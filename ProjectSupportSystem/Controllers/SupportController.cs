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


		// GET: Support/Create
		public IActionResult AddOrUpdate(int id = 0)
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

			var support = new Support();
			if (id == 0)
			{
				return View(support);
			}
			else
			{
				support = _context.Supports.Find(id);
				return View(support);
			}
		}

		// POST: Support/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddOrUpdate([Bind("SupportType,SupportName,WhoApply,Goal,ApplicationProcessAndCondition,SupportDuration,SupportPercentage,SupportAmount,Code,SupportSupElementID,ID,Description")] Support support)
		{
			if (ModelState.IsValid)
			{
				if (support.ID == 0)
					_context.Add(support);
				else
					_context.Update(support);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(support);
		}

		// GET: Support/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			var support = await _context.Supports.FindAsync(id);
			_context.Supports.Remove(support);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


	}
}
