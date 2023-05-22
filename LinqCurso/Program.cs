﻿using curso_linq;

LinQueries queries = new LinQueries();

//Toda la coección
//PrintValues(queries.Collection());

//Libros despues del 2000
//PrintValues(queries.BooksReleasedAfter2000());

//Libros que tienen mas de 250 paginas y contienen "in action" en su titulo 
//PrintValues(queries.BooksWithMoreThan250Pages());

//Libros que tienen estatus 
//Console.WriteLine($" ¿Todos los libros tienen status? : {queries.BooksHaveStatus()}");

//Algun libro fue publicado en 2005?
//Console.WriteLine($" ¿Algun libro fue publicado en 2005?? : {queries.AnyBookWasPublishedIn2005()}");

//Elementos que pertenezcan a la categoría de Python
//PrintValues(queries.PythonBooks());

//Elementos que pertenezcan a la categoría de Java ordenados de forma ascendene 
//PrintValues(queries.JavaBooksOrderedByName());

//Utilizando el operador OrderByDescending retornar todos los elementos que tengan más de 450 páginas, oedenados por número de páginas en forma descendente. 
PrintValues(queries.BooksWithMorethan450PAgesOrderedByName());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -70} {1,15} {2,11}", "Titulo", "N. Paginas", "Fecha de publicación");

    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -70} {1,15} {2,15}/n", book.title, book.pageCount, book.publishedDate.ToShortDateString());
    }
}

