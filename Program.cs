using System;


class Program
{
    static void Main(string[] args)
    {
        BaseList arrayList = new ArrayList();
        BaseList chainList = new ChainList();

        Random random = new Random();
        for (int i = 0; i < 1000; i++)
        {
            int operation = random.Next(1, 6);
            int Data = random.Next(50);
            int index = random.Next(50);
            switch (operation)
            {
                case 1:
                    arrayList.Add(Data);
                    chainList.Add(Data);
                    break;
                case 2:
                    arrayList.Delete(index);
                    chainList.Delete(index);
                    break;
                case 3:
                    arrayList.Insert(index, Data);
                    chainList.Insert(index, Data);
                    break;
                case 4:
                    arrayList.Clean();
                    chainList.Clean();
                    break;
                case 5:
                    arrayList.Sort();
                    chainList.Sort();
                    break;
            }
        }

        if (chainList.IsEqual(arrayList))
        {
            Console.WriteLine("Списки одинаковы");
        } 
        else
        {
            Console.WriteLine("Списки не одинаковы!");
        }

        Console.WriteLine("Array: ");
        arrayList.Print();
        Console.WriteLine("Chain: ");
        chainList.Print();

        Console.WriteLine("Проверка Assign: ");
        BaseList clone = arrayList.Clone();
        BaseList second_clone = arrayList.Clone();
        Console.WriteLine("Применение Assign от chain к clone: ");
        clone.Assign(chainList);
        clone.Print();
        Console.WriteLine("Применение AssignTo от clone к second_clone: ");
        second_clone.AssignTo(clone);
        second_clone.Print();

    }
}
