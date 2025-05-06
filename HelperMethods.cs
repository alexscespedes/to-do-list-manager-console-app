namespace ToDoList;

public class HelperMethods {
    public void CheckIfEmpty(List<Task> tasks) {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Task not found");
            return;
        }
    }
}
