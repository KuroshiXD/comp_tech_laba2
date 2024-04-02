using System;


class ChainList : BaseList
{
    private Node head;

    public override void Add(int data)
    {
        Node newNode = new Node(data);
        Node current = head;

        if (head == null)
        {
            head = newNode;
            count++; // Увеличиваем count, когда добавляем первый элемент
            return;
        }

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;

        count++; // Увеличиваем count после добавления элемента в конец списка
    }

    public override void Insert(int index, int data)
    {
        Node current = head;
        int currentIndex = 0;

        if (index < 0 || index > count)
        {
            return;
        }
        else
        {
            if (index == 0)
            {
                Node currentNode = new Node(data);
                currentNode.Next = current;
                head = currentNode;
                count++; // Увеличиваем count при добавлении элемента в начало списка
                return;
            }
            else
            {
                while (current != null)
                {
                    if (currentIndex + 1 == index)
                    {
                        Node currentNode = new Node(data);
                        currentNode.Next = current.Next;
                        current.Next = currentNode;
                        count++; // Увеличиваем count при добавлении элемента в середину списка
                        return;
                    }
                    currentIndex++;
                    current = current.Next;
                }
            }
        }
    }

    public override void Delete(int index)
    {
        if (index < 0 || index >= count)
        {
            return;
        }
        else
        {
            if (index == 0)
            {
                head = head.Next;
                count--; // Уменьшаем count при удалении первого элемента списка
                return;
            }
            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex + 1 == index)
                {
                    current.Next = current.Next.Next;
                    count--; // Уменьшаем count при удалении элемента из середины списка
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }
    }

    public override void Clean()
    {
        head = null;
        count = 0;
    }

    private Node Find(int index)
    {
        int currentIndex = 0;
        Node current = head;

        if (index < 0 || index >= count)
        {
            return null;
        }
        else
        {
            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }
                current = current.Next;
                currentIndex++;
            }
        }
        return null;
    }

    public override int this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                return 0;

            Node node = Find(index);
            if (node != null)
                return node.Data;
            else
                return 0;
        }

        set
        {
            if (index >= 0 && index < count)
            {
                Node node = Find(index);
                if (node != null)
                    node.Data = value;
            }
        }
    }


    protected override ChainList EmptyClone()
    {
        return new ChainList();
    }

    public override void Sort()
    {
        // Проверяем, что список не пустой или состоит только из одного элемента
        if (head == null || head.Next == null)
        {
            return;
        }

        int n = count; // Получаем количество элементов в списке
        int gap = n / 2; // Инициализируем начальный интервал

        // Начинаем с большого интервала, а затем уменьшаем его до 1
        while (gap > 0)
        {
            // Проходим через список, начиная с позиции i с шагом gap
            for (int i = 0; i < n - gap; i++)
            {
                // Получаем текущий узел, смещаясь на позицию i
                Node current = head;
                for (int j = 0; j < i; j++)
                {
                    current = current.Next;
                }

                // Получаем узел через gap позиций
                Node gapNode = head;
                for (int j = 0; j < i + gap; j++)
                {
                    gapNode = gapNode.Next;
                }

                // Применяем сортировку вставками для каждого интервала
                while (gapNode != null)
                {
                    // Если текущий элемент больше элемента через gap позиций, меняем их местами
                    if (current.Data > gapNode.Data)
                    {
                        int temp = current.Data;
                        current.Data = gapNode.Data;
                        gapNode.Data = temp;
                    }

                    // Переходим к следующим элементам в интервале
                    current = current.Next;
                    gapNode = gapNode.Next;
                }
            }

            gap /= 2; // Уменьшаем интервал
        }
    }

    public override void Print()
    {
        Node current = head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
}



