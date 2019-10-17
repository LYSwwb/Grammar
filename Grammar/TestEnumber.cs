using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;

namespace Grammar
{
    public class TestEnumber
    {
        public static void TestStreamReaderEnumerable() {
            long memoryBefore = GC.GetTotalMemory(true);
            IEnumerable<String> stringsFound;
            try
            {
                stringsFound = from line in new StreamReaderEnumerable(@"F:\NET\temptempFile.txt")
                               where line.Contains("string to search for")
                               select line;
                Console.WriteLine("Found:" + stringsFound.Count());
            }
            catch (FileNotFoundException) {
                Console.WriteLine(@"This example requires a file named F:\NET\temptempFile.txt.");
                return;
            }

            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Memory Used With Iterator = \t"
                                + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

        public static void TestReadingFile() {
            long memoryBefore = GC.GetTotalMemory(true);
            StreamReader sr;
            try
            {
                sr = new StreamReader(@"F:\NET\temptempFile.txt");
            }
            catch (FileNotFoundException) {
                Console.WriteLine(@"This example requires a file named F:\NET\temptempFile.txt.");
                return;
            }

            List<string> fileContents = new List<string>();
            while (!sr.EndOfStream) {
                fileContents.Add(sr.ReadLine());
            }

            var stringsFound = from line in fileContents
                               where line.Contains("string to search for")
                               select line;

            sr.Close();

            Console.WriteLine("Found:" + stringsFound.Count());

            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Memory Used Without Iterator = \t"
                                + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

    }
    public class StreamReaderEnumerable : IEnumerable<string>
    {
        private string _filePath;
        public StreamReaderEnumerable(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StreamReaderEnumerator(_filePath);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
    }

    public class StreamReaderEnumerator : IEnumerator<string>
    {
        private StreamReader _sr;
        public StreamReaderEnumerator(string filePath)
        {
            _sr = new StreamReader(filePath);
        }
        private string _current;

        public string Current
        {
            get
            {
                if (_sr == null || _current == null)
                {
                    throw new InvalidOperationException();
                }
                return _current;
            }
        }

        private object Current1
        {
            get { return this.Current; }
        }

        object IEnumerator.Current
        {
            get { return Current1; }
        }
        //Implement MoveNext and Reset, which ara required by IEnumerator.
        public bool MoveNext()
        {
            _current = _sr.ReadLine();
            if (_current == null)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _sr.DiscardBufferedData();
            _sr.BaseStream.Seek(0, SeekOrigin.Begin);
            _current = null;
        }
        //Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    //Dispose of managed resoures.
                }
                _current = null;
                if (_sr != null)
                {
                    _sr.Close();
                    _sr.Dispose();
                }
            }
            this.disposedValue = true;
        }
        ~StreamReaderEnumerator()
        {
            Dispose(false);
        }
    }
}
