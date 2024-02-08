using System;
namespace Session4
{
    class Person
    {
        string name, city;
        int age;
        public Person()
        {

        }
        public Person(int age)
        {
            this.age = age;
        }
        public Person(string name)
        {
            this.name = name;
        }
        public Person(int age, string name, string city)
        {
            this.age = age;
            this.name = name;
            this.city = city;
        }
        public Person(string name,int age , string city)
        {
            this.age = age;
            this.name = name;
            this.city = city;
        }
        public Person(string name = "", string city = "", int age = 15)//this is all constraints
        {
            this.name = name;
            this.city = city;
            this.age = age;
        }
        public string Display(int num)
        {
            return $"name={name}, city={city}, age={age}" +"----"+ num.ToString();
        }
        public string Display(int num, string company)
        {
            return $"name={name}, city={city}, age={age} , number={num} , company={company}";
        }
        public virtual string DisplayName()
        {
            return $"name={name}";
        }
        public string DisplayCity()
        {
            return $"city=Alleppo";
        }
    }
    sealed class programmer
    {
        string name;
        public programmer(string name)
        {
            this.name = name;
        }
        public string DisplayName()
        {
            return $"name is {name}";
        }
    }
    //class developer:programmer //this is an error because programmer is sealed class
    //{
    //    string name;
    //    public string DisplayName()
    //    {
    //        return $"name={name}";
    //    }
    //}
    class developer : Person
    {
        public override string DisplayName()
        {
            return "Mohammad";
        }
        //public override  string DisplayCity()//this is error because it is not virtual methode
        //{
        //    return "Idleb";
        //}
        public new string DisplayCity()
        {
            return $"city=New Idleb";
        }
    }
    public class Complex
    {
        private int real;
        private int img;
        public Complex(int r = 0, int i = 0)
        {
            real = r;
            img = i;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex temp = new Complex();
            temp.real = c1.real + c2.real;
            temp.img = c1.img + c2.img;
            return temp;
        }
        public string Display()
        {
            return $"{real} + {img}i";
        }      
    }
}
