using System;

namespace PostException
{
public class RuntimeException : ApplicationException
{
public RuntimeException(string message): base(message){ }
public RuntimeException(string message, Exception inner): base(message, inner){}
}
}
