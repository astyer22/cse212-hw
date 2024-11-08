public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // Initialize indices for list1 and list2
        int index1 = 0;
        int index2 = 0;

        // Initialize the result array with the same length as the select array
        int[] result = new int[select.Length];

        // Iterate through the select array
        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1) // Select from list1
            {
                result[i] = list1[index1];
                index1++; // Increment the index for list1
            }
            else if (select[i] == 2) // Select from list2
            {
                result[i] = list2[index2];
                index2++; // Increment the index for list2
            }
        }

        return result;
    }
}
