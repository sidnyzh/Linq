﻿using Ejericios;
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

foreach (var item in starsWithValueAndItsColorIsGreen)
{
    Console.WriteLine(item.Nombre);
}