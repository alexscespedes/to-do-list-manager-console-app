namespace ToDoList;

public class Task {
    public string Title { get; set; }

    public string Description { get; set; }

    public DateOnly DueDate { get; set; }

    public enum Priority
    {
        Low,
        Medium,

        High
    };

    public Priority PriorityLevels { get; set; }

    public bool IsCompleted { get; set; } = false;

    public Task() {}

    public Task (string title, string description, DateOnly dueDate, Priority priority, bool isCompleted) {
        Title = title;
        Description = description;
        DueDate = dueDate;
        PriorityLevels = priority;
        IsCompleted = isCompleted;
    }
}
