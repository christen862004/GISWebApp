using GISWebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GISWebApp.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }

    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort using buble sort alg.
        }
    }

    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort using buble sort alg.
        }

    }

    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            
        }
    }

    //DIP (high [MyList]==> abstract - interface)
    class MyList {
        int[] arr;
        ISort sortAlg=null; //default null (composition)

        public MyList(ISort sort)//ask | Inject at constructor level
        {
            sortAlg = sort;//not creae askin constr
            
        }
        public void SortList(ISort sort)//injection at method
        {
            sortAlg = sort;
            sortAlg.Sort(arr);
        }
    }
















    class Parent
    {   
        public virtual void Read()
        {

        }
    }

    class ReadOnlyPDF : Parent
    {
        //public override void Write()
        //{
        //    throw new Exception("asdasf");
        //}
    }



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
    //public class Parent<T>//open type
    //{
    //    public T id { get; set; }
    //}
    ////option1 (object boxing unbox | dynamic ) 
    //public class Child : Parent<int> 
    //{ }

    //public class Child2<T> : Parent<T>
    //{ }
    
    
    public class TestClass
    {
        public int Add(int x,int y)
        {
            ISort r = new BubbleSort();
            r = new SelectionSort();
            r = new ChrisSort();

            MyList list1 = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());//console app
            MyList list3 = new MyList(new ChrisSort());


            ReadOnlyPDF file = new ReadOnlyPDF();
            file.Read();
            //file.Write();
             

            MyController ctr=new MyController();
            //ctr.x;
            //ctr.Model = new Employee();
            //Child c = new Child();
            //Child2<string> c2 = new Child2<string>();

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
