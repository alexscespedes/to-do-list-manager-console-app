using System.Globalization;
using System.Text.RegularExpressions;
using static ToDoList.Task;

namespace ToDoList;
public class taskManager {
    List<Task> taskList = new List<Task>();

    public void AddTask(Task task) {

        taskList.Add(task);


        // SaveTasksToTextFile(taskList);
        Console.WriteLine("Task successfully created");
    }

    public void ViewTasks() {
        foreach (var task in taskList)
        {
            string status = task.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}");
        }
    }

    public void RemoveTask(int id) {
        var task = taskList.SingleOrDefault(t => t.Id == id);

        if (task != null)
        {
            taskList.Remove(task);
        }
    }

    public void MarkAsComplete (int id) {
        var task = taskList.SingleOrDefault(t => t.Id == id);

        if (task != null)
        {
            if (!task.IsCompleted)
            {
                task.IsCompleted = true;
            }
        }
    }

    public void FilterTask(int userInput) 
    {
        var tasksFiltered = new List<Task>();
        if (userInput == 1)
        {
            // Console.Write("Enter the priority: ");
            Priority userPriority = Priority.High;
            tasksFiltered = taskList.Where(t => t.PriorityLevels == userPriority).ToList();
        }
        else if (userInput == 2)
        {
            // Console.Write("Enter the status: ");
            bool userCompletionStatus = true;
            tasksFiltered = taskList.Where(t => t.IsCompleted == userCompletionStatus).ToList();
        }
        else if (userInput == 3)
        {
            // Console.Write("Enter the Date (yyyy-mm-dd): ");
            DateOnly userDate = new DateOnly(2025, 04, 28);
            tasksFiltered = taskList.Where(t => t.DueDate == userDate).ToList();
        }

        foreach (var task in tasksFiltered)
        {
            string status = task.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}");
        }
    }

    public void SortByName(int userInput) {
        var tasksSortedByName = new List<Task>();
        if (userInput == 1) {
            tasksSortedByName = taskList.OrderBy(task => task.Title).ToList();
        }
        else if (userInput == 2)
        {
            tasksSortedByName = taskList.OrderByDescending(task => task.Title).ToList();
        }

        foreach (var task in tasksSortedByName)
        {
            string status = task.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}");
        }
    }

    public void SortByDate(int userInput) {
        var tasksSortedByDate = new List<Task>();
        if (userInput == 1) {
            tasksSortedByDate = taskList.OrderBy(t => t.DueDate).ToList();
        }
        else if (userInput == 2)
        {
            tasksSortedByDate = taskList.OrderByDescending(t => t.DueDate).ToList();
        }

        foreach (var task in tasksSortedByDate)
        {
            string status = task.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}");
        }
    }

    public void SaveTasksToTextFile(List<Task> tasks) {
        string filePath = "/home/alexsc03/Documents/Projects/DotNet/C-SharpConsoleApps/ToDoListManager/tasks.txt";
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath)) {
                sw.WriteLine("Id, Title, Description, DueDate, Priority, Status");
                foreach (var task in tasks)
                {
                    sw.WriteLine($"{task.Id}, {task.Title}, {task.Description}, {task.DueDate}, {task.PriorityLevels}, {task.IsCompleted}");
                }
            }
        }
        catch (Exception e)
        {
            
            Console.WriteLine("Error saving tasks: " + e.Message);
        }
    }

    public void ReadTasksFromTextFile() {
        string filePath = "/home/alexsc03/Documents/Projects/DotNet/C-SharpConsoleApps/ToDoListManager/tasks.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No tasks file found. Starting with an empty list.");
            return;
        }

        try
        {
            using (StreamReader file = new StreamReader(filePath)) 
            {
                string? line;
                string? headerLine = file.ReadLine();                

                while ((line = file.ReadLine()) != null) {
                    string[] items = line.Split(',');
                    if (items.Length >= 1)
                    {
                        taskList.Add(new Task(items[1], items[2], DateOnly.Parse("04/05/2025"), (Priority)Enum.Parse(typeof(Priority), items[4]), bool.Parse(items[5])));
                    }
                }
            }
        }
        catch (Exception e)
        {
            
            Console.WriteLine("Exception: " + e.Message);
        }

        Console.WriteLine("Read Successfully.");
    }

    public void SearchTaskByTitle(string title) {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Error: the title cannot be empty");
            return;
        }

        var tasksPartialSearched = taskList.Where(task => task.Title.StartsWith(title.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList();
        
        if (tasksPartialSearched.Count == 0)
        {
            Console.WriteLine("Task not found");
            return;
        }

        foreach (var task in tasksPartialSearched)
        {
            string status = task.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}");
        }

    }
}
