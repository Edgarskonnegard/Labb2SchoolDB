using Labb2SchoolDB.Models;

class DBAction
{   
    //Lägg till ny elev
    public void AddStudent()
    {
        Console.Clear();
        System.Console.WriteLine("Add student.");
        System.Console.Write("Enter firstname: ");
        string firstName = Console.ReadLine();
        System.Console.Write("Enter firstname: ");
        string lastName = Console.ReadLine();
        System.Console.Write("Enter ssn: ");
        string ssn = Console.ReadLine();
        System.Console.Write("Enter class id: ");
        int classId = Convert.ToInt32(Console.ReadLine());

        using(var context = new SchoolContext())
        {
            if(context.Classes.FirstOrDefault(c => c.ClassId == classId) != default 
            && ssn.All(char.IsDigit) && ssn.Length == 10)
            {
                var newStudent = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Ssn = ssn,
                    ClassId = classId

                };
                context.Students.Add(newStudent);
                System.Console.WriteLine("New student added.");
                //context.SaveChanges();
                Console.ReadKey(intercept: true);
            }
            else{
                System.Console.WriteLine("Invalid input error.");
                Console.ReadKey(intercept: true);
            }
        }
    }
    // Visa alla elever i en klass
    public void ShowClass()
    {
        using(var context = new SchoolContext())
        {
            var classes = context.Classes.AsQueryable();
            List<string> classNames = new List<string>();
            if(classes != null)
            {
                foreach(var c in classes)
                {
                    classNames.Add(c.ClassName);
                }
                string classToShow = Menu(classNames.ToArray<string>());
                var students = context.Students.Where(s => s.ClassId == classNames.ToList().IndexOf(classToShow)+1).ToList();
                //int classID = classes.;
                string[] menuItems = {"Order by Firstname", "Order by Lastname"};
                string choice = Menu(menuItems);
                students = choice == menuItems[0] ? students.OrderBy(s => s.FirstName).ToList() : students.OrderBy(s => s.LastName).ToList();
                Console.Clear();
                System.Console.WriteLine($"Students in class {classToShow}");
                System.Console.WriteLine(new string('-',10));
                foreach(var s in students)
                {
                    System.Console.WriteLine($"{s.FirstName} {s.LastName}");
                }
                System.Console.WriteLine();
                Console.ReadKey(intercept: true);
            }
            else{
                System.Console.WriteLine("There are no classes in the database.");
            }
            
        }
    }


    //visa alla elever
    public void ShowStudents()
    {
        string[] menuItems = {"Order by Firstname", "Order by Lastname"};
        string choice = Menu(menuItems);
        using(var context = new SchoolContext())
        {
            var students = context.Students.AsQueryable();
            if(students != null)
            {
                students = choice == menuItems[0] ? students.OrderBy(s => s.FirstName) : students.OrderBy(s => s.LastName);
                Console.Clear();
                System.Console.WriteLine("Students");
                System.Console.WriteLine(new string('-',10));
                foreach(var s in students)
                {
                    System.Console.WriteLine($"{s.FirstName} {s.LastName}");
                }
                System.Console.WriteLine();
                Console.ReadKey(intercept: true);
            }
            else{
                System.Console.WriteLine("There are no students in the database.");
            }
        }
    }

    public string Menu(string[] menuItems)
    {
        ConsoleKey key;
        int currentSelection = 0;
        do
        {
            Console.Clear();
            System.Console.WriteLine("Choose method to display data.");
            for(int i = 0; i < menuItems.Length; i++)
            {
                System.Console.WriteLine(i == currentSelection ? ">" + menuItems[i] : " " + menuItems[i]);
            }
            key = Console.ReadKey(intercept: true).Key;
            if(key == ConsoleKey.Tab)
            {
                currentSelection = currentSelection == menuItems.Length -1 ? 0 : currentSelection +1;
            }
        }while(key != ConsoleKey.Enter);
        return menuItems[currentSelection];
    }

}