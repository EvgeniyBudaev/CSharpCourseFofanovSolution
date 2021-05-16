using System;

namespace D_OOP
{
    public class BankTerminal
    {
        protected string id;

        public BankTerminal(string id)
        {
            this.id = id;
        }

        // virtual - чтобы часть наследников могло воспользоваться этим методом, а часть могла воспользоваться но и переопределить этот метод
        public virtual void Connect() 
        {
            Console.WriteLine("General Connecting Protocol...");
        }
    }

    public class ModelXTerminal : BankTerminal
    {
        public ModelXTerminal(string id) : base(id)
        {
        }

        // override - если этот класс хочет переопределить родительский метод
        public override void Connect()
        {
            // base - значит что мы обращаемся к родительскому классу
            base.Connect();
            Console.WriteLine("Additional actions for Model X");
        }
    }

    public class ModelYTerminal : BankTerminal
    {
        public ModelYTerminal(string id) : base(id)
        {
        }

        public override void Connect()
        {
            Console.WriteLine("Actions for Model Y");
        }
    }
}