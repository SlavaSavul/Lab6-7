using System;
using System.Text;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                try
                {
                    Turner Turner1 = new Turner("", "Svirid", 23, "machine operator of wide profile", "AutoCardan", 24000);
                    Student Student1 = new Student("Maxim", "Svirid", 29, "BSTU", "POIT", 2, "English");
                    Employee Employee1 = new Employee("Maxim", "Svirid", 36, "Hight", "AutoCardan", 700);
                    Turner Turner2 = new Turner("Maxim", "Svirid", 25, "machine operator of wide profile", "AutoCardan", 34000);
                    Programmer Programmer1 = new Programmer("Maxim", "Svirid", 44, "JS, AspectJ, PL/M, REXX", "EPAM", 44000);
                    Programmer Programmer2 = new Programmer("Maxim", "Svirid", 54, "JS, AspectJ, PL/M, REXX", "EPAM", 44000);                    
                    FocusGroup A = new FocusGroup();


                    A.SetPerson = Turner1;
                    #region
                    A.SetPerson = Employee1;
                    A.SetPerson = Student1;
                    A.SetPerson = Turner2;
                    A.SetPerson = Programmer2;
                    A.SetPerson = Programmer1;

                    Console.WriteLine();                    
                    Controler CONT = new Controler();
                    CONT.Show(A);
                    Console.WriteLine();
                    Console.WriteLine();

                    CONT.Sort(A);
                    CONT.Show(A);
                    FocusGroup B = new FocusGroup();
                    B.Persons = CONT.GetProgrammers(A);
                    CONT.Show(B);
                    #endregion

                }
                catch (PersonException e)
                {
                    e.GetMassage();
                    throw;
                }
                catch (FocusGroupException e)
                {
                    e.GetMassage();

                }
                finally
                {
                    Console.WriteLine("Finally");
                }
            }
            catch (PersonException e)
            {
                Console.WriteLine("Ошибка 123цйвыфчя");
            }

            Console.ReadKey();
        }
    }


    
    class FocusGroup
    {
        public List<Person> focusGroups;
        public Person SetPerson
        {
            set { if (value == null) throw new FocusGroupException("Не может быть null",102);
                 focusGroups.Add(value);
            }            
        }
        public List<Person> Persons
        {
            set{
                for (int i=0;i<value.Count;i++)
                {
                    if (value[i] == null) throw new FocusGroupException("Не может быть null",102, i);
                    focusGroups.Add(value[i]);
                }
            }
            get { return focusGroups; }
        }       
        public FocusGroup()
        {
            focusGroups = new List<Person>();
        }
        public void Delete(Person del)
        {
            int t = 0;
            foreach (Person i in focusGroups)
            {               
                if(i.Equals(del))
                {
                    focusGroups.RemoveAt(t);
                    break;
                }
                t++;
            }
        }           
    }

    class Controler : IComparer<Person>
    {
        public List<Person> GetProgrammers(FocusGroup obj)
        {
            List<Person> Programmers = new List<Person>();
            foreach (Person i in obj.focusGroups)
            {
                if (i is Programmer)
                {
                    Programmers.Add(i);
                }
            }
            return Programmers;
        }
        public void Sort(FocusGroup obj)
        {
            Person buf;
            for (int i = 0; i < obj.focusGroups.Count; i++)
            {
                for (int j = i + 1; j < obj.focusGroups.Count; j++)
                {
                    if (obj.focusGroups[i].Age < obj.focusGroups[j].Age)
                    {
                        buf = obj.focusGroups[i];
                        obj.focusGroups[i] = obj.focusGroups[j];
                        obj.focusGroups[j] = buf;
                    }
                }
            }
        }
        public void KolStudents(FocusGroup obj)
        {
            int kol = 0;
            foreach (Person i in obj.focusGroups)
            {
                if (i is Student)
                {
                    kol++;
                }
            }
            Console.WriteLine("Количество студентов {0}", kol);
            Console.WriteLine();
        }
        public void Show(FocusGroup obj)
        {
            foreach (Person i in obj.focusGroups)
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine();
            }
        }
        public int Compare(Person obj1, Person obj2)
        {
            if (obj1.Age < obj2.Age)
                return 1;
            else if (obj1.Age > obj2.Age)
                return -1;
            return 0;
        }
    }
    
    struct StructPerson
    {
        string Name;
        string Family;
        int Age;
        public StructPerson(string name, string family, int age)
        {
            Name = name;
            Family = family;
            Age = age;
        }
        public void Info()
        {
            Console.WriteLine($"Name: {Name}  Family: {Family}  Age:  {Age}");
        }
    }
    enum EInfo : byte { Name, Family, Age }



    interface IInfo
    {
        string Information();
    }
    interface IGet 
    {
        void GetStr();
    }
    interface IGetMass
    {
        void GetMassage();
    }


    class PersonException :Exception, IGetMass
    {
        public int numException;
        string str = "(Person)";
        public PersonException(string message,int num) :base(message)
        {
            numException = num;
        }
        public virtual  void GetMassage()
        {
            Console.WriteLine(Message + " Номер ошибки: "+ numException + str);
        }

    }
    class WorkingException: PersonException
    {
        string str="(Working)";
        public WorkingException(string message, int num) : base(message,num)
        {
        }
        public override void GetMassage()
        {
            Console.WriteLine(Message + " Номер ошибки: " + numException +str);
        }
    }
    class LeanerException : PersonException
    {
        string str = "(Leaner)";
        public LeanerException(string message, int num) : base(message,num)
        {        
        }
        public override void GetMassage()
        {
            Console.WriteLine(Message + " Номер ошибки: " + numException + str);
        }

    }
    class FocusGroupException : Exception, IGetMass
    {
        public int numException;
        public int index;
        public FocusGroupException(string message,int num, int i = -1) : base(message)
        {
            numException = num;
            index = i;
        }
        public void GetMassage()
        {
            if(index>=0)
                Console.WriteLine(Message +"\nИндекс "+ index + " Номер ошибки: " + numException+ "(FocusGroup)");
            else
                Console.WriteLine(Message  + " Номер ошибки: " + numException+ "(FocusGroup)");
        }

    }




    abstract partial class Person : IInfo
    {
       
        public virtual string Information()
        {
            //Console.WriteLine("Name: "+ Name + "\nFamily: "+ Family+ "\nAge: " + Age);
            return ("Name: " + Name + "\nFamily: " + Family + "\nAge: " + Age);
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Person") + "\n" + Information();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            Person Obj = (Person)obj;
            return GetHashCode() == Obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return (Name + Family + Age).GetHashCode();
        }
    }

    abstract partial class Working : Person
    {
        

      
        public override string Information()
        {
            // base.Information();
            //Console.WriteLine("Organization:   {0} \nWage: {1:c} ", Organization, Wage);
            return base.Information() + String.Format("\nOrganization:   {0} \nWage: {1:c} ", Organization, Wage);
        }
        public virtual void GetStr()
        {
            Console.WriteLine("\nWorking");
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Working") + "\n" + Information();
        }

    }

    abstract partial class Learner : Person
    {

        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("Educational institution: " + EducationalInstitution + "\nCourse: " + Course + "\nSpecialty: " + Specialty);
            return base.Information() + ("\nEducational institution: " + EducationalInstitution + "\nCourse: " + Course + "\nSpecialty: " + Specialty);
        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Learner") + "\n" + Information();
        }
    }

    partial class Employee : Working, IGet
    {
       

        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("Education: " + Education);
            return base.Information() + ("\nEducation: " + Education);
        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Employee") + "\n" + Information();
        }


        void IGet.GetStr()
        {
            Console.WriteLine("IGet");
        }

        public override void GetStr()
        {
            Console.WriteLine("Employee");
        }


    }

    partial class Turner : Working
    {
       
        public new string Information()
        {
            return base.Information() + ("\nSpecialty: " + Specialty);
        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Turner") + "\n" + Information();
        }



       

    }

    partial class Programmer : Working
    {
       
        public override string Information()
        {
            // base.Information();
            //Console.WriteLine("\nProgrammingLanguages: " + ProgrammingLanguages);
            return base.Information() + ("\nProgramming Languages: " + programmingLanguages);

        }

        public override string ToString()
        {
            return String.Format("Тип объекта: Programmer") + "\n" + Information();
        }

    }

    partial  class Student : Learner
    {
       
        public override string Information()
        {
            // base.Information();
            //Console.WriteLine("Courses: " + AdditionalCourses);
            return base.Information() + ("\nCourses: " + AdditionalCourses);

        }
        public override string ToString()
        {
            return String.Format("Тип объекта: Student") + "\n" + Information();
        }
    }

    sealed partial class StudentExtramural : Learner
    {
        
        public override string Information()
        {
            //base.Information();
            // Console.WriteLine("WorkPlace: " + WorkPlace);
            return base.Information() + ("\nWorkPlace: " + WorkPlace);


        }
        public override string ToString()
        {
            return String.Format("Тип объекта: StudentExtramural") + "\n" + Information();
        }
    }

    class Print
    {
        public void IAmPrinting(Person obj)
        {
            if (obj == null) return;

            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }

        public void Enum(Person obj, EInfo op)
        {
            switch (op)
            {
                case EInfo.Name:
                    Console.WriteLine(obj.Name);
                    break;
                case EInfo.Family:
                    Console.WriteLine(obj.Family);
                    break;
                case EInfo.Age:
                    Console.WriteLine(obj.Age);
                    break;              
            }
        }
    }


}
