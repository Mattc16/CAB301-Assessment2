using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of ToolCollection
        ToolCollection toolCollection = new ToolCollection();

        // Generate random test data and insert into the collection
        GenerateRandomTestData(toolCollection, 10);

        // Display the initial state of the tool collection
        Console.WriteLine("Initial state of the Tool Collection:");
        DisplayToolCollection(toolCollection);

        // Test searching for a tool
        string searchToolName = "Screwdriver"; // Adjusted to match the generated tool names
        ITool? foundTool = toolCollection.Search(searchToolName);
        Console.WriteLine($"\nSearching for '{searchToolName}':");
        if (foundTool != null)
        {
            Console.WriteLine($"Found: {foundTool}");
        }
        else
        {
            Console.WriteLine($"'{searchToolName}' not found.");
        }

        // Test deleting a tool
        string deleteToolName = "Wrench"; // Adjusted to match the generated tool names
        if (toolCollection.Search(deleteToolName) != null)
        {
            bool deleted = toolCollection.Delete(new Tool(deleteToolName));
            Console.WriteLine($"\nDeleting '{deleteToolName}': {(deleted ? "Deleted successfully." : "Failed to delete.")}");
        }
        else
        {
            Console.WriteLine($"\nCannot delete '{deleteToolName}': Tool not found.");
        }

        // Display the updated state of the tool collection after deletion
        Console.WriteLine("\nState of the Tool Collection after deletion:");
        DisplayToolCollection(toolCollection);

        // Test the ToArray function
        TestToArray(toolCollection);
    }

    static void GenerateRandomTestData(ToolCollection toolCollection, int numTools)
    {
        Random random = new Random();
        string[] toolNames = { "Hammer", "Screwdriver", "Wrench", "Pliers", "Saw", "Drill", "Chisel", "Level", "Tape Measure", "Clamp" };
        for (int i = 0; i < numTools; i++)
        {
            string toolName = toolNames[random.Next(0, toolNames.Length)]; // Randomly select a tool name from the array
            int toolNumber = random.Next(1, 11); // Random number of tools available
            Tool tool = new Tool(toolName, toolNumber);
            toolCollection.Insert(tool);
        }
    }

    static void DisplayToolCollection(ToolCollection toolCollection)
    {
        ITool[] tools = toolCollection.ToArray();
        foreach (ITool tool in tools)
        {
            Console.WriteLine(tool);
        }
    }

    static void TestToArray(ToolCollection toolCollection)
    {
        Console.WriteLine("\nTesting the ToArray function:");
        ITool[] tools = toolCollection.ToArray();
        Console.WriteLine("Tools in the Tool Collection (sorted alphabetically by name):");
        foreach (ITool tool in tools)
        {
            Console.WriteLine(tool);
        }
    }
}
