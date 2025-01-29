namespace Labb2SchoolDB;

class Program
{
    static void Main(string[] args)
    {

        DBAction dbAction = new DBAction();
        //dbAction.ShowStudents();
        Dictionary<string,Action> actionMap = new Dictionary<string,Action>
        {
            {"Add student", dbAction.AddStudent},
            {"Show students", dbAction.ShowStudents},
            {"Show class", dbAction.ShowClass}
        };
        while(true)
        {
                string choice = dbAction.Menu(actionMap.Keys.ToArray<String>());
                actionMap[choice].DynamicInvoke();  

        }
    }
}
