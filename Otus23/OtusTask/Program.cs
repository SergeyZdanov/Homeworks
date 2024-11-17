
using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();
StreamReader sr = new StreamReader("C:\\Users\\serg1\\Desktop\\Homeworks\\Otus23\\Files\\1.txt");

Task task = new Task(() =>
{
    string line = sr.ReadToEnd();
    Console.WriteLine(line.Split(" ").Length-1);
});


StreamReader sr2 = new StreamReader("C:\\Users\\serg1\\Desktop\\Homeworks\\Otus23\\Files\\2.txt");
Task task2 = new Task(() =>
{
    string line = sr2.ReadToEnd();
    Console.WriteLine(line.Split(" ").Length-1);
});


StreamReader sr3 = new StreamReader("C:\\Users\\serg1\\Desktop\\Homeworks\\Otus23\\Files\\3.txt");
Task task3 = new Task(() =>
{
    string line = sr3.ReadToEnd();
    Console.WriteLine(line.Split(" ").Length - 1);
});
task.Start();

task2.Start();

task3.Start();

task.Wait();
task2.Wait();
task3.Wait();

sr.Close();
sr2.Close();
sr3.Close();

stopwatch.Stop();
Console.WriteLine("Время выполнения первого задания: " + stopwatch.ElapsedMilliseconds);

stopwatch.Restart();

stopwatch.Start();

Console.WriteLine(ReadlAllFilesForFolder("C:\\Users\\serg1\\Desktop\\Homeworks\\Otus23\\Files"));

stopwatch.Stop();

Console.WriteLine("Время выполнения второго задания: " + stopwatch.ElapsedMilliseconds);
int ReadlAllFilesForFolder(string path)
{
    var files = Directory.GetFiles(path);
    string result = "";

    Task task = new Task(() => {
        foreach (var file in files)
        {
            result += File.ReadAllText(file);
        }
    });

    task.Start();
    task.Wait();
    return result.Split(" ").Length-1;
}