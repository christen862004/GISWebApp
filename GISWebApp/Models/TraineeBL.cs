namespace GISWebApp.Models
{
    public class TraineeBL
    {
        //declae local list 
        List<Trainee> TraineeList;
       
        public TraineeBL()
        {
               TraineeList = new() {
                    new(){Id=1,Name="Ahmed",Email="Ahmed@gmail.com",ImageUrl="m.png"},
                    new(){Id=2,Name="Eman",Email="Eman@gmail.com",ImageUrl="2.jpg"},
                    new(){Id=3,Name="Mostafa",Email="Mostafa@gmail.com",ImageUrl="m.png"},
                    new(){Id=4,Name="Rehab",Email="Rehab@gmail.com",ImageUrl="2.jpg"},
                    new(){Id=5,Name="Mohamed",Email="Model@gmail.com",ImageUrl="m.png"},
               };
        }
       
        public List<Trainee> GetAll()
        {
            return TraineeList;
        }

        public Trainee GetByID(int id)//3
        {
            //Linq
            return TraineeList.FirstOrDefault( t => t.Id == id);
        }

        public Trainee GetByName(string name)
        {
            return TraineeList.FirstOrDefault(t => t.Name.Contains(name));
        }
    }
}
