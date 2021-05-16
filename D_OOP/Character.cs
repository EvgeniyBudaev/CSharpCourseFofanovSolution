using System;

namespace D_OOP
{
    public class Character
    {
        public static int speed = 10; // статическое свойство или поле абсолютно разделяются на все экземпляры типа Character
        public const int charisma = 10; // константа. обязаны инициализировать переменную
        // readonly - используется, если поле инициализируем через конструктор единожды и дальше в метод не имеем права его дальше менять
        // readonly - помечает поле как инстанцию класса
        // readonly. не обязаны сразу инициализировать переменную. 
        public readonly int strength; // readonly. не обязаны сразу инициализировать переменную. 

        public int Health {get; private set;} = 100; // Автосвойства
        
        public Race Race { get; private set; }

        public int Armor { get; private set; }

        // Конструкторы - для защиты начального состояния класса
        public Character() // конструктор по-умолчанию
        {}

        public Character(Race race)
        {
            Race = race;
            switch (race)
            {
                case D_OOP.Race.Elf:
                    Armor = 30;
                    break;
                case D_OOP.Race.Ork:
                    Armor = 40;
                    break;
                case D_OOP.Race.Terrain:
                    Armor = 20;
                    break;
                default:
                    throw new ArgumentException("Unknown race.");
            }
        }

        public Character(Race race, int armor)
        {
            Race = race;
            Armor = armor;
        }

        public Character(Race race, int armor, int strength)
        {
            Race = race;
            Armor = armor;
            this.strength = strength;
        }

        public void Hit(int damage)
        {
            if (damage > Health)
                damage = Health;

            Health -= damage;
        }

        public int PrintSpeed()
        {
            return speed;
        }

        public void IncreaseSpeed()
        {
            speed += 10;
        }
    }

    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}