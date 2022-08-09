using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidencePojisteni.Data;
using EvidencePojisteni.Models.Insurances;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EvidencePojisteni.Classes;
using EvidencePojisteni.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EvidencePojisteni.Controllers
{
    [ExceptionsToMessageFilter]
    [Authorize(Roles = "Admin")]
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InsurancesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Insurances
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurance.ToListAsync());
        }

        // GET: Insurances/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance
                .FirstOrDefaultAsync(m => m.InsuranceId == id);

            var insuranceView = new InsuranceView()
            {
                InsuranceId = insurance.InsuranceId,
                InsuranceName = insurance.InsuranceName,
                InsuranceDescription = insurance.InsuranceDescription,
                ExistingImage = insurance.InsuranceImage
            };

            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        // GET: Insurances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceView model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Insurance insurance = new Insurance()
                {
                    InsuranceName = model.InsuranceName,
                    InsuranceDescription = model.InsuranceDescription,
                    InsuranceImage = uniqueFileName
                };

                _context.Add(insurance);
                await _context.SaveChangesAsync();
                this.AddFlashMessage(new FlashMessage("Pojištění bylo vytvořeno", FlashMessageType.Success));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Insurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance.FindAsync(id);
            var insuranceView = new InsuranceView()
            {
                InsuranceId = insurance.InsuranceId,
                InsuranceName = insurance.InsuranceName,
                InsuranceDescription = insurance.InsuranceDescription,
                ExistingImage = insurance.InsuranceImage
            };

            if (insurance == null)
            {
                return NotFound();
            }
            return View(insuranceView);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InsuranceView model)
        {
            if (ModelState.IsValid)
            {
                var insurance = await _context.Insurance.FindAsync(model.InsuranceId);
                insurance.InsuranceName = model.InsuranceName;
                insurance.InsuranceDescription = model.InsuranceDescription;

                if (model.InsuranceImage != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images\\insurances", model.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    insurance.InsuranceImage = ProcessUploadedFile(model);
                }
                _context.Update(insurance);
                await _context.SaveChangesAsync();
                this.AddFlashMessage(new FlashMessage("Pojištění bylo změněno", FlashMessageType.Success));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Insurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance
                .FirstOrDefaultAsync(m => m.InsuranceId == id);

            var insuranceView = new InsuranceView()
            {
                InsuranceId = insurance.InsuranceId,
                InsuranceName = insurance.InsuranceName,
                InsuranceDescription = insurance.InsuranceDescription,
                ExistingImage = insurance.InsuranceImage
            };
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insuranceView);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insurance = await _context.Insurance.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\insurances\\", insurance.InsuranceImage);
            _context.Insurance.Remove(insurance);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            await _context.SaveChangesAsync();
            this.AddFlashMessage(new FlashMessage("Pojištění bylo úspěšně odstraněno", FlashMessageType.Success));
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceExists(int id)
        {
            return _context.Insurance.Any(e => e.InsuranceId == id);
        }

        private string ProcessUploadedFile(InsuranceView model)
        {
            string uniqueFileName = null;

            if (model.InsuranceImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images\\insurances");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.InsuranceImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.InsuranceImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
