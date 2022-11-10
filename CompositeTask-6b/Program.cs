using System;
using System.Collections;
namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            Component principal = new Composite("Principal");
            principal.Add(new Leaf("Assistant of principal"));

            Component headMathTeacher  = new Composite("Head math teacher");
            headMathTeacher.Add(new Leaf("Math teacher 1"));
            headMathTeacher.Add(new Leaf("Math teacher 2"));
            headMathTeacher.Add(new Leaf("Math teacher 3"));

            principal.Add(headMathTeacher);

            Component headEnglishTeacher = new Composite("Head English teacher");
            headEnglishTeacher.Add(new Leaf("English teacher 1"));
            headEnglishTeacher.Add(new Leaf("English teacher 2"));

            principal.Add(headEnglishTeacher);

            Leaf leaf = new Leaf("Second assistant of principal");

            principal.Add(leaf);
            principal.Remove(leaf);

             principal.Display(1);

            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    // "Composite"
    class Composite : Component
    {
        private ArrayList children = new ArrayList();
        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in children)
            {
                component.Display(depth + 1);
            }
        }
    }

    // "Leaf"
    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}