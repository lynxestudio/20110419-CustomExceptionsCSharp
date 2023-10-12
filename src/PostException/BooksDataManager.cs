using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Configuration;

namespace PostException 
{
public static class BooksDataManager 
{
static string connStr = null;
static List<Book> books = null;

public static List<Book> SelectAll() {
try {
    connStr = ConfigurationManager.ConnectionStrings["curry"].ConnectionString;
    books = new List<Book>();
    string CommandText = "SELECT title,pubyear,numpages,authors FROM books";
    using (NpgsqlConnection conn = new NpgsqlConnection(connStr)) {
    conn.Open();
    using (NpgsqlCommand cmd = new NpgsqlCommand(CommandText, conn)) {
    using (NpgsqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
    while (reader.Read()) {
    books.Add(new Book {
    Title = reader["title"].ToString(),
    PubYear = Convert.ToInt32(reader["pubyear"]),
    NumPages = Convert.ToInt32(reader["numpages"]),
    Authors = reader["authors"].ToString()
});
}
}
}
}
return books;
}
catch (NpgsqlException ex) {
var dbex = new DataBaseException("Error en base de datos", ex);
Logger.WriteLog(dbex);
throw dbex;
}
catch (Exception ex) {
var rex = new RuntimeException("Error grave consulte al administrador", ex);
Logger.WriteLog(rex);
throw rex;
}
}
}
}