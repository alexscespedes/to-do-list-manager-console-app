namespace ToDoList;
public class TaskManager {
    private List<Task> taskList = new List<Task>();
    HelperMethods helper = new HelperMethods();
    public void AddTask(Task task) {

        taskList.Add(task);
        SaveTasksToTextFile(taskList);
        Console.WriteLine("Task successfully created");
    }

    public void ViewTasks() {
        foreach (var task in taskList)
        {
            helper.PrintTask(task);
        }
    }

    public void ViewMutatedTasks(List<Task> tasks) {
        foreach (var task in tasks)
        {
            helper.PrintTask(task);
        }
    }

    public void RemoveTask(int id) {
        var task = taskList.SingleOrDefault(t => t.Id == id);

        if (task != null)
        {
            taskList.Remove(task);
            return;
        }
        Console.WriteLine($"No task found with Id {id}");

    }

    public void MarkAsComplete (int id) {
        var task = taskList.SingleOrDefault(t => t.Id == id);

        if (task != null)
        {
            if (!task.IsCompleted)
            {
                task.IsCompleted = true;
                return;
            }
            else 
            {
                Console.WriteLine($"Task already completed");
                return;
            }
        }
        Console.WriteLine($"No task found with Id {id}");
    }

    public void FilterTask(int userInput) 
    {
        var tasksFiltered = new List<Task>();
        switch (userInput) {
                case 1:
                    Console.Write("Enter the filter value: ");
                    if (!Enum.TryParse(typeof(Priority), Console.ReadLine(), true, out object? userPriority))
                    {
                        Console.WriteLine("Invalid priority input.");
                        return;
                    }
                    
                    tasksFiltered = taskList.Where(task => task.PriorityLevels == (Priority)userPriority!).ToList();
                    // I have to use this many time, time to refactor...
                    if (tasksFiltered.Count == 0)
                    {
                        Console.WriteLine("No task found");
                    }
                    helper.CheckIfEmpty(tasksFiltered);
                    break;
                case 2:
                    Console.Write("Enter the filter value: ");
                    if (!bool.TryParse(Console.ReadLine(), out bool userStatus))
                    {
                        Console.WriteLine("Invalid status format");
                    }
                    tasksFiltered = taskList.Where(task => task.IsCompleted == userStatus).ToList();
                    helper.CheckIfEmpty(tasksFiltered);
                    break;
                case 3:
                    Console.Write("Enter the filter value: ");
                    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly userDueDate))
                    {
                        Console.WriteLine("Invalid dateOnly format");
                        return;
                    }
                    tasksFiltered = taskList.Where(task => task.DueDate == userDueDate).ToList();
                    helper.CheckIfEmpty(tasksFiltered);
                    break;
                default:
                    Console.WriteLine("Invalid option, please enter a valid one.");
                    break;
        }
        ViewMutatedTasks(tasksFiltered);
    }

    public void SortTasks(int userInput) {
        var tasksSorted = new List<Task>();
        switch (userInput) {
            case 1:
                tasksSorted = taskList.OrderBy(task => task.Title).ToList();
                break;
            case 2:
                tasksSorted = taskList.OrderByDescending(task => task.Title).ToList();
                break;
            case 3:
                tasksSorted = taskList.OrderBy(t => t.DueDate).ToList();
                break;
            case 4:
                tasksSorted = taskList.OrderByDescending(t => t.DueDate).ToList();
                break;
            default:
                Console.WriteLine("Invalid option, please enter a valid one.");
                break;
        }

        ViewMutatedTasks(tasksSorted);
    }

    public void SaveTasksToTextFile(List<Task> tasks) {
        string filePath = "/home/alexsc03/Documents/Projects/DotNet/C-SharpConsoleApps/ToDoListManager/tasks.txt";
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath)) {
                sw.WriteLine("Id, Title, Description, DueDate, Priority, Status");
                foreach (var task in tasks)
                {
                    sw.WriteLine($"{task.Id},{task.Title},{task.Description},{task.DueDate},{task.PriorityLevels},{task.IsCompleted}");
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
                        taskList.Add(new Task(items[1], items[2], DateOnly.Parse(items[3]), (Priority)Enum.Parse(typeof(Priority), items[4]), bool.Parse(items[5])));
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
        if (string.IsNullOrWhiteSpace(title)) {
            Console.WriteLine("The title cannot be empty");
            return;
        }
        
        var tasksPartialSearched = taskList.Where(task => task.Title.Contains(title.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList();

        helper.CheckIfEmpty(tasksPartialSearched);

        ViewMutatedTasks(tasksPartialSearched);
    }

}
