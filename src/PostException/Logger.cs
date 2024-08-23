using System;
using System.IO;

namespace PostException
{
public class Logger
{

public static void WriteLog(DataBaseException e)
{
Log(e.InnerException);
}

public static void WriteLog(RuntimeException e)
{
Log(e.InnerException);
}

static void Log(Exception e) {
try{
using (StreamWriter writer = new StreamWriter(
new FileStream("log.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
{
writer.WriteLine(string.Format("{0} | {1} | {2}", DateTime.Now,e.Source,e.Message));
writer.Flush();
writer.Close();
}
}catch(Exception ex){
throw new RuntimeException("No se pudo cargar el log",ex);
}
}
}
}
