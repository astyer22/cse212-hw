public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (Data == value)
        {
            return true;
        }
        else if (value < Data)
        {
            // Search in the left subtree
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search in the right subtree
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
{
    // Recursively calculate the height of the left and right subtrees
    int leftHeight = (Left != null && Left.Data != Data) ? Left.GetHeight() : 0;
    int rightHeight = (Right != null && Right.Data != Data) ? Right.GetHeight() : 0;

    // The height of the current node is 1 + the greater height of the two subtrees
    return 1 + Math.Max(leftHeight, rightHeight);
}

}
