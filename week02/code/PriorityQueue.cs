using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<(string item, int priority, int order)> queue;  // List to store items along with their priority and insertion order.
    private int order;  // Counter to maintain FIFO order for equal priorities.

    public PriorityQueue()
    {
        queue = new List<(string, int, int)>();
        order = 0;
    }

    // Enqueue method to add items with priorities.
    public void Enqueue(string item, int priority)
    {
        // Insert the item with its priority and insertion order.
        queue.Add((item, priority, order));
        order++;
        // Maintain the max-heap property by sorting the queue after each insertion.
        queue.Sort((x, y) =>
        {
            // First, compare by priority (higher priority comes first).
            int priorityComparison = y.priority.CompareTo(x.priority);
            if (priorityComparison == 0)
            {
                // If priorities are the same, use the FIFO order (lower order number comes first).
                return x.order.CompareTo(y.order);
            }
            return priorityComparison;
        });
    }

    // Dequeue method to remove and return the highest priority item.
    public string Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        // Remove and return the first item (which is the highest priority item).
        string item = queue[0].item;
        queue.RemoveAt(0);
        return item;
    }

    // Peek method to return the highest priority item without removing it.
    public string Peek()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return queue[0].item;
    }

    // Method to check if the queue is empty.
    public bool IsEmpty()
    {
        return queue.Count == 0;
    }
}
