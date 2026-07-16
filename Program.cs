
LinkQueries queries = new LinkQueries();
//toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//libros >250pg in Action
//ImprimirValores(queries.Libros250pgyAction());

//status
//Console.WriteLine($"todos los libros tienen status:? - {queries.TodosLosLibrosTienenStatus()}");

//libros publicados en 2005
//Console.WriteLine($"libros 2005:? - {queries.LibrosPublicados2005()}");

//libros Pythno
//ImprimirValores(queries.LibrosPython());

//libros JavaASC
//ImprimirValores(queries.LibrosJavaAsc());

//libros Java DESC
//ImprimirValores(queries.LibrosJavaDesc());

// 3 libros fecha plublicacion mas recinete
//ImprimirValores(queries.LibrosMasRecientes());

//libro mas de 400 paginas
//ImprimirValores(queries.LibrosMasPaginas());

//seleccion dinamica de datos
//ImprimirValores(queries.TresPrimerLibrosdelaColeccion());

//Cantidad de libros
//Console.WriteLine($"cantidad de libros es de: {queries.CantidadLibros()}");

//Menor fecha de publicacion
//Console.WriteLine($"La menor fecha es: {queries.MenorPublicacion()}  ");

//Menor pag May a 0
//ar libroMenorPag = queries.MenpgMay0();
//Console.WriteLine($"{libroMenorPag.title} - {libroMenorPag.pageCount}");

//suma de paginas
//Console.WriteLine($"suma: {queries.SumaDePagLb()} ");

//libros publicados despues del 2015
//Console.WriteLine(queries.LibrosDpCont());

//Promedio
//Console.WriteLine($"promedio: {queries.Promedio()}");

// libors despues del 2000
//ImprimirGrupo(queries.LiborsDp2000Ag());

//ImprimirDiccionario de libors agrupados por primera letradel titulo 
//var dictionaryLookup = queries.DiccionarioDeDatos();
//ImprimirDiccionario(dictionaryLookup, 'A');

//Libros filtrados con la clausula join 
ImprimirValores(queries.liborsdespuesdel2050());

void ImprimirDiccionario(ILookup<char, Book> bookList, char letter)
{
	Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
	foreach (var item in bookList[letter])
	{
        	Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.title,item.pageCount,item.publishedDate.Date.ToShortDateString()); 
	}

}

void ImprimirValores (IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion"); 
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.title, item.pageCount, item.publishedDate.ToShortDateString());
    }
}
                

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.title,item.pageCount,item.publishedDate.Date.ToShortDateString()); 
        }
    }
}