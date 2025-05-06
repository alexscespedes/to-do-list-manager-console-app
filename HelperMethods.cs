namespace ToDoList;

public class HelperMethods {
    public bool CheckIfEmpty(List<Task> tasks) {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Task not found.");
            return true;
        }
        return false;
    }

    public void PrintTask(Task task) {
        string status = task.IsCompleted ? "Completed" : "Active";
        Console.WriteLine($" ID: {task.Id} |Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Priority: {task.PriorityLevels}, Status: {status}"); 
    }
}
