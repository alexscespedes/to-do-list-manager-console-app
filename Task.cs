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

    private Priority _priority;

    public void SetPriority(Priority value) 
    {
        _priority = value;
    }

    public Priority GetPriority() {
        return _priority;
    }

    public bool IsCompleted { get; set; } = false;

    public Task (string title, string description, DateOnly dueDate, Priority priority, bool isCompleted) {
        Title = title;
        Description = description;
        DueDate = dueDate;
        _priority = priority;
        IsCompleted = isCompleted;
    }
}
