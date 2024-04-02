using System;


abstract class BaseList
{
    protected int count;

    int Count { get { return count; } }

    public abstract void Add(int data);

    public abstract void Insert(int index, int data);

    public abstract void Delete(int index);

    public abstract void Clean();

    public abstract int this[int index] { get; set; }

    public virtual void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.Write($"{this[i]} ");
        }
        Console.WriteLine();
    }

    public void Assign(BaseList source)
    {
        Clean();
        for (int i = 0; i < source.Count; i++)
        {
            this.Add(source[i]);
        }
    }

    public void AssignTo(BaseList dest)
    {
        dest.Assign(this);
    }

    public BaseList Clone()
    {
        BaseList clone = EmptyClone();
        clone.Assign(this);
        return clone;
    }

    public virtual void Sort()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = 0; j < Count - 1 - i; j++)
            {
                if (this[j] > this[j + 1])
                {
                    // Обмен элементов местами
                    int temp = this[j];
                    this[j] = this[j + 1];
                    this[j + 1] = temp;
                }
            }
        }
    }

    public bool IsEqual(BaseList list)
    {
        if (this.Count != list.Count)
        {
            Console.WriteLine(this.Count + " " + list.Count);
            return false;
        }

        for (int i = 0; i < this.Count; i++)
        {
            if (this[i] != list[i])
            {
                return false;
            }
        }
        return true;
    }

    protected abstract BaseList EmptyClone();
}
