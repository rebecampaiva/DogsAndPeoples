using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogsAndPeoples.Data;
using DogsAndPeoples.Models;

namespace DogsAndPeoples.Controllers
{
    public class CaesController : Controller
    {
        private readonly DB_DogsAndPeoplesContext _context;

        public CaesController(DB_DogsAndPeoplesContext context)
        {
            _context = context;
        }

     

        // GET: Caes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caess.ToListAsync());
        }


        [HttpGet]
        public string GetCaes()
        {
            using (DB_DogsAndPeoplesContext _context = new DB_DogsAndPeoplesContext())
            {
                //var lista = _context.Ata.ToList();
                //return Json(lista);
                return JsonSerializer.Serialize(_context.Caess.ToList());
            }
        }


        // GET: Caes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caes = await _context.Caess
                .FirstOrDefaultAsync(m => m.CaesId == id);
            if (caes == null)
            {
                return NotFound();
            }

            return View(caes);
        }

        // GET: Caes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aerodromo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaesId,Nome")] Caes caes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caes);
        }

        // GET: Caes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caes = await _context.Caess.FindAsync(id);
            if (caes == null)
            {
                return NotFound();
            }
            return View(caes);
        }

        // POST: Caes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaesId,Nome")] Caes caes)
        {
            if (id != caes.CaesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AerodromoExists(caes.CaesId))
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
            return View(caes);
        }

        // GET: Aerodromo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caes = await _context.Caess
                .FirstOrDefaultAsync(m => m.CaesId == id);
            if (caes == null)
            {
                return NotFound();
            }

            return View(caes);
        }

        // POST: Caes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caes = await _context.Caess.FindAsync(id);
            _context.Caess.Remove(caes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AerodromoExists(int id)
        {
            return _context.Caess.Any(e => e.CaesId == id);
        }
    }
}
