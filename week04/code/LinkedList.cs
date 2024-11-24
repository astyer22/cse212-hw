using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }
public void InsertTail(int value)
{
    // Create a new node to insert
    Node newNode = new Node(value);

    // Check if the list is empty (i.e., no nodes exist in the list)
    if (_head == null)
    {
        // If the list is empty, set both the head and tail to the new node
        _head = newNode;
        _tail = newNode;
    }
    else
    {
        // If the list is not empty, link the new node to the end of the list
        // Set the current tail's Next pointer to the new node
        _tail!.Next = newNode;  // Use the null-forgiving operator to suppress the CS8602 warning

        // Set the new node's Prev pointer to the current tail
        newNode.Prev = _tail;

        // Update the tail pointer to the new node, making it the last node in the list
        _tail = newNode;
    }
}


/// <summary>
/// Remove the last node (i.e. the tail) of the linked list.
/// </summary>
/// <summary>
/// Remove the last node (i.e. the tail) of the linked list.
/// </summary>
public void RemoveTail()
{
    // Check if the list is empty
    if (_head == null)
    {
        // If the list is empty, there is nothing to remove
        return;
    }

    // If the list has only one node, we will remove it
    if (_head == _tail)
    {
        _head = null;  // Set head to null
        _tail = null;  // Set tail to null
    }
    else
    {
        // If the list has more than one node:
        // Move the tail pointer to the previous node
        _tail = _tail.Prev;

        // Disconnect the new tail from the previous node
        _tail.Next = null;
    }
}




    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

/// <summary>
/// Remove the first node that contains 'value'.
/// </summary>
public void Remove(int value)
{
    Node? curr = _head;

    while (curr is not null)
    {
        // If we find the node that contains the value, proceed with removal
        if (curr.Data == value)
        {
            // If the node to be removed is the head
            if (curr == _head)
            {
                // Handle head removal logic directly here
                if (_head == _tail) // Only one node in the list
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next;
                    _head.Prev = null;
                }
            }
            // If the node to be removed is the tail
            else if (curr == _tail)
            {
                RemoveTail();
            }
            // If the node is in the middle
            else
            {
                // Reconnect the previous node's next pointer to the current node's next node
                curr.Prev!.Next = curr.Next;

                // Reconnect the next node's previous pointer to the current node's previous node
                curr.Next!.Prev = curr.Prev;

                // Clean up the current node's references (for garbage collection)
                curr.Next = null;
                curr.Prev = null;
            }

            return; // Exit after the node is removed
        }

        // Move to the next node
        curr = curr.Next;
    }
}



    /// <summary>
/// Search for all instances of 'oldValue' and replace the value with 'newValue'.
/// </summary>
public void Replace(int oldValue, int newValue)
{
    // Start from the head of the list
    Node? curr = _head;

    // Traverse the list
    while (curr != null)
    {
        // If we find a node with oldValue, replace its value
        if (curr.Data == oldValue)
        {
            curr.Data = newValue;
        }

        // Move to the next node
        curr = curr.Next;
    }
}


    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

  /// <summary>
/// Iterate backward through the Linked List.
/// </summary>
public IEnumerable Reverse()
{
    // Start from the tail of the list
    Node? curr = _tail;

    // Traverse the list backwards using the Prev pointer
    while (curr != null)
    {
        // Yield the data of the current node
        yield return curr.Data;

        // Move to the previous node
        curr = curr.Prev;
    }
}

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}