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
            //{
            //    List<Student> studentList = new List<Student>();
            //    List<Scode> studentScodeList = new List<Scode>();
            //    //print<Student> pr = show<Student>;

            //    studentList.Add(new Student("张三01", 110, 1001, "一年级", DateTime.Parse("2019/05/05")));
            //    studentList.Add(new Student("李三02", 112, 1001, "一年级", DateTime.Parse("2019/01/05")));
            //    studentList.Add(new Student("张三03", 113, 1001, "一年级", DateTime.Parse("2019/03/05")));
            //    studentList.Add(new Student("张三04", 114, 1001, "一年级", DateTime.Parse("2019/04/05")));
            //    studentList.Add(new Student("张三05", 115, 1002, "一年级", DateTime.Parse("2019/05/05")));
            //    studentList.Add(new Student("张三06", 116, 1005, "一年级", DateTime.Parse("2019/05/05")));
            //    studentList.Add(new Student("张三07", 117, 1004, "一年级", DateTime.Parse("2019/05/05")));
            //    studentList.Add(new Student("张三08", 118, 1002, "一年级", DateTime.Parse("2019/05/05")));
            //    studentList.Add(new Student("张三09", 1159, 1003, "一年级", DateTime.Parse("2019/05/05")));

            //    studentScodeList.Add(new Scode(110, 89, "语文"));
            //    studentScodeList.Add(new Scode(112, 50, "语文"));
            //    studentScodeList.Add(new Scode(113, 60, "语文"));
            //    studentScodeList.Add(new Scode(114, 89, "语文"));
            //    studentScodeList.Add(new Scode(110, 89, "数学"));
            //    studentScodeList.Add(new Scode(118, 89, "语文"));
            //    studentScodeList.Add(new Scode(119, 89, "语文"));


            //    var student1001 = studentList.Where(s => s.ClassCode == 1001);
            //    var listOrderBy = studentList.Where(s => s.ClassCode == 1001).OrderBy(t => t.BirthDay);
            //    var listStartWith = studentList.Where(s => (s.ClassCode == 1001) && (s.StudentName.StartsWith("李"))).OrderByDescending(t => t.BirthDay);
            //    var listScore = studentList.Where(s => (s.ClassCode == 1001) && (studentScodeList.Exists(p => (p.ScoreValue > 0 && p.ScoreValue < 90) && p.StudentCode == s.StudentCode)));
            //    //foreach (Student stu in student1001) {
            //    //    Console.WriteLine("学生姓名：{0}学生编号：{1}", stu.StudentName, stu.StudentCode);
            //    //    //pr(stu);
            //    //}
            //    //foreach (Student stu in listOrderBy) {
            //    //    Console.WriteLine("学生姓名：{0}学生编号：{1}", stu.StudentName, stu.StudentCode);
            //    //    //pr(stu);
            //    //}
            //    //foreach (Student stu in listStartWith) {
            //    //    Console.WriteLine("学生姓名：{0}学生编号：{1}", stu.StudentName, stu.StudentCode);
            //    //    //pr(stu);
            //    //}
            //    PeopleType pt;
            //    switch (pt)
            //    {
            //        case PeopleType.p1:
            //            break;
            //        case PeopleType.p2:
            //            break;
            //        case PeopleType.p3:
            //            break;
            //        case PeopleType.p4:
            //            break;
            //        default:
            //            break;
            //    }
            //    foreach (Student sc in listScore)
            //    {
            //        Console.WriteLine("学生姓名：{0}学生编号：{1}", sc.StudentName, sc.StudentCode);
            //        //pr(stu);
            //    }
            //}

            TestEnumber.TestStreamReaderEnumerable();
            Console.WriteLine("-------");
            TestEnumber.TestReadingFile();

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
