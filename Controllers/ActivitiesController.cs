using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
   // [ApiController]
 //  [Route("api/[controller]")]
    //  [Authorize]

    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index() //pe baza index()-el imi va arata toate activitatile scrise 
        {//codul bazei de date care a fost creat de enitity framework:
              return View(await _context.Activities.ToListAsync());
        }

        
        // GET: Activities/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()  
        {
            return View();//ca parametru avem tot ShowSearchForm-insa odata ce metoda are acest nume, param nu are rost sa l mai scriem
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {

            return View("Index", await _context.Activities
                .Where(j => j.Medic.Contains(SearchPhrase) || j.Pacient.Contains(SearchPhrase))
                .ToListAsync());
        }


        // GET: Activities/Details
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

       
        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.

      //  [Authorize] il punem si aici pt ca e mai important pt securitate caci intra niste date in baza de date!

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amprentare,Medic,Pacient,Manopera,Componente,Elemente,Pret_Element,Pret_Manopera,Adaos,Pret_Final,Status_plata,Livrare,Data_incasarii,Mentiuni")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Id = Guid.NewGuid();
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Amprentare,Medic,Pacient,Manopera,Componente,Elemente,Pret_Element,Pret_Manopera,Adaos,Pret_Final,Status_plata,Livrare,Data_incasarii,Mentiuni")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Id))
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
            return View(activity);
        }

        // GET: Activities/Delete/
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Activities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Activity'  is null.");
            }
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(Guid id)
        {
          return _context.Activities.Any(e => e.Id == id);
        }
    }
}
