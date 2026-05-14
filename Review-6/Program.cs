using System;
using System.IO;
using System.Text.Json;

namespace FileProcessingSystem
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public sealed class FileManager
    {
        private static readonly FileManager instance =
            new FileManager();

        private FileManager()
        {
        }

        public static FileManager GetInstance()
        {
            return instance;
        }

        public StreamWriter GetWriter(string path)
        {  
            FileStream fs =
                new FileStream(path, FileMode.OpenOrCreate);

            return new StreamWriter(fs);
        }
    }

    public interface IFileReader
    {
        void ReadFile(string path);
    }

    public interface IFileWriter
    {
        void WriteFile(string path, Student student);
    }

    public class CsvReader : IFileReader
    {
        public void ReadFile(string path)
        {
            StreamReader reader =
                new StreamReader(path);

            string data = reader.ReadToEnd();

            Console.WriteLine("CSV FILE CONTENT");
            Console.WriteLine(data);

            reader.Close();
        }
    }

    public class CsvWriter : IFileWriter
    {
        public void WriteFile(string path, Student student)
        {
            StreamWriter writer =
                FileManager.GetInstance().GetWriter(path);

            writer.WriteLine("Id,Name");
            writer.WriteLine(student.Id + "," + student.Name);

            writer.Close();
        }
    }

    public class JsonReader : IFileReader
    {
        public void ReadFile(string path)
        {
            string jsonData =
                File.ReadAllText(path);

            Student student =
                JsonSerializer.Deserialize<Student>(jsonData);

            Console.WriteLine("JSON FILE CONTENT");
            Console.WriteLine("Id : " + student.Id);
            Console.WriteLine("Name : " + student.Name);
        }
    }

    public class JsonWriter : IFileWriter
    {
        public void WriteFile(string path, Student student)
        {
            string jsonData =
                JsonSerializer.Serialize(student);

            StreamWriter writer =
                FileManager.GetInstance().GetWriter(path);

            writer.WriteLine(jsonData);

            writer.Close();
        }
    }

    public interface IFileFactory
    {
        IFileReader CreateReader();

        IFileWriter CreateWriter();
    }

    public class CsvFactory : IFileFactory
    {
        public IFileReader CreateReader()
        {
            return new CsvReader();
        }

        public IFileWriter CreateWriter()
        {
            return new CsvWriter();
        }
    }

    public class JsonFactory : IFileFactory
    {
        public IFileReader CreateReader()
        {
            return new JsonReader();
        }

        public IFileWriter CreateWriter()
        {
            return new JsonWriter();
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.Id = 1;
            student.Name = "Adarsh";

         
            IFileFactory csvFactory =
                new CsvFactory();

            IFileWriter csvWriter =
                csvFactory.CreateWriter();

            csvWriter.WriteFile("student.csv", student);

            IFileReader csvReader =
                csvFactory.CreateReader();

            csvReader.ReadFile("student.csv");

            Console.WriteLine();
            IFileFactory jsonFactory =
                new JsonFactory();

            IFileWriter jsonWriter =
                jsonFactory.CreateWriter();

            jsonWriter.WriteFile("student.json", student);

            IFileReader jsonReader =
                jsonFactory.CreateReader();

            jsonReader.ReadFile("student.json");
        }
    }
}