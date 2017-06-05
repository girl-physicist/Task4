using System;
using DatabaseHandler;


namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientServer cs = new ClientServer();
           //Recorder recorder=new Recorder();
            //recorder.SaveRecords("Ivanov_19112012.csv");
          
            cs.OnStart();
            cs.OnStop();
            Console.Read();
        }
    }
}
