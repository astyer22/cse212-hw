public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the size of 'length'
        double[] multiples = new double[length];

        // Step 2: Loop through each position in the array and calculate the multiple of the number
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array of multiples
        return multiples;}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calcualte the split point
        // The split point is the index where the list will be split into two parts.  The first part will be the last 'amount' elements
        int splitPoint = data.Count -amount;

        // Step 2: Get the two parts of the list
        // The last part is the first 'amount' elements
        List<int> lastPart = data.GetRange(splitPoint, amount);

        // The first part is the remaining elements
        List<int> firstPart = data.GetRange(0, splitPoint);

        // Step 3: Clear the original list so it can be reorder
        data.Clear();

        // Step 4: Add the last part first
        data.AddRange(lastPart);

        // Step 5: Add the first part
        data.AddRange(firstPart);

    }
}
