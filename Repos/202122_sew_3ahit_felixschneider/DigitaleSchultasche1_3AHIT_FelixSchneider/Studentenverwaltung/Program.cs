using System;
using System.IO;
using libstudents;

namespace Studentenverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Directory.SetCurrentDirectory(@"C:\Users");
            Studentmanager sm = new Studentmanager();
            Console.WriteLine("Microsoft Windows [Version 10.0.19043.1237]\n(c) Microsoft Corporation. Alle Rechte vorbehalten.");

            while (true)
            {
                Console.WriteLine();
                Console.Write($"{Directory.GetCurrentDirectory()} $ ");
                ChangeFColor(ConsoleColor.Yellow);
                string command = Console.ReadLine().ToLower();
                string[] commands = command.Split(" ");
                ChangeFColor(ConsoleColor.White);
                switch (commands[0])
                {
                    case "info": 
                    case "help": HelpCommand(commands); break;
                    case "hints": 
                    case "hint": 
                    case "tips": 
                    case "tip": TipCommand(); break;
                    case "cd": CdCommand(commands); break;
                    case "pwd": PwdCommand(); break;
                    case "ls": LsCommand(); break;
                    case "creat": 
                    case "new": NewCommand(sm); break;
                    case "rm": 
                    case "delete": RmCommand(commands, sm); break;
                    case "change": 
                    case "edit": EditCommand(commands, sm); break;
                    case "show": ShowCommand(sm); break;
                    case "sort": SortCommand(commands, sm); break;
                    case "save": SaveCommand(commands, sm); break;
                    case "load": LoadCommand(commands, sm); break;
                    case "close": 
                    case "exit": return;
                    default: Console.WriteLine("Bash command not found!"); break;
                }
            }
        }

        public static void HelpCommand(string[] commands)
        {
            if(commands.Length == 2)
            {
                try
                {
                    switch (commands[1])
                    {
                        case "hints":
                        case "hint":
                        case "tips":
                        case "tip": Console.WriteLine("'tips': Shows tips from the creator"); break;
                        case "cd": Console.WriteLine("'cd {path}': Changes directory\n\tExample: cd C:/Users/Felix"); break;
                        case "pwd": Console.WriteLine("'pwd': Prints working directory"); break;
                        case "ls": Console.WriteLine("'ls': Lists directories"); break;
                        case "creat":
                        case "new": Console.WriteLine("'new': Creats new student"); break;
                        case "rm":
                        case "delete": Console.WriteLine("'rm {id of student}': Removes a student from the list\n\tExample: rm #839474"); break;
                        case "change":
                        case "edit": Console.WriteLine("'edit {id of student}: Edits one value from one student\n\tExample: edit #839474"); break;
                        case "show": Console.WriteLine("'show': Lists all students"); break;
                        case "sort": Console.WriteLine("'sort {by attribute}: Sorts the list of students by the given attribute.\n\tThe possible attributes are: Firstname / Surname / Age / Email / Classname / Grade / ID.\n\tExample: sort Surname"); break;
                        case "save": Console.WriteLine("'save {path}': Saves all your students in a file"); break;
                        case "load": Console.WriteLine("'load {path}': Loads students from a file"); break;
                        case "close":
                        case "exit": return;
                        default: Console.WriteLine("Bash command not found!"); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Type:\n" +
                    "'cd {path}': Changes directory\n" +
                    "'pwd': Prints working directory\n" +
                    "'ls': Lists directories\n" +
                    "'new': Creats new student\n" +
                    "'rm {id of student}': Removes a student from the list\n" +
                    "'edit {id of student}: Edits one value from one student\n" +
                    "'show': Lists all students\n" +
                    "'sort {by attribute}: Sorts the list of students by the given attribute\n" +
                    "'save {path}': Saves all your students in a file\n" +
                    "'load {path}': Loads students from a file\n" +
                    "'help': Shows a list of all commands which can be used\n" +
                    "'tips': Shows tips from the creator\n" +
                    "'exit': Exits this program (Please stay here!)");
            }
        }

        public static void TipCommand()
        {
            Console.WriteLine("Tipps:\n" +
                "The path can be relative or absolute.");
        }

        public static void CdCommand(string[] commands)
        {
            if (commands.Length == 2)
            {
                if (Directory.Exists(commands[1]))
                    Directory.SetCurrentDirectory(commands[1]);
                else Console.WriteLine("Wrong path input!");
            }
        }

        public static void PwdCommand()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public static void LsCommand()
        {
            try
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
                string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir + "\\");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void NewCommand(Studentmanager sm)
        {
            if (sm.AddStudent(NewStudent()))
                Console.WriteLine("Student has successfully been added.");
            else Console.WriteLine("There is already a student with this name!\n" +
                "If you need some tips for handling this problem, type 'tips'!");
        }

        public static void RmCommand(string[] commands, Studentmanager sm)
        {
            if (commands.Length == 2)
            {
                int id;
                try
                {
                    if (commands[1][0] == '#')
                    {
                        commands[1] = commands[1].Substring(1);
                    }
                    id = Convert.ToInt32(commands[1]);
                    if (sm.GetFirstnamebyID(id) != null && sm.GetSurnamebyID(id) != null)
                    {
                        string name = sm.GetFirstnamebyID(id) + " " + sm.GetSurnamebyID(id);
                        Console.WriteLine($"Do you realy want to delete {name} (y/n)?");
                        if (Console.ReadLine() == "y")
                        {
                            if(sm.RemoveStudentbyID(id))
                                Console.WriteLine($"{name} has successfully been removed!");
                            else Console.WriteLine($"{name} was not removed!");
                        }
                        else Console.WriteLine($"{name} was not removed!");
                    }
                    else Console.WriteLine("There is no student with this ID!");
                }
                catch
                {
                    Console.WriteLine("ID has to be an integer!");
                }
            }
            else Console.WriteLine("Please enter the name of one student after 'rm'/'delete'!");
        }

        public static void EditCommand(string[] commands, Studentmanager sm)
        {

            if (commands.Length == 2)
            {
                int id;
                EAttribute attribute = EAttribute.none;
                try
                {
                    if (commands[1][0] == '#')
                    {
                        commands[1] = commands[1].Substring(1);
                    }
                    id = Convert.ToInt32(commands[1]);
                }
                catch
                {
                    Console.WriteLine("ID has to be an integer!");
                    return;
                }
                Console.WriteLine("What do you want to edit (Firstname/Surname/Age/Email/Classname/Grade)?");
                while (attribute == EAttribute.none)
                {
                    try
                    {
                        Console.Write("--> ");
                        attribute = (EAttribute)Enum.Parse(typeof(EAttribute), Console.ReadLine(), true);
                        switch (attribute)
                        {
                            case EAttribute.Firstname:
                                Console.WriteLine("What is the person's firstname?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong name input!");
                                break;
                            case EAttribute.Surname:
                                Console.WriteLine("What is the person's surname?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong name input!");
                                break;
                            case EAttribute.Age:
                                Console.WriteLine("How old is this person?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong age input!");
                                break;
                            case EAttribute.Email:
                                Console.WriteLine("Whats the person's email?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong email input!");
                                break;
                            case EAttribute.Classname:
                                Console.WriteLine("In which class does the person go?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong classname input!");
                                break;
                            case EAttribute.Grade:
                                Console.WriteLine("What grade does the person have?");
                                if (sm.Edit(id, attribute, Console.ReadLine()))
                                    Console.WriteLine("Attribute has successfully been edited!");
                                else Console.WriteLine("Wrong grade input!");
                                break;
                            default:
                                Console.WriteLine("Attribute has to be one of these: Firstname / Surname / Age / Email / Classname / Grade!");
                                continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Attribute has to be one of these: Name / Age / Email / Classname / Grade!");
                        Console.WriteLine("What do you want to edit?");
                    }
                }
            }
            else Console.WriteLine("Please enter the name of one student after 'edit'/'change'!");
        }

        public static void ShowCommand(Studentmanager sm)
        {
            Student[] students = sm.GetStudents();
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }

        public static void SortCommand(string[] commands, Studentmanager sm)
        {
            if(commands.Length == 2)
            {
                try
                {
                    if(commands[1] == "firstname" || commands[1] == "surname" || commands[1] == "age" || commands[1] == "email" || commands[1] == "classname" || commands[1] == "grade" || commands[1] == "id")
                    {
                        sm.SortList(commands[1]);
                        Console.WriteLine($"Students have successfully been sorted by {commands[1]}!");
                    }
                    else Console.WriteLine("Wrong attribute input!\nPlease enter one of these attributes: Firstname/Surname/Age/Email/Classname/Grade/ID!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else Console.WriteLine("Please enter an attribute according to which the list is sorted after 'sort'!");
        }

        public static void SaveCommand(string[] commands, Studentmanager sm)
        {
            if (commands.Length == 2)
            {
                if (sm.Save(commands[1]))
                    Console.WriteLine("Your students have been saved!");
                else Console.WriteLine("Wrong path input!");
            }
            else Console.WriteLine("Please enter one path after 'save'!");
        }

        public static void LoadCommand(string[] commands, Studentmanager sm)
        {
            if (commands.Length == 2)
            {
                if (sm.Load(commands[1]))
                    Console.WriteLine("Your students have successfully been loaded!");
                else Console.WriteLine("Wrong path input!");
            }
            else Console.WriteLine("Please enter one path after 'load'!");
        }

        public static void ChangeFColor(ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
        }

        public static void ChangeBColor(ConsoleColor cc)
        {
            Console.BackgroundColor = cc;
        }

        public static Student NewStudent()
        {
            Student s = new Student();
            while (s.Firstname == null || s.Surname == null || s.Age == 0 || s.Email == null || s.Classname == null || !(s.Grade >= 9 && s.Grade <= 14))
            {
                try
                {
                    if (s.Firstname == null)
                    {
                        Console.Write("Firstname: ");
                        s.Firstname = Console.ReadLine();
                    }
                    if (s.Surname == null)
                    {
                        Console.Write("Surname: ");
                        s.Surname = Console.ReadLine();
                    }
                    if (s.Age == 0)
                    {
                        Console.Write("Age: ");
                        s.Age = Convert.ToInt32(Console.ReadLine());
                    }
                    if (s.Email == null)
                    {
                        Console.Write("Email: ");
                        s.Email = Console.ReadLine();
                    }
                    if (s.Classname == null)
                    {
                        Console.Write("Classname: ");
                        s.Classname = Console.ReadLine().ToUpper();
                    }
                    if (!(s.Grade >= 9 && s.Grade <= 14))
                    {
                        Console.Write("Grade: ");
                        s.Grade = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input!");
                }
            }

            return s;
        }
    }
}
