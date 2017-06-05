using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherService.DataBase;

namespace FileWatcherService
{
    class Parser
    {
        public IEnumerable<SaleInfo> ParseData(string path)
        {
            string[] param;//Ivanov_19112012.csv
            var managerName = Path.GetFileName(path).Split('_').First();
            IList<SaleInfo> records = new List<SaleInfo>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        param = sr.ReadLine().Split(',');//Дата,Клиент,Товар,Сумма
                        records.Add(new SaleInfo(managerName, param[0], param[1], param[2], param[3]));
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return records;
        }
    }
}


