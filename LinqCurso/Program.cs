using curso_linq;

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
//PrintValues(queries.BooksWithMorethan450PAgesOrderedByName());

//primeros 3 libros con fecha de publicación más reciente que estén categotizados en Java 
//PrintValues(queries.ThreeMostRecentJavaBooks());

//Seleccionar el tercer y cuarto libro de los que tengan más de 400 páginas 
//PrintValues(queries.ThirtdAndFourthBooksWithMoreThan400Pages());

//Número de libros que tienen entre 200 y 500 páginas
//Console.WriteLine(queries.NumberOfBooksWithPAgesBetween200And500());

//Fecha de publicación menor 
Console.WriteLine(queries.MinpublishedDate());

//Cantidad de páginas del libro con mayor número de páginas en la colección 
Console.WriteLine(queries.MaxPagesNumber());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -70} {1,15} {2,11}", "Titulo", "N. Paginas", "Fecha de publicación");

    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -70} {1,15} {2,15}/n", book.title, book.pageCount, book.publishedDate.ToShortDateString());
    }
}

