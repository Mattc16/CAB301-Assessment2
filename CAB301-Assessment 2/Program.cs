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
        string searchToolName = "Tool6"; // Adjusted to match the generated tool names
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
        string deleteToolName = "Tool3"; // Adjusted to match the generated tool names
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
    }

    static void GenerateRandomTestData(ToolCollection toolCollection, int numTools)
    {
        Random random = new Random();
        for (int i = 0; i < numTools; i++)
        {
            string toolName = "Tool" + i; // Adjusted to start from Tool0
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
}
