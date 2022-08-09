using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Data;
using EvidencePojisteni.Models.InsuranceEvents;
using EvidencePojisteni.Extensions;
using EvidencePojisteni.Models.Insureds;
using EvidencePojisteni.Classes;
using Microsoft.AspNetCore.Identity;

namespace EvidencePojisteni.Controllers
{
    public class InsuranceEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public InsuranceEventsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: InsuranceEvents
        public async Task<IActionResult> Index()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var insuredId = _context.Insured.Where(x => x.UserId == userId).Select(x => x.InsuredId).FirstOrDefault();
            ViewBag.InsuredId = insuredId;
            var applicationDbContext = _context.InsuranceEvent.Include(i => i.Insurance).Include(i => i.Insured);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InsuranceEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceEvent = await _context.InsuranceEvent
                .Include(i => i.Insurance)
                .Include(i => i.Insured)
                .FirstOrDefaultAsync(m => m.InsuranceEventId == id);
            if (insuranceEvent == null)
            {
                return NotFound();
            }

            return View(insuranceEvent);
        }

        // GET: InsuranceEvents/Create
        public IActionResult Create(int insuredId)
        {
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName");
            return View();
        }

        // POST: InsuranceEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventInsuranceView model, string BtnNext)
        {
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    InsuranceEvent insuranceEvent = GetInsuranceEvent();
                    insuranceEvent.InsuranceId = model.InsuranceId;
                    insuranceEvent.InsuredId = model.InsuredId;

                    HttpContext.Session.SetObject("DataObject", insuranceEvent);

                    if (User.Identity.IsAuthenticated)
                    {
                        var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                        var user = _context.Insured.Where(x => x.UserId == userId);

                        insuranceEvent.FirstName = user.Select(x => x.FirstName).FirstOrDefault();
                        insuranceEvent.SurName = user.Select(x => x.SurName).FirstOrDefault();
                        insuranceEvent.Gender = user.Select(x => x.Gender).FirstOrDefault();
                        insuranceEvent.Email = user.Select(x => x.Email).FirstOrDefault();
                        insuranceEvent.Phone = user.Select(x => x.Phone).FirstOrDefault();
                        insuranceEvent.Street = user.Select(x => x.Street).FirstOrDefault();
                        insuranceEvent.City = user.Select(x => x.City).FirstOrDefault();
                        insuranceEvent.Zip = user.Select(x => x.Zip).FirstOrDefault();

                        HttpContext.Session.SetObject("DataObject", insuranceEvent);

                        return View("CreateThirdStep");
                    }
                    else
                        return View("CreateSecondStep");
                }
            }
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", model.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", model.InsuredId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSecondStep(InsuredBase model, string BtnPrevious, string BtnNext)
        {
            InsuranceEvent insuranceEvent = GetInsuranceEvent();

            if (BtnPrevious != null)
            {
                EventInsuranceView info = new EventInsuranceView();
                info.InsuranceId = insuranceEvent.InsuranceId;
                info.InsuredId = insuranceEvent.InsuredId;
                ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", info.InsuranceId);
                ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", info.InsuredId);
                return View("Create", info);
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    insuranceEvent.FirstName = model.FirstName;
                    insuranceEvent.SurName = model.SurName;
                    insuranceEvent.Gender = model.Gender;
                    insuranceEvent.Email = model.Email;
                    insuranceEvent.Phone = model.Phone;
                    insuranceEvent.Street = model.Street;
                    insuranceEvent.City = model.City;
                    insuranceEvent.Zip = model.Zip;

                    HttpContext.Session.SetObject("DataObject", insuranceEvent);

                    return View("CreateThirdStep");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateThirdStep(EventDetailsView model, string BtnPrevious, string BtnNext)
        {
            InsuranceEvent insuranceEvent = GetInsuranceEvent();

            if (BtnPrevious != null)
            {
                if(User.Identity.IsAuthenticated)
                {
                    EventInsuranceView info = new EventInsuranceView();
                    info.InsuranceId = insuranceEvent.InsuranceId;
                    info.InsuredId = insuranceEvent.InsuredId;
                    ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", info.InsuranceId);
                    ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", info.InsuredId);
                    return View("Create", info);
                }
                else
                {
                    InsuredBase info = new InsuredBase();
                    info.FirstName = insuranceEvent.FirstName;
                    info.SurName = insuranceEvent.SurName;
                    info.Gender = insuranceEvent.Gender;
                    info.Email = insuranceEvent.Email;
                    info.Phone = insuranceEvent.Phone;
                    info.Street = insuranceEvent.Street;
                    info.City = insuranceEvent.City;
                    info.Zip = insuranceEvent.Zip;
                    return View("CreateSecondStep", info);
                }
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    insuranceEvent.EventDate = model.EventDate;
                    insuranceEvent.EventDescription = model.EventDescription;

                    HttpContext.Session.SetObject("DataObject", insuranceEvent);

                    return View("CreateFourthStep");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFourthStep(EventCompensationView model, string BtnPrevious, string BtnNext, string BtnCancel)
        {
            InsuranceEvent insuranceEvent = GetInsuranceEvent();

            if (BtnPrevious != null)
            {
                EventDetailsView info = new EventDetailsView();
                info.EventDate = insuranceEvent.EventDate;
                info.EventDescription = insuranceEvent.EventDescription;
                return View("CreateThirdStep", info);
            }
            if (BtnNext != null)
            {
                if (ModelState.IsValid)
                {
                    insuranceEvent.AccountNumber = model.AccountNumber;
                    insuranceEvent.BankCode = model.BankCode;

                    _context.Add(insuranceEvent);
                    await _context.SaveChangesAsync();
                    this.AddFlashMessage(new FlashMessage("Pojistná událost byla vytvořena", FlashMessageType.Success));
                    if (User.Identity.IsAuthenticated)
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            if (BtnCancel != null)
                RemoveInsuranceEvent();
            return View();
        }

        // GET: InsuranceEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceEvent = await _context.InsuranceEvent.FindAsync(id);
            var name = _context.InsuranceEvent.Where(n => n.InsuredId == insuranceEvent.InsuredId).FirstOrDefault();
            ViewBag.Name = name.FirstName + " " + name.SurName;
            if (insuranceEvent == null)
            {
                return NotFound();
            }
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", insuranceEvent.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", insuranceEvent.InsuredId);
            return View(insuranceEvent);
        }

        // POST: InsuranceEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsuranceEventId,InsuranceId,InsuredId,EventDate,EventDescription,AccountNumber,BankCode,InsuranceRole,FirstName,SurName,Gender,Email,Phone,Street,City,Zip")] InsuranceEvent insuranceEvent)
        {
            if (id != insuranceEvent.InsuranceEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceEventExists(insuranceEvent.InsuranceEventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                this.AddFlashMessage(new FlashMessage("Pojistná událost byla upravena", FlashMessageType.Success));
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", insuranceEvent.InsuranceId);
            ViewData["InsuredId"] = new SelectList(_context.Insured, "InsuredId", "FirstName", insuranceEvent.InsuredId);
            return View(insuranceEvent);
        }

        // GET: InsuranceEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceEvent = await _context.InsuranceEvent
                .Include(i => i.Insurance)
                .Include(i => i.Insured)
                .FirstOrDefaultAsync(m => m.InsuranceEventId == id);
            if (insuranceEvent == null)
            {
                return NotFound();
            }

            return View(insuranceEvent);
        }

        // POST: InsuranceEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceEvent = await _context.InsuranceEvent.FindAsync(id);
            _context.InsuranceEvent.Remove(insuranceEvent);
            await _context.SaveChangesAsync();
            this.AddFlashMessage(new FlashMessage("Pojistná událost byla odstraněna", FlashMessageType.Success));
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceEventExists(int id)
        {
            return _context.InsuranceEvent.Any(e => e.InsuranceEventId == id);
        }

        private InsuranceEvent GetInsuranceEvent()
        {
            if (HttpContext.Session.GetObject<InsuranceEvent>("DataObject") == null)
            {
                HttpContext.Session.SetObject("DataObject", new InsuranceEvent());
            }
            return (InsuranceEvent)HttpContext.Session.GetObject<InsuranceEvent>("DataObject");
        }
        private void RemoveInsuranceEvent()
        {
            HttpContext.Session.SetObject("DataObject", null);
        }
    }
}
