using Microsoft.AspNetCore.Mvc;
using Scratch_Activity.Data;
using Scratch_Activity.Models;

namespace Scratch_Activity.Controllers;

public class CustomerController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var customers = _context.Customers.ToList();
        return View(customers);
    }
    public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Customer customer)
{
    if (ModelState.IsValid)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(customer);
}
public IActionResult Edit(int id)
{
    var customer = _context.Customers.Find(id);

    if (customer == null)
    {
        return NotFound();
    }

    return View(customer);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Customer customer)
{
    if (ModelState.IsValid)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    return View(customer);
}
public IActionResult Delete(int id)
{
    var customer = _context.Customers.Find(id);

    if (customer == null)
    {
        return NotFound();
    }

    return View(customer);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var customer = _context.Customers.Find(id);

    if (customer != null)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    return RedirectToAction(nameof(Index));
}
}