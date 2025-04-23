using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GISWebApp.Models
{
    //design class == >cant dentermine type
    public class class1<T>//open type
    {
        public T id { get; set; }
    }


    public class TestClass
    {
        public int Add(int x,int y)
        {
            //View Model
            class1<int> obj=new() { id=1};
            
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
