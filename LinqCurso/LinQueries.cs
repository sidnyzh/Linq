using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace curso_linq
{
    public class LinQueries
    {

        //collección para guardar todos registros que vienen del book.json
        public List<Book> booksCollection = new();
        public LinQueries()
        {

            using (StreamReader reader = new StreamReader("Books.json"))
            {
                string json = reader.ReadToEnd();

                this.booksCollection = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            //se guarda dentro de un Json la lectura de todo el archivo 

        }
        public IEnumerable<Book> Collection()
        {
            return booksCollection;
        }

        // Reto #1
        // utilizando el operador Where retirna los libros que fueron publicados después del año 2000

        public IEnumerable<Book> BooksReleasedAfter2000()
        {

            //Extension method
            //IEnumerable<Book> BooksReleasedAfter2000 = booksCollection.Where(x => x.publishedDate.Year > 2000);

            //query expression

            IEnumerable<Book> BooksReleasedAfter2000 = from b in booksCollection
                                                       where b.publishedDate.Year > 2000
                                                       select b;

            return BooksReleasedAfter2000;
        }


        // Reto #2
        // utilizando el operador Where retorna los libros que tengan mas de 250 páginas y el titulo contenga las palabras in Action

        public IEnumerable<Book> BooksWithMoreThan250Pages()
        {

            //Extension mathod
            //IEnumerable<Book> booksWithMoreThan250Pages = booksCollection.Where(x => x.pageCount > 250 && x.title.Contains("in Action"));

            //query expression

            IEnumerable<Book> booksWithMoreThan250Pages = from b in booksCollection
                                                          where b.pageCount > 250 && b.title.Contains("in Action")
                                                          select b;
                                                           

            return booksWithMoreThan250Pages;
        } 

    }
}
