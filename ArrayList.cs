using System;


class ArrayList : BaseList
{
    private int[] buffer;
    private int capacity;

    public ArrayList()
    {
        capacity = 1;
        buffer = new int[capacity];
        count = 0;
    }

    public void ResizeArray()
    {
        int newsize = buffer.Length * 2;
        int[] newArray = new int[newsize];
        Array.Copy(buffer, newArray, buffer.Length);
        buffer = newArray;

    }

    public override void Add(int data)
    {
        if (count == buffer.Length)
        {
            ResizeArray();
        }
        buffer[count++] = data;

    }

    public override void Insert(int index, int data)
    {

        if (index < 0 || index >= buffer.Length - 1)
        {
            return;
        }

        else
        {
            if (count == buffer.Length) { ResizeArray(); }
               
            else
            {
            for (int i = count; i > index; i--) { buffer[i] = buffer[i - 1]; }

            buffer[index] = data;
            count++;
            }
        }
    }

    public override void Clean()
    {
        buffer = new int[capacity];
        count = 0;
        capacity = 1;
    }

    public override void Delete(int index)
    {
        if (index < 0 || index >= buffer.Length - 1) { return; }

        else
        {
            for (int i = index; i < count - 1; i++)
            {
            buffer[i] = buffer[i + 1];
            }
            count--;
        }
    }

    public override int this[int index]
    {
        get
        {
            if (index < 0 || index > buffer.Length - 1) { return 0; }
            else
            {
                return buffer[index];
            }
        }

        set
        {
            if (index < 0 || index > buffer.Length - 1) { return; }
            else
            {
                buffer[index] = value;
            }
        }
    }

    protected override ArrayList EmptyClone()
    {
        return new ArrayList();
    }
}

