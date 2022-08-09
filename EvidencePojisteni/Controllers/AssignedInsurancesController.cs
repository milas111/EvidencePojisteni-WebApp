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
    public class AssignedInsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private const int pageSize = 10;

        public AssignedInsurancesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: AssignedInsurances
        public async Task<IActionResult> Index(int? page)
        {
            var insuredId = _context.Insured.Where(x => x.UserId == userManager.FindByNameAsync(User.Identity.Name).Result.Id).Select(x => x.InsuredId).FirstOrDefault();
            ViewBag.InsuredId = insuredId;
            var assignedInsurancesList = _context.AssignedInsurance.Include(a => a.Insurance).Include(a => a.Insured);
            var assignedInsurancesListPaged = _context.AssignedInsurance.Include(a => a.Insurance).Include(a => a.Insured).ToPagedList(page ?? 1, pageSize);
            ViewBag.AssignedInsurancesList = assignedInsurancesListPaged;
            if (User.IsInRole("Admin"))
            {
                return View(await assignedInsurancesListPaged.ToListAsync());
            }
            else
            {
                return View(await assignedInsurancesList.ToListAsync());
            }
        }

        // GET: AssignedInsurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurance = await _context.AssignedInsurance
                .Include(a => a.Insurance)
                .Include(a => a.Insured)
                .FirstOrDefaultAsync(m => m.AssignedInsuranceId == id);
            if (assignedInsurance == null)
            {
                return NotFound();
            }

            return View(assignedInsurance);
        }

        // GET: AssignedInsurances/Create
        public IActionResult Create(int insuredId)
        {
            var name = _context.Insured.Where(n => n.InsuredId == insuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName");
            return View();
        }

        // POST: AssignedInsurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int insuredId, [Bind("AssignedInsuranceId,InsuranceId,InsuredId,Value,Issue,ValidFrom,ValidTo,InsuranceRole")] AssignedInsurance assignedInsurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignedInsurance);
                await _context.SaveChangesAsync();
                this.AddFlashMessage(new FlashMessage("Přidání pojištění proběhlo úspěšně", FlashMessageType.Success));
                return RedirectToAction("Index");
            }
            var name = _context.Insured.Where(n => n.InsuredId == insuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", assignedInsurance.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", assignedInsurance.InsuredId);
            return View(assignedInsurance);
        }

        // GET: AssignedInsurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurance = await _context.AssignedInsurance.FindAsync(id);
            var name = _context.Insured.Where(n => n.InsuredId == assignedInsurance.InsuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            if (assignedInsurance == null)
            {
                return NotFound();
            }
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", assignedInsurance.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "City", assignedInsurance.InsuredId);
            return View(assignedInsurance);
        }

        // POST: AssignedInsurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignedInsuranceId,InsuranceId,InsuredId,Value,Issue,ValidFrom,ValidTo,InsuranceRole")] AssignedInsurance assignedInsurance)
        {
            if (id != assignedInsurance.AssignedInsuranceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignedInsurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignedInsuranceExists(assignedInsurance.AssignedInsuranceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                this.AddFlashMessage(new FlashMessage("Pojištění bylo pozměněno", FlashMessageType.Success));
                return RedirectToAction("Details", "Insureds", new { id = assignedInsurance.InsuredId });
            }
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", assignedInsurance.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "City", assignedInsurance.InsuredId);
            return View(assignedInsurance);
        }

        // GET: AssignedInsurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignedInsurance = await _context.AssignedInsurance
                .Include(a => a.Insurance)
                .Include(a => a.Insured)
                .FirstOrDefaultAsync(m => m.AssignedInsuranceId == id);
            if (assignedInsurance == null)
            {
                return NotFound();
            }

            return View(assignedInsurance);
        }

        // POST: AssignedInsurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignedInsurance = await _context.AssignedInsurance.FindAsync(id);
            _context.AssignedInsurance.Remove(assignedInsurance);
            await _context.SaveChangesAsync();
            this.AddFlashMessage(new FlashMessage("Pojištění pojištěnce bylo odstraněno", FlashMessageType.Success));
            return RedirectToAction("Details", "Insureds", new { id = assignedInsurance.InsuredId });
        }

        private bool AssignedInsuranceExists(int id)
        {
            return _context.AssignedInsurance.Any(e => e.AssignedInsuranceId == id);
        }
    }
}
