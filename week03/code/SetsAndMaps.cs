using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
/// The words parameter contains a list of two character 
/// words (lower case, no duplicates). Using sets, find an O(n) 
/// solution for returning all symmetric pairs of words.  
/// </summary>
/// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
public static string[] FindPairs(string[] words)
{
    // Step 1: Create a HashSet to store words for quick lookup
    HashSet<string> wordSet = new HashSet<string>(words);
    
    // Step 2: Create a list to hold the result pairs
    List<string> pairs = new List<string>();

    // Step 3: Create a HashSet to track words we've already used to form pairs
    HashSet<string> usedWords = new HashSet<string>();

    // Step 4: Iterate over each word in the words array
    foreach (var word in words)
    {
        // Skip the word if it has already been used in a pair
        if (usedWords.Contains(word))
        {
            continue;
        }

        // Step 5: Check if the reverse of the word exists in the set
        string reversedWord = new string(word.Reverse().ToArray());

        // If the reversed word exists and it's not the same word (e.g., 'aa' case)
        if (wordSet.Contains(reversedWord) && word != reversedWord)
        {
            // Add both words to the usedWords set
            usedWords.Add(word);
            usedWords.Add(reversedWord);

            // Step 6: Add the pair to the result list in the format "word & reversedWord"
            pairs.Add($"{word} & {reversedWord}");
        }
    }

    // Step 7: Convert the list of pairs to an array and return
    return pairs.ToArray();
}


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            // Split the line into fields
            var fields = line.Split(',');

            // Ensure the line has at least 4 columns
            if (fields.Length < 4)
                continue;

            // Get the degree from the 4th column
            var degree = fields[3].Trim();

            // Update the count in the dictionary
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }
        

        return degrees;
    }

    /// <summary>
/// Determine if 'word1' and 'word2' are anagrams.  An anagram
/// is when the same letters in a word are re-organized into a 
/// new word.  A dictionary is used to solve the problem.
/// 
/// Examples:
/// is_anagram("CAT","ACT") would return true
/// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
/// 
/// Important Note: When determining if two words are anagrams, you
/// should ignore any spaces.  You should also ignore cases.  For 
/// example, 'Ab' and 'Ba' should be considered anagrams
/// 
/// Reminder: You can access a letter by index in a string by 
/// using the [] notation.
/// </summary>
public static bool IsAnagram(string word1, string word2)
{
    // Normalize the words: remove spaces and convert to lowercase
    word1 = word1.ToLower().Replace(" ", "");
    word2 = word2.ToLower().Replace(" ", "");

    // If the lengths are different, they can't be anagrams
    if (word1.Length != word2.Length)
    {
        return false;
    }

    // Count the occurrences of each character in word1
    var charCount = new Dictionary<char, int>();
    for (int i = 0; i < word1.Length; i++)
    {
        char c = word1[i];
        if (charCount.ContainsKey(c))
        {
            charCount[c]++;
        }
        else
        {
            charCount[c] = 1;
        }
    }

    // Check if word2 matches the character counts
    for (int i = 0; i < word2.Length; i++)
    {
        char c = word2[i];
        if (!charCount.ContainsKey(c) || charCount[c] == 0)
        {
            return false;
        }
        charCount[c]--;
    }

    // If all counts are zero, the words are anagrams
    return true;
}


    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Check if the deserialized data contains valid features
if (featureCollection?.Features == null)
{
    // Return an empty array if no features are found
    return Array.Empty<string>();
}

// Initialize a list to hold the formatted earthquake summaries
var earthquakeSummaries = new List<string>();

// Loop through each feature in the collection
foreach (var feature in featureCollection.Features)
{
    // Ensure both magnitude and place properties are valid
    if (feature.Properties?.Mag.HasValue == true && !string.IsNullOrEmpty(feature.Properties.Place))
    {
        // Format the earthquake summary string
        string summary = $"{feature.Properties.Place} - Mag {feature.Properties.Mag:F2}";

        // Add the formatted summary to the list
        earthquakeSummaries.Add(summary);
    }
}

// Convert the list of summaries to an array and return
return earthquakeSummaries.ToArray();

        return [];
    }
}