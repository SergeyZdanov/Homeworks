namespace OtusDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 22 }
            };
            var res = people.GetMax<Person>(Converter);
            Console.WriteLine(" ------------------ Задание с обобщенной функцией ------------------");

            Console.WriteLine("Максимальное число: " + Converter(res));


            Console.WriteLine(" ------------------ Задание с файлами ------------------");

            Files files = new Files();

            Sub sub1 = new Sub("Jon1");
            Sub sub2 = new Sub("Jon2");
            Sub sub3 = new Sub("Jon3");

            files.FileFound += sub1.Print;
            files.FileFound += sub2.Print;
            files.FileFound += sub3.Print;

            files.FindFiles("C:\\Users\\serg1\\Desktop\\Homeworks\\Otus17\\Files");

        }

        private static float Converter<T>(T value) 
        {
            var type = value.GetType();
            var prop = type.GetProperty("Age");
            var number = prop.GetValue(value);

            bool res = float.TryParse(number.ToString(), out var num);

            if (res)
                return num;

            Console.WriteLine("Данный объект невозможно перевести в число");
            return 0;
        }
    }
}
