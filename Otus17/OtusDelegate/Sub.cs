using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusDelegate
{
    internal class Sub
    {
        public string Name;
        public string StopFile = "";

        public Sub(string name)
        {
            Console.WriteLine("Укажите стоп файл вписан его имя");
            StopFile = Console.ReadLine();

            this.Name = name;
        }

        public void Print(object sender, FileArgs e)
        {
            Console.WriteLine($"Для меня {Name} найден новый файл: {e.FileName}!");

            if (e.FileName.Contains(StopFile))
            {
                e.Cancel = true;
            }
        }
    }
}
