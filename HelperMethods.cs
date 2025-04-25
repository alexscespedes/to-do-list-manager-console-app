namespace ToDoList;

public class HelperMethods {
        public bool TaskStringValidation(string title, string description) {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Error: Title and Description cannot be empty");
            return false;
        }

        // In real world, we create dropdown to make sure every task have just the predefined priority.
        // if (Priority.High != priority || Priority.Medium != priority || Priority.Low != priority)
        // {
        //     Console.WriteLine("Invalid Priority Level");
        // }
        // we are gonna use dateonly.now() to make sure every task have the right datetime

        return true;
    }


    /*
        public void AddTask(string title, string description, DateOnly dueDate, Priority priority) {
        // if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        // {
        //     Console.WriteLine("Error: Title and Description cannot be empty");
        //     return;
        // }
        // if (TaskExists(title))
        // {
        //     Console.WriteLine("The task already exists");
        //     return;
        // }

        taskList.Add( new Task {
            Title = title,
            Description = description,
            DueDate = dueDate,
            PriorityLevels = priority
        });

        Console.WriteLine($"Task {title} succesfully added");
    }

        private bool TaskExists(string title) {
        return taskList.Exists(task => task.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    */
}
