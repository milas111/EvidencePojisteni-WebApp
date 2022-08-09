using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Data;
using EvidencePojisteni.Models.AssignedInsurances;
using EvidencePojisteni.Classes;
using EvidencePojisteni.Extensions;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace EvidencePojisteni.Controllers
{
    [ExceptionsToMessageFilter]
    public class AssignedInsurancesToPolicyholdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private const int pageSize = 10;

        public AssignedInsurancesToPolicyholdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: AssignedInsurancesToPolicyholders
        public async Task<IActionResult> Index(int? page)
        {
            var AssignedInsurancesToPolicyholders = _context.AssignedInsurancesToPolicyholders.Include(a => a.AssignedInsurance).Include(a => a.Insured);
            var AssignedInsurancesToPolicyholdersList = _context.AssignedInsurancesToPolicyholders.Include(a => a.AssignedInsurance).Include(a => a.Insured).ToPagedList(page ?? 1, pageSize);
            ViewBag.AssignedInsurancesToPolicyholdersList = AssignedInsurancesToPolicyholdersList;
            if (User.IsInRole("Admin"))
            {
                return View(await AssignedInsurancesToPolicyholdersList.ToListAsync());
            }
            else
            {
                return View(await AssignedInsurancesToPolicyholders.ToListAsync());
            }
        }

        // GET: AssignedInsurancesToPolicyholders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurancesToPolicyholders = await _context.AssignedInsurancesToPolicyholders
                .Include(a => a.AssignedInsurance)
                .Include(a => a.Insured)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignedInsurancesToPolicyholders == null)
            {
                return NotFound();
            }

            return View(assignedInsurancesToPolicyholders);
        }

        // GET: AssignedInsurancesToPolicyholders/Create
        public IActionResult Create(int insuredId)
        {
            var name = _context.Insured.Where(n => n.InsuredId == insuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            ViewData["AssignedInsuranceId"] = new SelectList(from i in _context.AssignedInsurance.Where(x => x.InsuranceRole == 0 && _context.AssignedInsurancesToPolicyholders.Where(y => y.AssignedInsuranceId == x.AssignedInsuranceId).Count() == 0) select new { AssignedInsuranceId = i.AssignedInsuranceId, InsuranceInfo = i.Insured.FirstName + " " + i.Insured.SurName + "-" + i.Insurance.InsuranceName + "-" + i.Issue }, "AssignedInsuranceId", "InsuranceInfo");
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName");
            return View();
        }

        // POST: AssignedInsurancesToPolicyholders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int insuredId, [Bind("Id,AssignedInsuranceId,InsuredId")] AssignedInsurancesToPolicyholders assignedInsurancesToPolicyholders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignedInsurancesToPolicyholders);
                await _context.SaveChangesAsync();
                this.AddFlashMessage(new FlashMessage("Pojištění bylo přiřazeni danému pojistníkovi", FlashMessageType.Success));
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedInsuranceId"] = new SelectList(_context.AssignedInsurance, "AssignedInsuranceId", "Info", assignedInsurancesToPolicyholders.AssignedInsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", assignedInsurancesToPolicyholders.InsuredId);
            return View(assignedInsurancesToPolicyholders);
        }

        // GET: AssignedInsurancesToPolicyholders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurancesToPolicyholders = await _context.AssignedInsurancesToPolicyholders.FindAsync(id);
            var name = _context.Insured.Where(n => n.InsuredId == assignedInsurancesToPolicyholders.InsuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            if (assignedInsurancesToPolicyholders == null)
            {
                return NotFound();
            }
            ViewData["AssignedInsuranceId"] = new SelectList(from i in _context.AssignedInsurance.Where(x => x.InsuranceRole == 0 && _context.AssignedInsurancesToPolicyholders.Where(y => y.AssignedInsuranceId == x.AssignedInsuranceId).Count() == 0) select new { AssignedInsuranceId = i.AssignedInsuranceId, InsuranceInfo = i.Insured.FirstName + " " + i.Insured.SurName + "-" + i.Insurance.InsuranceName + "-" + i.Issue }, "AssignedInsuranceId", "InsuranceInfo", assignedInsurancesToPolicyholders.AssignedInsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", assignedInsurancesToPolicyholders.InsuredId);
            return View(assignedInsurancesToPolicyholders);
        }

        // POST: AssignedInsurancesToPolicyholders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignedInsuranceId,InsuredId")] AssignedInsurancesToPolicyholders assignedInsurancesToPolicyholders)
        {
            if (id != assignedInsurancesToPolicyholders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignedInsurancesToPolicyholders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedInsurancesToPolicyholdersExists(assignedInsurancesToPolicyholders.Id))
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
            ViewData["AssignedInsuranceId"] = new SelectList(_context.AssignedInsurance, "AssignedInsuranceId", "Issue", assignedInsurancesToPolicyholders.AssignedInsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "City", assignedInsurancesToPolicyholders.InsuredId);
            return View(assignedInsurancesToPolicyholders);
        }

        // GET: AssignedInsurancesToPolicyholders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurancesToPolicyholders = await _context.AssignedInsurancesToPolicyholders
                .Include(a => a.AssignedInsurance)
                .Include(a => a.Insured)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignedInsurancesToPolicyholders == null)
            {
                return NotFound();
            }

            return View(assignedInsurancesToPolicyholders);
        }

        // POST: AssignedInsurancesToPolicyholders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignedInsurancesToPolicyholders = await _context.AssignedInsurancesToPolicyholders.FindAsync(id);
            _context.AssignedInsurancesToPolicyholders.Remove(assignedInsurancesToPolicyholders);
            await _context.SaveChangesAsync();
            this.AddFlashMessage(new FlashMessage("Pojištění bylo odstraněno ze seznamu přiřazených pojištění", FlashMessageType.Success));
            return RedirectToAction(nameof(Index));
        }

        private bool AssignedInsurancesToPolicyholdersExists(int id)
        {
            return _context.AssignedInsurancesToPolicyholders.Any(e => e.Id == id);
        }
    }
}
