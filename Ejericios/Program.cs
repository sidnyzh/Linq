using Ejericios;
using System.Text.RegularExpressions;

List<Animal> animales = new List<Animal>();

animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });


// filtra todos los animales que sean de color verde que su nombre inicie con una vocal

var reg = new Regex("^[aeiouAEIOU].*");
var starsWithValueAndItsColorIsGreen = animales.Where(x => x.Color.Equals("Verde") && reg.IsMatch(x.Nombre));

//foreach (var item in starsWithValueAndItsColorIsGreen)
//{
//    Console.WriteLine(item.Nombre);
//}

// Retorna los elementos de la colleción animal ordenados por nombre


var orderByName = animales.OrderBy(x => x.Nombre);

foreach (var animal in orderByName) Console.WriteLine(animal.Nombre);

// Retorna los datos de la colleción Animales agrupada por color 

void AnimalesAgrupadoPorColor()
{
    IEnumerable<IGrouping<string, Animal>> animalesAgrupadosPorColor = animales.GroupBy( x => x.Color);
    
    foreach (var grupo in animalesAgrupadosPorColor)
    {
        Console.WriteLine(grupo.Key);
        
        foreach(var animal in grupo)
        {
            Console.WriteLine($" Nombre: {animal.Nombre} Color: {animal.Color}");
        }
    }
}

AnimalesAgrupadoPorColor();


