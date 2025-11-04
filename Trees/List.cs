namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.

using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Previous = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    public ListNode<T> First = null;
    public ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }
        else
        {
            ListNode<T> f = First;
            int i = 0;
            while (i < index)
            {
                f = f.Next;
                i++;
            }
            return f.Value;
        }
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> lvalue = new ListNode<T>(value);

        if (First == null)
        {
            First = lvalue;
            Last = lvalue;
            m_numItems++;

        }
        else
        {
            Last.Next = lvalue;
            Last = lvalue;
            m_numItems++;

        }
        
        

    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        if (index == 0)
        {
            ListNode<T> f = First;
            First = First.Next;
            if (First != null)
            {
                First.Previous = null;
            }
            else
            {
                Last = null;
            }

            m_numItems--;

            return f.Value;
        }
        else if (index < m_numItems)
        {
            ListNode<T> value = First;
            if (index == m_numItems - 1)
            {
                Last = value.Previous;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    value = value.Next;

                }
                value.Previous.Next = value.Next.Next;
            }
            m_numItems--;
            return value.Value;

        }
        else
        {
            return default(T);
        }
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        m_numItems = 0;
        First = null;
        Last = null;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        ListNode<T> value = First;
        while (value!=null)
        {
            yield return value.Value;
            value=value.Next;
        }
        
    }
}