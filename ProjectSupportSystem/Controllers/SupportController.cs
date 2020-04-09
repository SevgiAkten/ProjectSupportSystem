using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

		public async Task<IActionResult> Support(string supportType)
		{

			var supportList = await _context.Supports.ToListAsync();

			if (supportType == "KOSGEB")
				supportList = await _context.Supports.Where(x => x.SupportType == "KOSGEB").ToListAsync();
			else if (supportType == "TÜBİTAK")
				supportList = await _context.Supports.Where(x => x.SupportType == "TÜBİTAK" || x.SupportType == "TÜBİTAK TEYDEB").ToListAsync();
			else if (supportType == "TİCARET BAKANLIĞI")
				supportList = await _context.Supports.Where(x => x.SupportType == "TİCARET BAKANLIĞI").ToListAsync();

			return View(supportList);
		}

		[HttpPost]
		public async Task<IActionResult> Search(IFormCollection formCode)
		{
			bool kosgeb = Convert.ToBoolean(formCode["kosgeb"].ToString());
			bool tubitak = Convert.ToBoolean(formCode["tubitak"].ToString());
			bool ticbak = Convert.ToBoolean(formCode["ticbak"].ToString());
			decimal minAmount = Convert.ToDecimal(formCode["minAmount"].ToString());
			decimal maxAmount = Convert.ToDecimal(formCode["maxAmount"].ToString());
			decimal minDuration = Convert.ToDecimal(formCode["minDuration"].ToString());
			decimal maxDuration = Convert.ToDecimal(formCode["maxDuration"].ToString());
			decimal minPercentage = Convert.ToDecimal(formCode["minPercentage"].ToString());
			decimal maxPercentage = Convert.ToDecimal(formCode["minPercentage"].ToString());

			var supportList = await _context.Supports.ToListAsync();

			//TODO: ARAMA SEÇENEKLERİNE GÖRE KOŞULLAR YAILACAK

			//if (kosgeb == "true")
			//{
			//	if(minAmount!=null && maxAmount != null)
			//	{
			//		supportList= await _context.Supports.Where(x=>x.SupportType=="KOSGEB" && mi x.SupportDuration).ToListAsync();
			//	}
			//}

			return View(supportList);
		}



		// GET: Support/Create
		public IActionResult AddOrUpdate(int id = 0)
		{

			var SupportElements = new List<SelectListItem>();
			foreach (var supportElement in _context.SupportElements.ToList())
			{
				SupportElements.Add(new SelectListItem
				{
					Text = supportElement.SupportElementName,
					Value = supportElement.ID.ToString()
				});
			}

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
		public async Task<IActionResult> AddOrUpdate([Bind("SupportType,SupportName,WhoApply,Goal,ApplicationProcessAndCondition,SupportDuration,SupportPercentage,SupportAmount,Code,SupportSupElementID,ID,Description")] Support support, string[] SupportElements)
		{
			if (ModelState.IsValid)
			{
				if (support.ID == 0)
				{
					_context.Add(support);
					await _context.SaveChangesAsync();
					foreach (var supportElementId in SupportElements)
					{
						var SupportSupElement = new SupportSupElement
						{
							SupportID = support.ID,
							SupportElementID = Convert.ToInt32(supportElementId)
						};
						_context.Add(SupportSupElement);
					}
				}
				else
				{
					foreach (var supportElementId in SupportElements)
					{
						var id = Convert.ToInt32(supportElementId);
						var supportSupElement = _context.SupportSupElements.FirstOrDefault(x => x.SupportElementID == id);
						if (supportSupElement != null)
						{
							supportSupElement.SupportID = support.ID;
							supportSupElement.SupportElementID = id;
							_context.Update(supportSupElement);

						}
						else
						{
							var SupportSupElement = new SupportSupElement
							{
								SupportID = support.ID,
								SupportElementID = id
							};
							_context.Add(SupportSupElement);

						}
					}

					_context.Update(support);

				}
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
