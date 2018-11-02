

using System;
using System.Text;
/**
* @(#) LoggerLazy.cs
*/
namespace GameServer
{
	public class LoggerLazy
	{
		public static LoggerLazy getInstance(  )
		{
            return LoggerHolder.instance;
		}
		
		public void log( string tag, string message )
		{
            Console.WriteLine(new StringBuilder("TAG:: ").Append(tag).Append("Message: ").Append(message).ToString());
		}
		
	}
	
}
