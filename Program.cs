namespace ToDoList;

class Program {

    static void Main(string[] args)
    {
        var taskManager = new taskManager();

        taskManager.MarkAsComplete(3);
        // taskManager.ViewTasks();
        // taskManager.FilterTasksByPriority(Task.Priority.High);
        // taskManager.FilterTasksByCompletionStatus(true);
        // taskManager.FilterTasksByDueDate(new DateOnly(2025, 04, 28));
        // taskManager.SortByName(1);
        // taskManager.SortByDate(2);
        taskManager.FilterTask(3);

        /*
    1. Add a new task 
    2. Remove a task 
    3. Check if a task exists.
    4. Display all tasks
    5. Show total task
    6. Filter tasks
        - by priority
        - completion status
        - due date
    7. Sort tasks
        - name ascending
        - due date (newest)
    8. Exit
        */
    }
}
