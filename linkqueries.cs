
public class LinkQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinkQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        // extension method
        //return librosCollection.Where(p=> p.publishedDate.Year > 2000);

        //query expresion
        return from l in librosCollection  where l.publishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> Libros250pgyAction(){
        //extension method
        //return librosCollection.Where(p=> p.pageCount > 250 && p.title.Contains("in Action"));
    
        //query expresion
        return from l in librosCollection where l.pageCount > 250 && l.title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus(){
        return librosCollection.All(p=> p.status != string.Empty);
    }

    public bool LibrosPublicados2005(){
        return librosCollection.Any(p=> p.publishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosPython(){
        return librosCollection.Where(p=> p.categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosJavaAsc(){
        return librosCollection.Where(p=> p.categories.Contains("Java")).OrderBy(p=> p.title);
    }

    public IEnumerable<Book> LibrosJavaDesc(){
        return librosCollection.Where(p=> p.pageCount > 450).OrderByDescending(p=> p.pageCount);
    }

    public IEnumerable<Book> LibrosMasRecientes()
    {
        return librosCollection
        .Where(p=> p.categories.Contains("Java"))
        .OrderByDescending(p=> p.publishedDate)
        .Take(3);
    }

    public IEnumerable<Book> LibrosMasPaginas()
    {
        return librosCollection
        .Where(p=> p.pageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> TresPrimerLibrosdelaColeccion()
    {
        return librosCollection.Take(3)
        .Select(p=> new Book() {title = p.title, pageCount = p.pageCount});
    }

    public int CantidadLibros()
    {
        return librosCollection
        .Where(p=>p.pageCount >=200 && p.pageCount<=500).Count();
    }

    public DateTime MenorPublicacion()
    {
        return librosCollection
        .Min(p=> p.publishedDate);
    }

    public Book? MenpgMay0()
    {
        return librosCollection
        .Where(p=>p.pageCount > 0)
        .MinBy(p=>p.pageCount);

    }

    public int SumaDePagLb()
    {
        return librosCollection
        .Where(p=>p.pageCount >=0 && p.pageCount <=500).Sum(p=>p.pageCount);
    }

    public string LibrosDpCont()
    {
        return librosCollection
        .Where(p=>p.publishedDate.Year > 2015)
        .Aggregate("", (Titulos, next) =>
        {
            if(Titulos != string.Empty)
            {
                Titulos += " - " + next.title;
            }
            else
            {
                Titulos += next.title;
            }

            return Titulos;
        });
    }

    public double Promedio()
    {
        return librosCollection.Average(p=>p.title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LiborsDp2000Ag()
    {
        return librosCollection
        .Where(p=>p.publishedDate.Year >= 2000).GroupBy(p=>p.publishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeDatos(){
        return librosCollection.ToLookup(p=> p.title[0], p=> p);
    }

    public IEnumerable<Book> liborsdespuesdel2050(){
        var libros2005 = librosCollection.Where(p=>p.publishedDate.Year > 2005);

        var librosmas400 = librosCollection.Where(p=>p.pageCount >500);

        return libros2005.Join(librosmas400, p=>p.title, x=>x.title, (p,x)=> p);
    }
}