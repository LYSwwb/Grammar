using System;
using System.Reflection;

namespace Grammar
{
    /*
     * 委托的使用
     * 
     * 委托定义：
     *     委托是一个引用类型，表示对具体特定参数列表和返回类型的方法的引用，在实例化委托时，可以其实例与任何具有兼容签名和返回类型的方法相关联；
     *     是安全封装方法的类型，类似于C和C++中的函数指针。这是来自微软官方的定义。再来看一下国内一些网站的定义：委托是一个类，它定义了方法的类型，
     *     使得可以将方法当作另一个方法的参数来进行传递，这种将方法动态地赋给参数的做法，可以避免在程序中大量使用if-else/switch 语句，同时使得程序
     *     具有更好的可扩展性。通过上面的定义一些基础不好的同学是不是，仍然不知道是用来干嘛，先别急咱们一点一点的来聊。    
     * 首先 通过定义咱们知道了一个很重要的信息：委托是一个类型、是类。既然委托是一个类，那么委托是不是也应该具有类的特性。
     * 咱们来看一下定义一个委托的方法：delegagte void Evenhandler();
     *     看到是不是有些小伙伴会问，“委托不是一个类吗？为什么在定义的时候这么一句就完了呢？”
     *     咱们来看一个实例，通过反编译工具咱们看一下，委托通过编译之后长什么样子
     *     在图中咱们是不是可以清楚的看到，委托真是一个类，它继承自System.Object；并且它还有自己的方法：Invoke();BeginInvoke();EndInvoke();
     *     那么要怎么使用呢？咱们通过一个实例来看一下：
     *     
     *     
     *     
     *   在图中咱们是不是可以清楚的看到，委托真的是一个类，继承自System.Object；并且它还有自己的方法：Invoke();BeginInvoke();EndInvoke();
    *那么怎么使用委托呢？看下面的例子：
    *        public delegate void ShowResult(int a,int b);
    *        static void Main(string[] args)
    *        {
    *            ShowResult showResult = Add;
    *            //ShowResult showResult = New ShowResult(Add);
    *            DelegateTest.Calculate(showResult , 5, 6);
    *            
    *            
    *            Console.Read();
    *        }
    *
    *        public static void Add(int a, int b) {
    *            Console.WriteLine(a + b);
    *        }
    *
    *        public static void Divide(int a, int b) {
    *            Console.WriteLine(a / b);
    *        }
    *        public static void Subtract(int a, int b) {
    *            Console.WriteLine(a - b);
    *        }
    *        public static void Multiply(int a, int b) {
    *            Console.WriteLine(a * b);
    *        }
    *
    * 看了上面的例子是不是感觉委托没有什么用，我么直接调用相应的方法不就行了吗？为什么还要绕个远路呢？
    * 我们来看一下上面的实例，实例的目的是输出两个数的加、减、乘、除，这四个方法目前有一个共性的操作就是需要计算的结果进行输出。这仅仅是目前的需求，但是为了不挖坑，对传进去的参数是不是需要检测。
    * 现在针对现在的程序添加一些规则：1：a、b都要是正整数；2：对每次操作都要写入日志。
    * 考虑一下，添加这些规则，咱们是不是需要怎么修改代码。
    *         public delegate int ShowResult(int a,int b);
    *         
    *         static void Main(string[] args)
    *         {
    *             ShowResult showResult = Add;
    *             //ShowResult showResult = New ShowResult(Add);
    *             DelegateTest.Calculate(showResult , 5, 6);
    *             Console.Read();
    *         }
    *         
    *         
    *         public static int Add(int a, int b) {
    *             return a + b;
    *         }
    *         public static int Divide(int a, int b) {
    *             return a / b;
    *         }
    *         public static int Subtract(int a, int b) {
    *             return a - b;
    *         }
    *         public static int Multiply(int a, int b) {
    *             return a * b;
    *         }
    * 
    *         public static void Calculate(ShowResult showResult, int a, int b) {
    *             if(a < 0 || b < 0){
    *                 Console.WriteLine("参数有误");
    *             }else{     
    *                 System.Reflection.MethodInfo methodInfo = RuntimeReflectionExtensions.GetMethodInfo(showResult);
    *                 Console.WriteLine("在这里写入一条日志" + methodInfo.ToString());
    *                 Console.WriteLine(showResult(a, b));
    *                 //Console.WriteLine(showResult?.Invoke(a, b)); ?.  null检查 C#6.0以上版本
    *             }
    *         }
    * 
    * 向上面提取出所有相同的代码，放到一个方法中，把不相同的部分，定义成响应的方法。不论以后需要怎么改需求只需要更改Calcute 方法就行了，这样写代码的灵活性是不是更高，可扩展性是不是有了提升。
    * 协变：
    * 
    * 逆变：
    * 
    * 
    * 下面介绍一下C#定义好的委托：
    * 1、Action<T> delegate  封装一个方法，该方法没有返回值。其中可以有0~16个参数。
    * pubilc delegate void Action<in T>(T obj); // T 泛型
    * 
    * 2、Func<T, TResult> delegate 封装一个带有0~16个参数，且返回TResult类型的方法
    * public delegate TResult Func<out TResult>();  
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     *     
     * 
    */
    public class DelegateTest
    {
        public delegate int ShowResult(int a,int b);
        public static int Add(int a, int b) {
            return a + b;
        }
        public static int Divide(int a, int b) {
            return a / b;
        }
        public static int Subtract(int a, int b) {
            return a - b;
        }
        public static int Multiply(int a, int b) {
            return a * b;
        }

        public static void Calculate(ShowResult showResult, int a, int b) {
            if (a < 0 || b < 0)
            {
                Console.WriteLine("参数有误");
            }
            else
            {
                System.Reflection.MethodInfo methodInfo = RuntimeReflectionExtensions.GetMethodInfo(showResult);
                Console.WriteLine("在这里写入一条日志" + methodInfo.ToString());

                Console.WriteLine(showResult?.Invoke(a, b));
                //Console.WriteLine(showResult(a, b));
            }
        }

    }
}
