using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    delegate void print<T>(T t);
    public delegate int show();
    public class Program
    {
       public static void Main(string[] args)
        {

            //TestEnumber.TestStreamReaderEnumerable();
            //Console.WriteLine("-------");
            //TestEnumber.TestReadingFile();

            DelegateTest.Calculate(DelegateTest.Add, 5, 6);
            DelegateTest.Calculate(DelegateTest.Divide, 5, 6);
            DelegateTest.Calculate(DelegateTest.Subtract, 5, 6);
            DelegateTest.Calculate(DelegateTest.Multiply, 5, 6);

            Console.Read();



        }

        // private static void show<T>(T t) {
        //    PropertyInfo p = t.GetType().GetProperty("Student");
        //    Console.WriteLine("学生姓名：{0}学生编号：{1}", (string)p.GetValue("StudentName"), (string)p.GetValue("StudentCode"));
        //}

        public enum PeopleType { 
            p1,
            p2,
            p3,
            p4
        }
    }
   public class Student
    {
       public string StudentName { get; set; }
       public int StudentCode { get; set; }
       public int ClassCode { get; set; }
       public string ClassName { get; set; }
       public System.DateTime BirthDay { get; set; }
       public int Grade { get; set; }
       public Student(string studentName, int studentCode, int classCode, string className, System.DateTime birthDay) {
            this.StudentName = studentName;
            this.StudentCode = studentCode;
            this.ClassCode = classCode;
            this.ClassName = className;
            this.BirthDay = birthDay;
        }
    }
   public class Scode
    {
       public int StudentCode { get; set; }
       public int ScoreValue { get; set; }
       public string SubjectName { get; set; }
       public int Grade { get; set; }
        public Scode(int studentCode, int scoreValue, string subjectName) {
            this.StudentCode = studentCode;
            this.ScoreValue = scoreValue;
            this.SubjectName = subjectName;
        }
    }


}
