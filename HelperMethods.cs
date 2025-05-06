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
}
