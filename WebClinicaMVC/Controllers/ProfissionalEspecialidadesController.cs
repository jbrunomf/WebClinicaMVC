using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebClinicaMVC.Data;
using WebClinicaMVC.Models;

namespace WebClinicaMVC.Controllers
{
    public class ProfissionalEspecialidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionalEspecialidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfissionalEspecialidades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfissionalEspecialidades.Include(p => p.Especialidade).Include(p => p.Profissional);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfissionalEspecialidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfissionalEspecialidades == null)
            {
                return NotFound();
            }

            var profissionalEspecialidade = await _context.ProfissionalEspecialidades
                .Include(p => p.Especialidade)
                .Include(p => p.Profissional)
                .FirstOrDefaultAsync(m => m.IdEspecialidade == id);
            if (profissionalEspecialidade == null)
            {
                return NotFound();
            }

            return View(profissionalEspecialidade);
        }

        // GET: ProfissionalEspecialidades/Create
        public IActionResult Create()
        {
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "Id", "Nome");
            ViewData["IdProfissional"] = new SelectList(_context.Profissionais, "Id", "Id");
            return View();
        }

        // POST: ProfissionalEspecialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfissional,IdEspecialidade")] ProfissionalEspecialidade profissionalEspecialidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissionalEspecialidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalEspecialidade.IdEspecialidade);
            ViewData["IdProfissional"] = new SelectList(_context.Profissionais, "Id", "Id", profissionalEspecialidade.IdProfissional);
            return View(profissionalEspecialidade);
        }

        // GET: ProfissionalEspecialidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfissionalEspecialidades == null)
            {
                return NotFound();
            }

            var profissionalEspecialidade = await _context.ProfissionalEspecialidades.FindAsync(id);
            if (profissionalEspecialidade == null)
            {
                return NotFound();
            }
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalEspecialidade.IdEspecialidade);
            ViewData["IdProfissional"] = new SelectList(_context.Profissionais, "Id", "Id", profissionalEspecialidade.IdProfissional);
            return View(profissionalEspecialidade);
        }

        // POST: ProfissionalEspecialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfissional,IdEspecialidade")] ProfissionalEspecialidade profissionalEspecialidade)
        {
            if (id != profissionalEspecialidade.IdEspecialidade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionalEspecialidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalEspecialidadeExists(profissionalEspecialidade.IdEspecialidade))
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
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalEspecialidade.IdEspecialidade);
            ViewData["IdProfissional"] = new SelectList(_context.Profissionais, "Id", "Id", profissionalEspecialidade.IdProfissional);
            return View(profissionalEspecialidade);
        }

        // GET: ProfissionalEspecialidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfissionalEspecialidades == null)
            {
                return NotFound();
            }

            var profissionalEspecialidade = await _context.ProfissionalEspecialidades
                .Include(p => p.Especialidade)
                .Include(p => p.Profissional)
                .FirstOrDefaultAsync(m => m.IdEspecialidade == id);
            if (profissionalEspecialidade == null)
            {
                return NotFound();
            }

            return View(profissionalEspecialidade);
        }

        // POST: ProfissionalEspecialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfissionalEspecialidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfissionalEspecialidades'  is null.");
            }
            var profissionalEspecialidade = await _context.ProfissionalEspecialidades.FindAsync(id);
            if (profissionalEspecialidade != null)
            {
                _context.ProfissionalEspecialidades.Remove(profissionalEspecialidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalEspecialidadeExists(int id)
        {
          return (_context.ProfissionalEspecialidades?.Any(e => e.IdEspecialidade == id)).GetValueOrDefault();
        }
    }
}
