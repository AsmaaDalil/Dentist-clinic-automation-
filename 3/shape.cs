using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp34
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public virtual string PrintInfo() //إذا لم يتم إعادة تعريف التابع  في الفئة الوارثة، سيتم استخدام تعريفه الافتراضي في الفئة الأساسية .
        {
            return "This is a shape.";
        }
        public virtual string HelloShape()
        {
            return "hello to a shape.";
        }
        public  string HelloShapeNoVir()
        {
            return "hello to a shape no virtual.";
        }
    }
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double GetArea()
        {
            return width * height;
        }
        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override string PrintInfo()
        {
            return $"This is a circle with radius {radius}.";
        }
        public sealed override string HelloShape()
        {
            return "It is mine Circle";
        }
        //public override string HelloShapeNoVir()//this is an error because it is not virtual
        //{
        //    return "It is mine Circle";
        //}
    }
    public class MyCircle : Circle
    {
        private double radius;
        public MyCircle(double radius):base(radius)//base for pass parameter to Top class
        {
            this.radius = radius;
        }
        public override string PrintInfo()
        {
            return $"This is a My circle with radius {radius}.";
        }
        //public override string HelloShape() //this is an error because it is sealed in circle class
        //{
        //    return "It is mine";
        //}
    }
}
