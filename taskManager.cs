using static ToDoList.Task;

namespace ToDoList;
public class taskManager {
    List<Task> taskList = new List<Task>() 
    {
        new Task 
        {
            Title = "C-Sharp",
            Description = "C# is a modern, innovative, open-source, cross-platform object-oriented programming language",
            DueDate = DateOnly.FromDateTime(DateTime.Now),
            PriorityLevels = Task.Priority.High,
        },
        new Task 
        {
            Title = "JavaScript",
            Description = "JavaScript (JS) is a lightweight interpreted (or just-in-time compiled) programming language with first-class functions.",
            DueDate = new DateOnly(2025, 04, 27),
            PriorityLevels = Task.Priority.Medium,
        },
        new Task 
        {
            Title = "Azure Developer",
            Description = "C Build end-to-end solutions in Microsoft Azure to create Azure Functions, implement and manage web apps, develop solutions utilizing Azure storage, and more.",
            DueDate = new DateOnly(2025, 04, 26),
            PriorityLevels = Task.Priority.Low,
        },

    };

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

    public void FilterTasksByPriority(Priority userPriority) {
        var tasksPriority = taskList.Where(t => t.PriorityLevels == userPriority);

        foreach (var t in tasksPriority)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
    }

    public void FilterTasksByCompletionStatus(bool userCompletionStatus) {
        var tasksCompletionStatus = taskList.Where(t => t.IsCompleted == userCompletionStatus);

        foreach (var t in tasksCompletionStatus)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
    }

    public void FilterTasksByDueDate(DateOnly userDate) {
        var tasksDueDate = taskList.Where(t => t.DueDate == userDate);

        foreach (var t in tasksDueDate)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($" ID: {t.Id} |Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
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


}
