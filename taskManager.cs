namespace ToDoList;

public class taskManager {
    private List<Task> taskList = new List<Task>();

    public void GetTask() {
            var task = new Task {
            Title = "Advanced C# Course",
            Description = "OOP, SOLID & Desing Patterns",
            DueDate = new DateOnly(2016, 08, 21),
            PriorityLevels = Task.Priority.High,
        };

        taskList.Add(task);

        foreach (var t in taskList)
        {
            string status = t.IsCompleted ? "Completed" : "Active";
            Console.WriteLine($"Title: {t.Title}, Description: {t.Description}, DueDate: {t.DueDate}, Priority: {t.PriorityLevels}, Status: {status}");
        }
    }
}
