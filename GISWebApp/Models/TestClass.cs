using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GISWebApp.Models
{
    public class TestClass
    {
        public int Add(int x,int y)
        {
            //View Model
            
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
