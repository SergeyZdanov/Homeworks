using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusDelegate
{
    public class Files
    {
        public event EventHandler<FileArgs> FileFound;

        public List<long> size = new List<long>();

        public void FindFiles(string path) 
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();

            foreach (var file in files)
            {
                FileArgs args = new FileArgs(file.FullName);
                OnFileFound(args);

                if (args.Cancel)
                {
                    Console.WriteLine("Поиск файлов был отменён.");
                    break;
                }

                size.Add(file.Length);
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            if (FileFound != null)
            {
                foreach (EventHandler<FileArgs> handler in FileFound.GetInvocationList())
                {
                    handler.Invoke(this, e);

                    if (e.Cancel)
                        break;
                }
            }
        }
    }
}
