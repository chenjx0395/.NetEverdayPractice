using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

[HttpGet]
public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

[HttpGet("{id}")]
public ActionResult<Pizza> Get(int id)
{
    var pizza = PizzaService.Get(id);

    if(pizza == null)
        return NotFound();

    return pizza;
}

[HttpPost]
public IActionResult Create(Pizza pizza)
{            
    PizzaService.Add(pizza);

}

[HttpPut("{id}")]
public IActionResult Update(int id, Pizza pizza)
{
    PizzaService.Update(id, pizza);
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    PizzaService.Delete(id);
}
}