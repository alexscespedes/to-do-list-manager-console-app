using static ToDoList.Task;

namespace ToDoList;
public class taskManager {
    private List<Task> taskList = new List<Task>();

    public void AddTask(string title, string description, DateOnly dueDate, Priority priority) {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Error: Title and Description cannot be empty");
            return;
        }
        if (TaskExists(title))
        {
            Console.WriteLine("The task already exists");
            return;
        }

        taskList.Add( new Task {
            Title = title,
            Description = description,
            DueDate = dueDate,
            PriorityLevels = priority
        });

        Console.WriteLine($"Task {title} succesfully added");
    }

    private bool TaskExists(string title) {
        return taskList.Exists(task => task.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}
