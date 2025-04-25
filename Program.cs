namespace ToDoList;

class Program {

    static void Main(string[] args)
    {
        var taskManager = new taskManager();

        taskManager.RemoveTask(3);
        taskManager.ViewTasks();
    }
}
