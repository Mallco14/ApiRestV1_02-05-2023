namespace ApiRest.Models;


//Crear clase de la que deseamos con sus atributos
public class Pizza
{
    public int Id { get; set; }

    public string? Name { get; set; } = null;

    public bool IsGlutenFree { get; set; }

}