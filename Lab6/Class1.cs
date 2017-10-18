using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    abstract partial class Person : IInfo
    {
        string name;
        string family;
        int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Family
        {
            get { return family; }
            set { family = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name, string family, int age)
        {
            if(age<0)
            {
                throw new PersonException("Age < 0",121);
            }
            if (String.Compare(name,"",true)==0)
            {
                throw new PersonException("Имя обязательно",109);
            }
            if (String.Compare(family, "", true) == 0)
            {
                throw new PersonException("Фамилия обязательна",104);
            }
            this.name = name;
            this.family = family;
            this.age = age;

        }
      
    }

    abstract partial class Working : Person
    {
        string organization;
        int wage;
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }
        public int Wage
        {
            get { return wage; }
            set { wage = value; }
        }
        public Working(string name, string family, int age, string organization, int wage) : base(name, family, age)
        {
            if (String.Compare(organization, "", true) == 0)
            {
                throw new WorkingException("Отсутствует организация",211);
            }
            this.wage = wage;
            this.organization = organization;
        }
    }

    abstract partial class Learner : Person
    {
        string educationalInstitution;
        int course;
        string specialty;
        public string EducationalInstitution
        {
            get { return educationalInstitution; }
            set { educationalInstitution = value; }
        }
        public int Course
        {
            get { return course; }
            set { course = value; }
        }
        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }
        public Learner(string name, string family, int age, string educationalInstitution, string specialty, int course) : base(name, family, age)
        {
            if (course < 1) throw new LeanerException("Курс не может быть <1",120);
            if (String.Compare(specialty,"",true)==0) throw new LeanerException("Специальность должна быить задана",123);
            this.educationalInstitution = educationalInstitution;
            this.course = course;
            this.specialty = specialty;
        }    
    }

    partial class Employee : Working, IGet
    {
        string education;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public Employee(string name, string family, int age, string education, string organization, int wage) : base(name, family, age, organization, wage)
        {
            this.education = education;
        }


       


    }

    partial class Turner : Working
    {
        string specialty;
        public string Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        public Turner(string name, string family, int age, string specialty, string organization, int wage) : base(name, family, age, organization, wage)
        {
            this.specialty = specialty;
        }

     

    }

    partial class Programmer : Working
    {
        string programmingLanguages;
        public string ProgrammingLanguages
        {
            get { return programmingLanguages; }
            set { programmingLanguages = value; }
        }

        public Programmer(string name, string family, int age, string programmingLanguages, string organization, int wage) : base(name, family, age, organization, wage)
        {
            this.programmingLanguages = programmingLanguages;
        }

      

    }

    partial class Student : Learner
    {
        string additionalCourses;
        public string AdditionalCourses
        {
            get { return additionalCourses; }
            set { additionalCourses = value; }
        }

        public Student(string name, string family, int age, string educationalInstitution, string specialty, int course, string additionalCourses) : base(name, family, age, educationalInstitution, specialty, course)
        {
            this.additionalCourses = additionalCourses;
        }
       
    }

    sealed partial class StudentExtramural : Learner
    {
        string workPlace;
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }

        public StudentExtramural(string name, string family, int age, string educationalInstitution, string specialty, int course, string workPlace) : base(name, family, age, educationalInstitution, specialty, course)
        {
            this.workPlace = workPlace;
        }
      
    }


}
