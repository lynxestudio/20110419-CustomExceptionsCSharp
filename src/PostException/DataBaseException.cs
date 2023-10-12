using System;
using Npgsql;

namespace PostException
{
public class DataBaseException : ApplicationException
{
public DataBaseException(string message) : base(message) { }
public DataBaseException(string message, NpgsqlException inner):base(message,inner) { }
public DataBaseException(string message, Exception inner):base(message,inner) { }
}
}
