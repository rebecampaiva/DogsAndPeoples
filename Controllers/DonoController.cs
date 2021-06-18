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
    public class DonoController : Controller
    {
        private readonly DB_DogsAndPeoplesContext _context;

        public DonoController(DB_DogsAndPeoplesContext context)
        {
            _context = context;
        }

        // GET: Aeronave
       /* public async Task<IActionResult> Index()
        {
            var dB_DogsAndPeoplesContext = _context.Donos.Include(a => a.Aerodromo).Include(a => a.ModeloAeronave);
          return View(await dB_DogsAndPeoplesContext.ToListAsync());
        }*/

        [HttpGet]
        public string GetDono()
        {
            using (DB_DogsAndPeoplesContext _context = new DB_DogsAndPeoplesContext())
            {
                return JsonSerializer.Serialize(_context.Donos.ToList());
            }
        }




      

     

        // POST: Aeronave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AeronaveId,Nome")] Dono dono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonoId"] = new SelectList((from s in _context.Donos.OrderBy(m => m.Nome).ToList()
                                                      select new
                                                      {
                                                          DonosId = s.DonoId,
                                                          Nome =  s.Nome 
                                                      }), "AerodromoId", "Nome", null);

            return View(dono);
        }

     
    }
}
