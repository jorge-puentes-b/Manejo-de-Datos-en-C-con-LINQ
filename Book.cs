public class Book{
    public string title{get;set;} = string.Empty;
    public int pageCount{get;set;}
    public string status{get;set;} = string.Empty;
    public DateTime publishedDate{get;set;}
    public string[] authors {get;set;} = Array.Empty<string>();
    public string[] categories {get;set;} = Array.Empty<string>();

}

