using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace libstudents
{
    public enum EAttribute { none, Firstname, Surname, Age, Email, Classname, Grade }
    public class Studentmanager
    {
        private Random randy = new Random();
        public List<Student> Students { get; private set; }

        public Studentmanager():this(new List<Student>()) { }

        public Studentmanager(List<Student> ls)
        {
            this.Students = ls;
        }

        public bool AddStudent(Student s)
        {
            s.ID = GetID();
            Students.Add(s);
            return true;
        }

        private int GetID()
        {
            int id = randy.Next(100000, 1000000);
            foreach (var item in Students)
            {
                if(id == item.ID)
                {
                    return GetID();
                }
            }
            return id;
        } 

        public string GetFirstnamebyID(int id)
        {
            foreach (var item in Students)
            {
                if (item.ID == id)
                {
                    return item.Firstname;
                }
            }
            return null;
        }

        public string GetSurnamebyID(int id)
        {
            foreach (var item in Students)
            {
                if (item.ID == id)
                {
                    return item.Surname;
                }
            }
            return null;
        }

        public bool RemoveStudentbyID(int id)
        {
            foreach (var item in Students)
            {
                if (item.ID == id) {
                    if (Students.Remove(item))
                        return true;
                    return false;
                }
            }
            return false;
        }

        public bool Edit(int id, EAttribute att, string value)
        {
            foreach (var item in Students)
            {
                if (item.ID == id)
                {
                    try
                    {
                        switch (att)
                        {
                            case EAttribute.Firstname: item.Firstname = value; return true;
                            case EAttribute.Surname: item.Surname = value; return true;
                            case EAttribute.Age: item.Age = Convert.ToInt32(value); return true;
                            case EAttribute.Email: item.Email = value; return true;
                            case EAttribute.Classname: item.Classname = value; return true;
                            case EAttribute.Grade: item.Grade = Convert.ToInt32(value); return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public void SortList(string att)
        {
            switch(att)
            {
                case "firstname":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Firstname == null && y.Firstname == null) return 0;
                        else if (x.Firstname == null) return -1;
                        else if (y.Firstname == null) return 1;
                        else return x.Firstname.CompareTo(y.Firstname);
                    });
                    break;
                case "surname":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Surname == null && y.Surname == null) return 0;
                        else if (x.Surname == null) return -1;
                        else if (y.Surname == null) return 1;
                        else return x.Surname.CompareTo(y.Surname);
                    });
                    break;
                case "age":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Age == 0 && y.Age == 0) return 0;
                        else if (x.Age == 0) return -1;
                        else if (y.Age == 0) return 1;
                        else return x.Age.CompareTo(y.Age);
                    });
                    break;
                case "email":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Email == null && y.Email == null) return 0;
                        else if (x.Email == null) return -1;
                        else if (y.Email == null) return 1;
                        else return x.Email.CompareTo(y.Email);
                    });
                    break;
                case "classname":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Classname == null && y.Classname == null) return 0;
                        else if (x.Classname == null) return -1;
                        else if (y.Classname == null) return 1;
                        else return x.Classname.CompareTo(y.Classname);
                    });
                    break;
                case "grade":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.Grade == 0 && y.Grade == 0) return 0;
                        else if (x.Grade == 0) return -1;
                        else if (y.Grade == 0) return 1;
                        else return x.Grade.CompareTo(y.Grade);
                    });
                    break;
                case "id":
                    Students.Sort(delegate (Student x, Student y)
                    {
                        if (x.ID == 0 && y.ID == 0) return 0;
                        else if (x.ID == 0) return -1;
                        else if (y.ID == 0) return 1;
                        else return x.ID.CompareTo(y.ID);
                    });
                    break;
            }
        }

        public Student[] GetStudents()
        {
            return Students.ToArray();
        }

        public Student this[int idx]
        {
            get { return Students[idx]; }
            set
            {
                this.Students[idx] = value;
            }
        }        

        public bool Save(string path)
        {
            try
            {
                string text = "";
                foreach (var item in Students)
                {
                    text += ToCSV(item);
                    text += "\n";
                }
                File.WriteAllText(path, text);
                return true;
            }
            catch { return false; }
        }

        public bool Load(string path)
        {
            
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var item in lines)
                {
                    string[] words = item.Split(";");
                    Student s = new Student();
                    s.Firstname = words[0];
                    s.Surname = words[1];
                    s.Age = Convert.ToInt32(words[2]);
                    s.Email = words[3];
                    s.Classname = words[4];
                    s.Grade = Convert.ToInt32(words[5]);
                    s.ID = Convert.ToInt32(words[6]);
                    Students.Add(s);
                }
                return true;
            }
            catch { return false; }
        }

        private string ToCSV(Student s)
        {
            return $"{s.Firstname};{s.Surname};{s.Age};{s.Email};{s.Classname};{s.Grade};{s.ID}";
        }
    }
}
