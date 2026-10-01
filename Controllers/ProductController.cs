using Microsoft.AspNetCore.Mvc;
using Scratch_Activity.Data;
using Scratch_Activity.Models;

namespace Scratch_Activity.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
    public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Product product)
{
    if (ModelState.IsValid)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(product);
}
public IActionResult Edit(int id)
{
    var product = _context.Products.Find(id);

    if (product == null)
    {
        return NotFound();
    }

    return View(product);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Product product)
{
    if (ModelState.IsValid)
    {
        _context.Products.Update(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(product);
}
public IActionResult Delete(int id)
{
    var product = _context.Products.Find(id);

    if (product == null)
    {
        return NotFound();
    }

    return View(product);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var product = _context.Products.Find(id);

    if (product != null)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    return RedirectToAction(nameof(Index));
}
}