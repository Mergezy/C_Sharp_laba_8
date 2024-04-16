using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Registration user = new Registration(5);
            user.UserRegistration("Игорь", "1234567");
            user.UserRegistration("Никита2017", "18052017");

            for (int i = 0; i < user.Length(); i++)
            {
                DataBase database = user.Get((uint)i);
                Console.WriteLine("Username: " + database.Username + ", Password: " + database.Password);
            }
        }
    }
    public class ArrayG<T>
    {
        private int size;
        private T[] array;

        public ArrayG(uint size)
        {
            array = new T[size];
            size = 0;
        }
        public void Add(T item)
        {
            if (size < array.Length)
            {
                array[size] = item;
                size++;
            }
            else
                Console.WriteLine("Массив переполнен!");
        }
        public void Remove(uint index)
        {
            if (index <= size)
            {
                array[index] = default(T);
            }
            else
                Console.WriteLine("Некорректный индекс!");
        }
        public T Get(uint index)
        {
            if (index <= size)
                return array[index];
            else
                return default(T);
        }
        public string Get()
        {
            string str = "";
            return str = string.Join(", ", array);
        }
        public int Length()
        {
            return size;
        }
    }
    public class DataBase
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DataBase(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
    public class Registration : ArrayG<DataBase>
    {
        public Registration(uint size) : base(size)
        {
        }
        public void UserRegistration(string username, string password)
        {
            DataBase user = new DataBase(username, password);
            Add(user);
        }
    }
}
