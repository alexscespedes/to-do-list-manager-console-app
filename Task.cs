namespace ToDoList;

public class Task {
    
    static int nextId;
    public int Id {get; private set;}

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

    public Task() {
        Id = Interlocked.Increment(ref nextId);
    }

    public Task (string title, string description, DateOnly dueDate, Priority priority, bool isCompleted) {
        Id = Interlocked.Increment(ref nextId);
        Title = title;
        Description = description;
        DueDate = dueDate;
        PriorityLevels = priority;
        IsCompleted = isCompleted;
    }
}
