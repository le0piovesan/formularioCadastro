using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormularioCadastro.Models;

namespace FormularioCadastro.Controllers
{
    public class FormularioController : Controller
    {
        private readonly Context _context;

        public FormularioController(Context context)
        {
            _context = context;
        }

        // GET: Formulario
        public async Task<IActionResult> Index()
        {
              return _context.Formulario != null ? 
                          View(await _context.Formulario.ToListAsync()) :
                          Problem("Entity set 'Context.Formulario'  is null.");
        }

        // GET: Formulario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Formulario == null)
            {
                return NotFound();
            }

            var dbFormulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.id_usuario == id);
            if (dbFormulario == null)
            {
                return NotFound();
            }

            return View(dbFormulario);
        }

        // GET: Formulario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formulario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_usuario,nome,email,data_nascimento,rua,num,cidade,uf,mensagem")] DbFormulario dbFormulario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbFormulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbFormulario);
        }

        // GET: Formulario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Formulario == null)
            {
                return NotFound();
            }

            var dbFormulario = await _context.Formulario.FindAsync(id);
            if (dbFormulario == null)
            {
                return NotFound();
            }
            return View(dbFormulario);
        }

        // POST: Formulario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_usuario,nome,email,data_nascimento,rua,num,cidade,uf,mensagem")] DbFormulario dbFormulario)
        {
            if (id != dbFormulario.id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbFormulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbFormularioExists(dbFormulario.id_usuario))
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
            return View(dbFormulario);
        }

        // GET: Formulario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Formulario == null)
            {
                return NotFound();
            }

            var dbFormulario = await _context.Formulario
                .FirstOrDefaultAsync(m => m.id_usuario == id);
            if (dbFormulario == null)
            {
                return NotFound();
            }

            return View(dbFormulario);
        }

        // POST: Formulario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Formulario == null)
            {
                return Problem("Entity set 'Context.Formulario'  is null.");
            }
            var dbFormulario = await _context.Formulario.FindAsync(id);
            if (dbFormulario != null)
            {
                _context.Formulario.Remove(dbFormulario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbFormularioExists(int id)
        {
          return (_context.Formulario?.Any(e => e.id_usuario == id)).GetValueOrDefault();
        }
    }
}
