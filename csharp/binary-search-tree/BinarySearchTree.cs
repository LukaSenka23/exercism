using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private int value;
    public BinarySearchTree(int value)
    {
        this.value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        bool isFirst = true;
        foreach (var v in values)
        {
            if (isFirst)
            {
                this.value = v;
                isFirst = false;
            }
            else
                Add(v);
            
        }
    }

    public int Value
    {
        get => value;
    }

    private BinarySearchTree? left;
    public BinarySearchTree? Left
    {
        get;
        private set;
    }

    private BinarySearchTree? right;
    public BinarySearchTree? Right
    {
        get;
        private set;
    }

    public BinarySearchTree Add(int value)
    {
        if (value <= this.Value)
        {
            if (Left == null)
                Left = new BinarySearchTree(value);
            else
                Left.Add(value);
        }

        else
        {
            if (Right == null)
                Right = new BinarySearchTree(value);
            else
                Right.Add(value);
        }
        
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
            foreach (var v in Left)
                yield return v;
        
        yield return this.Value;//trenutna vrednost.

        if (Right != null)
            foreach (var v in Right)
                yield return v;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}