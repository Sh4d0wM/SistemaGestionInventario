
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Data;
using SistemaGestionInventario.Models;
using System.Globalization;

public class ProductosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTOS
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Productos.Include(p => p.Categoria);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: PRODUCTOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (producto == null) return NotFound();

        return View(producto);
    }
    // GET: Productos/Create
    public IActionResult Create()
    {
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre");
        return View();
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,Stock,CategoriaId")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Si hay un error de validación, recargamos la lista desplegable para que no desaparezca
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.CategoriaId);
        return View(producto);
    }

    // GET: Productos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();

        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.CategoriaId);
        return View(producto);
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,Stock,CategoriaId")] Producto producto)
    {
        if (id != producto.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(producto.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nombre", producto.CategoriaId);
        return View(producto);
    }

    // GET: PRODUCTOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Id == id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: PRODUCTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto != null)
        {
            _context.Productos.Remove(producto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Interpreta correctamente los precios con coma o punto decimal.
    private void LeerPrecioDesdeFormulario(Producto producto)
    {
        string texto = Request.Form["Precio"].ToString().Trim();

        // Quita la conversión previa de ASP.NET para validar el texto original.
        ModelState.Remove(nameof(Producto.Precio));

        // Acepta 2,50 y 2.50.
        texto = texto.Replace(',', '.');

        if (decimal.TryParse(
            texto,
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out decimal precio))
        {
            if (precio < 0.01m || precio > 999999.99m)
            {
                ModelState.AddModelError(
                    nameof(Producto.Precio),
                    "El precio debe estar entre 0,01 y 999999,99.");
            }
            else
            {
                producto.Precio = precio;
            }
        }
        else
        {
            ModelState.AddModelError(
                nameof(Producto.Precio),
                "Ingrese un precio válido. Ejemplo: 2,50.");
        }           
    }
   
    private bool productExists(int? id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}

