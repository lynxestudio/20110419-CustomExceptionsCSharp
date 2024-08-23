using System;

namespace PostException
{
class Program
{
static void Main(string[] args)
{
Console.WriteLine("Obteniendo la lista de libros");
try {
foreach (Book b in BooksDataManager.SelectAll()) {
Console.WriteLine("{0}",b.Title);
Console.WriteLine("{0}",b.Authors);
Console.WriteLine("{0}",b.NumPages);
Console.WriteLine("{0}",b.PubYear);
Console.WriteLine("+-----------------------------------------+");

}
}
catch (DataBaseException dbex)
{
Console.WriteLine(dbex.Message);
}
catch (RuntimeException ex)
{
Console.WriteLine(ex.Message);
}
}
}
}
