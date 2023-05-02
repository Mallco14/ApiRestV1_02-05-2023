using ApiRest.Models;
using ApiRest.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiRest.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }
    //GET ALL ACTION
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();
    //GET by Id action
    //Se selecciona el tipo de filtro de data y se agregar el pizza/id
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound();

        return pizza;
    }
    //POST action

    [HttpPost]
    // esto devuelve un resultado al cliente
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get),
            new { id = pizza.Id }, pizza);
    }

    //PUT action.
    //Se modifica mediante el id, esto puede cambiar
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        //verifica que el id que se quiera actualizar
        //se encuentra en el api caso contrario sale error
        if (id != pizza.Id)
            return BadRequest();

        //llama al meteodo get de pizza service para obtener la pizza
        //existente en el api o bd
        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            //retorna que no se a encontrado
            return NotFound();

        //Se llama tambien el metodo update de la calse PizzaService
        //para actualizar con los nuevos datos
        PizzaService.Update(pizza);
        
        //Esto devuelve al cliente que a sido procesado con exito.
        return NoContent();
    }



    //DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        //Primero encontrar la pizza
        var encontrapizza = PizzaService.Get(id); //encontre la pizza

        //validar si la piiza no es nula

        if (encontrapizza is null)
            return NotFound(); //Este return indica para que no encontrado

        //Llamo al metodo delete de pizza service y le paso el id para eliminar
        PizzaService.Delete(id);

        //Esto devuelve al cliente que a sido procesado con exito.
        return NoContent();
    }

}
