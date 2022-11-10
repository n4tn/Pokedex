using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonWebApp.Data;
using PokemonWebApp.Models;

namespace PokemonWebApp.Controllers
{
    public class PokedexesController : Controller
    {
        private readonly PokemonWebAppContext _context;

        public PokedexesController(PokemonWebAppContext context)
        {
            _context = context;
        }

        // GET: Pokedexes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pokedex.ToListAsync());
        }

        // GET: /Pokedexes/Pokemon/{searchstring} -- frontend 
        [HttpGet]
        //[Route("/Pokedexes/Pokemon/{searchstring}")]
        public async Task<IActionResult> Pokemon(string searchstring)
        {
            ViewData["GetPokemon"] = searchstring;
            if (searchstring == null || _context.Pokedex == null)
            {
                return NotFound();
            }
            var Pokemon = await _context.Pokedex.Where(x => x.Name.Contains(searchstring)).FirstOrDefaultAsync();
            if (Pokemon == null)
            {
                return NotFound();
            }
            return View(Pokemon);
        }
        // GET: /Pokedexes/Type/{searchstring} -- frontend
        [HttpGet]
        //[Route("/Pokedexes/Type/{searchstring}")]
        public async Task<IActionResult> Type(string searchstring)
        {
            ViewData["GetType"] = searchstring;
            if (searchstring == null || _context.Pokedex == null)
            {
                return NotFound();
            }
            var Type = await _context.Pokedex.Where(x => x.Types.Contains(searchstring)).ToListAsync();
            if (Type == null)
            {
                return NotFound();
            }
            return View(Type);
        }

        // GET: /Pokedexes/Height/{searchval} -- frontend
        [HttpGet]
        [Route("/Pokedexes/Height/{searchval}")]
        public async Task<IActionResult> Height(double searchval)
        {
            if (searchval == 0 || _context.Pokedex == null)
            {
                return NotFound();
            }
            var Height = await _context.Pokedex.Where(x => x.Height.Value == searchval).ToListAsync();
            if (Height == null)
            {
                return NotFound();
            }
            return View(Height);
        }

        // GET: /Pokedexes/Weight/{searchval} -- frontend
        [HttpGet]
        [Route("/Pokedexes/Weight/{searchval}")]
        public async Task<IActionResult> Weight(double searchval)
        {
            if (searchval == 0 || _context.Pokedex == null)
            {
                return NotFound();
            }
            var Weight = await _context.Pokedex.Where(x => x.Weight.Value == searchval).ToListAsync();
            if (Weight == null)
            {
                return NotFound();
            }
            return View(Weight);
        }

        // GET: /Pokedexes/Weakness/{searchstring} -- frontend
        [HttpGet]
        //[Route("/Pokedexes/Weakness/{searchstring}")]
        public async Task<IActionResult> Weakness(string searchstring)
        {
            ViewData["GetWeakness"] = searchstring;
            if (searchstring == null || _context.Pokedex == null)
            {
                return NotFound();
            }
            var Weakness = await _context.Pokedex.Where(x => x.Weakness.Contains(searchstring)).ToListAsync(); 
            if (Weakness == null)
            {
                return NotFound();
            }
            return View(Weakness);
        }


        // GET: Pokedexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pokedex == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // GET: Pokedexes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokedexes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Height,Weight,Gender")] Pokedex pokedex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokedex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokedex);
        }

        // GET: Pokedexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pokedex == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex == null)
            {
                return NotFound();
            }
            return View(pokedex);
        }

        // POST: Pokedexes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Height,Weight,Gender")] Pokedex pokedex)
        {
            if (id != pokedex.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokedex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokedexExists(pokedex.Id))
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
            return View(pokedex);
        }

        // GET: Pokedexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pokedex == null)
            {
                return NotFound();
            }

            var pokedex = await _context.Pokedex
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokedex == null)
            {
                return NotFound();
            }

            return View(pokedex);
        }

        // POST: Pokedexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pokedex == null)
            {
                return Problem("Entity set 'PokemonWebAppContext.Pokedex'  is null.");
            }
            var pokedex = await _context.Pokedex.FindAsync(id);
            if (pokedex != null)
            {
                _context.Pokedex.Remove(pokedex);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokedexExists(int id)
        {
          return _context.Pokedex.Any(e => e.Id == id);
        }
    }
}
