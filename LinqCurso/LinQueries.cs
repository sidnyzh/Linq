﻿using Newtonsoft.Json;
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

        // Reto #1 Where
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

        //All
        //Los libros tienen status 

        public bool BooksHaveStatus()
        {
            bool booksHaveStatus;
            booksHaveStatus = booksCollection.All(x => x.status != string.Empty);   

            return booksHaveStatus;
        }

        //Any 
        //verifica si alguno de los libros fue publicado en 2005

        public bool AnyBookWasPublishedIn2005()
        {
            bool anyBookWasPublishedIn2005;
            anyBookWasPublishedIn2005 = booksCollection.Any(x => x.publishedDate.Year == 2005);
            return anyBookWasPublishedIn2005;
        }

        //Contains 
        //Utilizando el operador Contains retorna los elementos que pertenezcan a la categoría de Python. 
        public IEnumerable<Book> PythonBooks()
        {
            IEnumerable<Book> pythonBooks;

            //pythonBooks = booksCollection.Where(x => x.categories.Contains("Python"));
            pythonBooks = from b in booksCollection
                          where b.categories.Contains("Python") 
                          select b;   

            return pythonBooks;
        }

        //OrderBy
        //Utilizando el operador OrderBy retornar todos los elementos que sean de la categoría de Java ordenados por nombre. 

        public IEnumerable<Book> JavaBooksOrderedByName()
        {
            IEnumerable<Book> javaBooksOrderedByName;

            //javaBooksOrderedByName = booksCollection.Where(x => x.categories.Contains("Java")).OrderBy(x => x.title);
            
            javaBooksOrderedByName = from b in booksCollection
                                     where b.categories.Contains("Java")
                                     orderby b.title
                                     select b;


            return javaBooksOrderedByName;
        }

        //OrderByDescending
        //Utilizando el operador OrderByDescending retornar todos los elementos que tengan más de 450 páginas, oedenados por número de páginas en forma descendente. 

        public IEnumerable<Book> BooksWithMorethan450PAgesOrderedByName()
        {
            IEnumerable<Book> booksWithMorethan450PAgesOrderedByName;
            //booksWithMorethan450PAgesOrderedByName = booksCollection.Where(x => x.pageCount >450).OrderByDescending(x => x.pageCount);
            booksWithMorethan450PAgesOrderedByName= from b in booksCollection
                                                    where b.pageCount > 450
                                                    orderby b.pageCount descending
                                                    select b;

            return booksWithMorethan450PAgesOrderedByName;
        }

        //Take 
        //seleccionar los primeros 3 libros con fecha de publicación más reciente que estén categotizados en Java 

        public IEnumerable<Book> ThreeMostRecentJavaBooks()
        {
            IEnumerable<Book> threeMostRecentJavaBooks;
            threeMostRecentJavaBooks = booksCollection.Where(x => x.categories.Contains("Java")).OrderByDescending(x => x.publishedDate).Take(3);

            IEnumerable<Book> threeMostRecentJavaBookss = (from b in booksCollection
                                                          where b.categories.Contains("Java")
                                                          orderby b.publishedDate descending
                                                          select b).Take(3);
            return threeMostRecentJavaBooks;
        }

        //Skip 
        //Seleccionar el tercer y cuarto libro de los que tengan más de 400 páginas 

        internal IEnumerable<Book> ThirtdAndFourthBooksWithMoreThan400Pages()
        {
            IEnumerable<Book> ThirtdAndFourthBooksWithMoreThan400Pages;
            ThirtdAndFourthBooksWithMoreThan400Pages = booksCollection
                .Where(x => x.pageCount > 400)
                .OrderBy(x => x.pageCount)
                .Take(4).Skip(2);
            return ThirtdAndFourthBooksWithMoreThan400Pages;
        }

        //Count
        //Número de libros que tienen entre 200 y 500 páginas 

        internal int NumberOfBooksWithPAgesBetween200And500()
        {
            int numberOfBooksWithPAgesBetween200And500 = booksCollection.Where(x => x.pageCount >=200 && x.pageCount <= 500 ).Count();

            //Query Expression
            int numberOfBooksWithPAgesBetween200And5002 = (from b in booksCollection
                                                          where b.pageCount >= 200 && b.pageCount <= 500
                                                          select b).Count();
                                                         

            return numberOfBooksWithPAgesBetween200And5002;
        }

        //Min 
        //Fecha de publicación menor 

        internal DateTime MinpublishedDate()
        {
            DateTime minpublishedDate;

            minpublishedDate = booksCollection.Min(x => x.publishedDate);

            return minpublishedDate;
        }

        //Min 
        //Cantidad de páginas del libro con mayor número de páginas en la colección 

        internal int MaxPagesNumber()
        {
            int maxPagesNumber;

            maxPagesNumber = booksCollection.Max(x => x.pageCount);

            return maxPagesNumber;
        }
        //MInBy
        //Libro que tenga la menor cantidad de páginas mayor a 0 

        internal Book BookWithLessPages()
        {
            Book bookWithLessPages;

            bookWithLessPages = booksCollection.Where(x => x.pageCount > 0).MinBy(x => x.pageCount )!;

            return bookWithLessPages;
             
        }

        //MaxBy 
        //libro con la fecha de publicación más reciente 

        internal Book MostRecentBook() 
        {
            Book mostRecentBook;

            mostRecentBook = booksCollection.MaxBy(x => x.publishedDate)!;

            return mostRecentBook;
            
        }

        //Sum
        //Suma de la cantidad de páginas de todos los libros que tengan entre 0 y 500

        internal int CountPages()
        {
            int CountPages;

            CountPages = booksCollection.Where(x => x.pageCount >= 0  && x.pageCount <=500).Sum(x => x.pageCount);

            return CountPages;

        }

        //Agregate
        //Retornar el titulo de los libros publicados despúes del 2015

        internal string BookstitleReleasesAfter2015()
        {
            string BookstitleReleasesAfter2015;
            BookstitleReleasesAfter2015 = booksCollection.Where(x => x.publishedDate.Year > 2015)
                // la semilla representa un string que sería el valor inicial 
                .Aggregate("", (titulosLibros, next) =>
            {
                if (titulosLibros != string.Empty)
                {
                    titulosLibros += "- " + next.title;
                }
                else
                {
                    titulosLibros += next.title;
                }

                return titulosLibros;
            });

            return BookstitleReleasesAfter2015;
        }

        //Average
        //Promedio de caracteres que tienen los libros en sus titulos 

        internal double tittleCharacteresAverage()
        {
            //Esta función puede devolver un double
            double average; 
            average = booksCollection.Average(x => x.title.Length);
            return average;
        }

        //GroupBy
        //Retornar todos los libros que fueron publicados a partir del 2000, agrupados por año 

        //El int, corresponde al tipo de dato por el que será agrupado, en este caso, el año 
        internal IEnumerable<IGrouping<int,Book>> GroupByYear()
        {
            var gropedBooks = booksCollection.Where(x=> x.publishedDate.Year >= 2000).GroupBy(x => x.publishedDate.Year);
            return gropedBooks;
        }

        //Lookup
        //Retorna un diccionario que permita consultar los libros de acuierdo a la letra con la que inicia el titulo del libro 

        internal ILookup<char, Book> DictionaryOfBooksByLetter() 
        {
            ILookup<char, Book> dictionary;
            //se obtiene el primer caracter deltitulo y se agrupa todo el objeto libro 
            dictionary = booksCollection.ToLookup(x => x.title[0], x => x);
            return dictionary;
        }


        //Obtén una colección que tenga todos los libros con más de 500 páginas y otra que contenga los libros publicados después del 2005. 
        //Utilizando la cláusula Join, retorna los libros que estén en ambascolecciones.

        internal IEnumerable<Book> BooksReleasedAfter2005WithMoreThan500PAges()
        {
            IEnumerable<Book> booksReleasedAfter2005WithMoreThan500PAges;

            IEnumerable<Book> BooksReleasedAfter2005 = booksCollection.Where(x => x.publishedDate.Year >= 2005);
            IEnumerable<Book> BooksWithMoreThan500PAges = booksCollection.Where(x => x.pageCount > 500);

            //Se deberia comparar por ID, pero en este caso, el único dato único es el ID
            booksReleasedAfter2005WithMoreThan500PAges = BooksReleasedAfter2005.Join(BooksWithMoreThan500PAges, x => x.title, p => p.title, (x, p) => x);

            return booksReleasedAfter2005WithMoreThan500PAges;
        }

    }
}
