using System;

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
            Console.WriteLine(showResult(a, b));
        }
    }
}
