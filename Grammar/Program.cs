using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            DelegateTest.ShowResult showResult = DelegateTest.Add;

            DelegateTest.Calculate(showResult, 5, 6);
            DelegateTest.Calculate(DelegateTest.Divide, 5, 6);
            DelegateTest.Calculate(DelegateTest.Subtract, 5, 6);
            DelegateTest.Calculate(DelegateTest.Multiply, 5, 6);

            //i*j+w*x
            //ParameterExpression a = Expression.Parameter(typeof(int), "i");   //创建一个表达式树中的参数，作为一个节点，这里是最下层的节点
            //ParameterExpression b = Expression.Parameter(typeof(int), "j");
            //BinaryExpression r1 = Expression.Multiply(a, b);    //这里i*j,生成表达式树中的一个节点，比上面节点高一级

            //ParameterExpression c = Expression.Parameter(typeof(int), "w");
            //ParameterExpression d = Expression.Parameter(typeof(int), "x");
            //BinaryExpression r2 = Expression.Multiply(c, d);

            //BinaryExpression result = Expression.Add(r1, r2);   //运算两个中级节点，产生终结点

            //Expression<Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(result, a, b, c, d);

            //Console.WriteLine(lambda + "");   //输出‘(i,j,w,x)=>((i*j)+(w*x))’，z对应参数b，p对应参数a

            //Func<int, int, int, int, int> f = lambda.Compile();  //将表达式树描述的lambda表达式，编译为可执行代码，并生成该lambda表达式的委托；

            //Console.WriteLine(f(1, 1, 1, 1) + "");  //输出结果2
            Console.ReadKey();














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
