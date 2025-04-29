using System.Globalization;
using static ToDoList.Task;

namespace ToDoList;
public class taskManager {
    List<Task> taskList = new List<Task>();

    public void AddTask() {
        taskList.Add( new Task {
            Title = "Docker",
            Description = "Docker is a software platform that allows you to build, test, and deploy applications quickly.",
            DueDate = DateOnly.FromDateTime(DateTime.Now),
            PriorityLevels = Priority.Medium
        });
        SaveTasksToTextFile(taskList);
        Console.WriteLine("Task successfully created");
    }

    public void ViewTasks() {
        foreach (var t in taskList)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
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
            tasksFiltered = FilterTasksByPriority(userPriority);
        }
        else if (userInput == 2)
        {
            // Console.Write("Enter the status: ");
            bool userCompletionStatus = true;
            tasksFiltered = FilterTasksByCompletionStatus(userCompletionStatus);
        }
        else if (userInput == 3)
        {
            // Console.Write("Enter the Date (yyyy-mm-dd): ");
            DateOnly userDate = new DateOnly(2025, 04, 28);
            tasksFiltered = FilterTasksByDueDate(userDate);
        }

        foreach (var t in tasksFiltered)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
    }

    public List<Task> FilterTasksByPriority(Priority userPriority) {
       return taskList.Where(t => t.PriorityLevels == userPriority).ToList();
    }

    public List<Task> FilterTasksByCompletionStatus(bool userCompletionStatus) {
       return taskList.Where(t => t.IsCompleted == userCompletionStatus).ToList();
    }

    public List<Task> FilterTasksByDueDate(DateOnly userDate) {
       return taskList.Where(t => t.DueDate == userDate).ToList();
    }

    public void SortByName(int userInput) {
        var tasksSortedByName = new List<Task>();
        if (userInput == 1) {
            tasksSortedByName = taskList.OrderBy(t => t.Title).ToList();
        }
        else if (userInput == 2)
        {
            tasksSortedByName = taskList.OrderByDescending(t => t.Title).ToList();
        }

        foreach (var t in tasksSortedByName)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
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

        foreach (var t in tasksSortedByDate)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
    }

    public void SaveTasksToTextFile(List<Task> tasks) {
        string filePath = "C:/Users/AlexanderSencion/Downloads/Projects/to-do-list-manager-console-app/tasks.txt";
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath)) {
                sw.WriteLine("Id, Title, Description, DueDate, Priority, Status");
                foreach (var t in tasks)
                {
                    string status = t.IsCompleted ? "Completed" : "Active";
                    sw.WriteLine($"{t.Id}, {t.Title}, {t.Description}, {t.DueDate}, {t.PriorityLevels}, {status}");
                }
            }
        }
        catch (Exception e)
        {
            
            Console.WriteLine("Error saving tasks: " + e.Message);
        }
    }

    public void ReadTasksFromTextFile() {
        string filePath = "C:/Users/AlexanderSencion/Downloads/Projects/to-do-list-manager-console-app/tasks.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No tasks file found. Starting with an empty list.");
            return;
        }

        try
        {
            using (StreamReader file = new StreamReader(filePath)) 
            {
                string line;
                string headerLine = file.ReadLine();                

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
}
