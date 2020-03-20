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



		// GET: SupportElement/Create
		public IActionResult AddOrUpdate(int id = 0)
		{
			if (id == 0)
				return View(new SupportElement());
			else
				return View(_context.SupportElements.Find(id));
		}

		// POST: SupportElement/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddOrUpdate([Bind("SupportElementName,SupportElementPercentage,SupportElementAmount,SupportSupElementID,ID,Description")] SupportElement supportElement)
		{
			if (ModelState.IsValid)
			{
				if (supportElement.ID == 0)
					_context.Add(supportElement);
				else
					_context.Update(supportElement);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(supportElement);
		}

		// GET: SupportElement/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			var supportElement = await _context.SupportElements.FindAsync(id);
			_context.SupportElements.Remove(supportElement);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
