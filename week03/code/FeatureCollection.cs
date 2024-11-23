// Class to map the entire feature collection in the JSON
public class FeatureCollection
{
    // List of features in the JSON
    public List<Feature> Features { get; set; }
}

// Class to map each feature in the JSON
public class Feature
{
    // Properties object inside each feature
    public Properties Properties { get; set; }
}

// Class to map the properties of each earthquake
public class Properties
{
    // Magnitude of the earthquake (nullable for missing values)
    public double? Mag { get; set; }

    // Location of the earthquake
    public string Place { get; set; }
}
