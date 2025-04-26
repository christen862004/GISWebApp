namespace GISWebApp.ViewModels
{
    public class EmpDepNAmeWithBrchTempMsgColorViewModel
    {
        //Hide Property + Hide Preoprty Name
        public int EmpID { get; set; }
        public string EmpName { get; set; }

        //Merger With another Model
        public string DeptName { get; set; }
        public List<string> Branches { get; set; }

        //Extra info
        public string Message { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
    }
}
