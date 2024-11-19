using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 2);
        priorityQueue.Enqueue("high", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue()); // Highest priority
        Assert.AreEqual("medium", priorityQueue.Dequeue()); // Second priority
        Assert.AreEqual("low", priorityQueue.Dequeue()); // Lowest priority
    }

    [TestMethod]
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 2);
        priorityQueue.Enqueue("second", 2);

        Assert.AreEqual("first", priorityQueue.Dequeue()); // FIFO order
        Assert.AreEqual("second", priorityQueue.Dequeue()); // FIFO order
    }

    [TestMethod]
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue()); // Empty queue
    }
}
