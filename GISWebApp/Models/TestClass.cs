using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GISWebApp.Models
{
    class MyController
    {
        int x;
        public object Model { get; set; }

        public int X
        {
            get { return x; }
            set { x = value; }
        } //

        public dynamic X2
        {
            get { return x; }
            set { x = value; }
        }
    }




    //design class == >cant dentermine type
    public class Parent<T>//open type
    {
        public T id { get; set; }
    }
    //option1 (object boxing unbox | dynamic ) 
    public class Child : Parent<int> 
    { }

    public class Child2<T> : Parent<T>
    { }
    
    
    public class TestClass
    {
        public int Add(int x,int y)
        {
            MyController ctr=new MyController();
            //ctr.x;
            ctr.Model = new Employee();
            Child c = new Child();
            Child2<string> c2 = new Child2<string>();

            //dynamic C# 8
            dynamic d = 10;//dont know type - determine at runtime
            dynamic s = "ahmed";
            dynamic obj = new Trainee();
            int no = s.name;//pass comile time , throw exception runtime
            

            //object o = 10;//boxing
            //int no =int.Parse(o.ToString());//unboxing

            return x + y;
        }

        public void Calc()
        {
            //action Tlist
            int a = 10;
            int b = 20;
            int z = Add(a, b);
        }
    }
}
