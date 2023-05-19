using curso_linq;

LinQueries queries = new LinQueries();

//Toda la coección
//PrintValues(queries.Collection());

//Libros despues del 2000
//PrintValues(queries.BooksReleasedAfter2000());

//Libros que tienen mas de 250 paginas y contienen "in action" en su titulo 

PrintValues(queries.BooksWithMoreThan250Pages());

void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0, -70} {1,15} {2,11}", "Titulo", "N. Paginas", "Fecha de publicación");

    foreach (var book in booksList)
    {
        Console.WriteLine("{0, -70} {1,15} {2,15}/n", book.title, book.pageCount, book.publishedDate.ToShortDateString());
    }
}

