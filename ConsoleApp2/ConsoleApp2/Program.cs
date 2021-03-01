using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace ConsoleApp2
{

    class Client
    {
       static void Main()
        {
            List<Auto> collection = new List<Auto>();
            collection.Add(new Car { ModelTitle = "ВАЗ" });
            collection.Add(new Track { ModelTitle = "ГАЗель" });
            collection.Add(new Car { ModelTitle = "Merсedes" });
            collection.Add(new Track { ModelTitle = "КамАЗ" });
            IVisitor visitor = new AutoVisitor();
            foreach (Auto a in collection)
            {
                a.Accept(visitor);
            }

        }
    }

    abstract class Auto
    {
        public string ModelTitle { get; set; }
        public abstract void Accept(IVisitor visitor);
    }
    class Car : Auto
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCar(this);
        }
    }
    class Track : Auto
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitTrack(this);
        }
    }
    interface IVisitor
    {
        void VisitCar(Car car);
        void VisitTrack(Track track);
    }
    class AutoVisitor : IVisitor
    {
        public void VisitCar(Car car)
        {
            Console.WriteLine($"Легковой автомобиль модели: {car.ModelTitle}");
        }
        public void VisitTrack(Track track)
        {
            Console.WriteLine($"Грузовой автомобиль модели: {track.ModelTitle}");
        }
    }




    /* class TestDestructors
     {
         static void Main()
         {
             //Builder b = new Builder();

             // MyClass c2 = b.WithX(40).WithY(50).WithZ(100).Build();


             Person p = new Person();

             Employee emp = new Employee("Microsoft");

             Console.Read();


         }
         public int[] GetArrray()
         {
             int[] result = new int[10];
             return result;
         }
     }


     class Person
     {
         // остальной код класса
         // конструктор по умолчанию
         public string FirstName;
         public Person()
         {
             FirstName = "Tom";
             Console.WriteLine("Вызов конструктора без параметров");
         }
     }
     class Employee : Person
     {
         public string Company;
         public Employee(string company)
         {
             Company = company;
             Console.WriteLine(FirstName);
             Console.WriteLine(Company);
         }
     }
     */





    //public class Singleton
    //{
    //    private static Lazy<Singleton> _instanceLazy = new Lazy<Singleton>(() => new Singleton());
    //    //private static Lazy<Singleton> _instanceLazy = new Lazy<Singleton>(delegate () { return new Singleton(); });


    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            return _instanceLazy.Value;
    //        }
    //    }


    //    private Singleton() { }


    //}



    //public class HttpClientFactory
    //{
    //    public HttpClient Create()
    //    {
    //        HttpClient h = new HttpClient();

    //        h.BaseAddress = new Uri("https:\\google.com");
    //        //h.DefaultRequestHeaders = new System.Net.Http.Headers.HttpRequestHeaders();
    //        h.Timeout = TimeSpan.FromMinutes(1.5);

    //        return h;
    //    }
    //}

    public class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class Builder
    {
        private int _x;
        private int _y = 55;
        private int _z;

        public Builder WithX(int x)
        {
            if (x < 0 || x > 100)
            {
                throw new ArgumentException();
            }

            _x = x;

            return this;
        }

        public Builder WithY(int y)
        {
            _y = y;

            return this;
        }

        public Builder WithZ(int z)
        {
            _z = z;

            return this;
        }

        public MyClass Build()
        {
            MyClass c = new MyClass();

            c.X = _x;
            c.Y = _y;
            c.Z = _z;

            return c;
        }
    }
}
