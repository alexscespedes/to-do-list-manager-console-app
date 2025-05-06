namespace ToDoList;
    class Program {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            taskManager.ReadTasksFromTextFile();
            
            bool exit = false;

            while(!exit) {
                Console.WriteLine("Welcome to the To-Do List Manager Console App");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. Remove a task");
                Console.WriteLine("3. Search by task title");
                Console.WriteLine("4. Mark a task as completed");
                Console.WriteLine("5. Display all tasks");
                Console.WriteLine("6. Filter tasks");
                Console.WriteLine("7. Sort tasks");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int userInput)) {
                    Console.WriteLine("Invalid input! Please enter a valid integer");
                    break;
                }

                switch(userInput) {
                    case 1: 
                        AddNewTask(taskManager);
                        break;
                    case 2:
                        DeleteTask(taskManager);
                        break;
                    case 3: 
                        SearchTaskName(taskManager);
                        break;
                    case 4:
                        TaskAsCompleted(taskManager);
                        break;
                    case 5: 
                        taskManager.ViewTasks();
                        break;
                    case 6:
                        FilterTasks(taskManager);
                        break; 
                    case 7:
                        SortTasks(taskManager);
                        break;                                                                        
                    case 8: 
                        exit = true;
                        break;
                }
            }
        }

        static void AddNewTask(TaskManager taskManager) {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            Console.Write("Enter task description: ");
            string description = Console.ReadLine()!;

            Console.Write("Enter task due date: ");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dueDate))
            {
                Console.WriteLine("Invalid DateOnly Format");
                return;
            }
            
            Console.WriteLine("Enter task priority: ");
            Console.WriteLine("1. High ");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Low ");
            Console.Write("Choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out int taskPriority)) {
                    Console.WriteLine("Invalid input! Please enter a valid integer");
                    return;
                }
            Priority priority;
            switch (taskPriority) {
                    case 1:
                        priority = Priority.High;
                        break;
                    case 2:
                        priority = Priority.Medium;
                        break;
                    case 3:
                        priority = Priority.Low;
                        break;
                    default:
                        Console.WriteLine("Invalid option, created with the default priority (Medium).");
                        priority = Priority.Medium;
                        break;
                    }

            var newTask = new Task {
                Title = title,
                Description = description,
                DueDate = dueDate,
                PriorityLevels = priority
            };            

            taskManager.AddTask(newTask);
        }

        static void DeleteTask(TaskManager taskManager) {
            Console.Write("Enter the id of the task to remove: ");
            bool valid = int.TryParse(Console.ReadLine(), out int id);
            if (!valid || id <= 0)
            {
                Console.WriteLine("Invalid Id entered.");
                return;
            }

            taskManager.RemoveTask(id);
        }

        static void SearchTaskName(TaskManager taskManager) {
            Console.Write("Enter title to search: ");
            string searchName = Console.ReadLine()!;
            taskManager.SearchTaskByTitle(searchName);
        }

        static void TaskAsCompleted(TaskManager taskManager) {
            Console.Write("Enter the id of the task to mark as complete: ");
            bool valid = int.TryParse(Console.ReadLine(), out int id);
            if (!valid || id <= 0)
            {
                Console.WriteLine("Invalid Id entered.");
                return;
            }

            taskManager.MarkAsComplete(id);
        }

        static void FilterTasks(TaskManager taskManager) {
            Console.WriteLine("Enter the filter option: ");
            Console.WriteLine("1. By Priority ");
            Console.WriteLine("2. By Completion Status");
            Console.WriteLine("3. By Due Date");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int filterOption)) {
                    Console.WriteLine("Invalid input! Please enter a valid integer");
                    return;
                }

            taskManager.FilterTask(filterOption);
        }

        static void SortTasks(TaskManager taskManager) {
            Console.WriteLine("Enter the sort option: ");
            Console.WriteLine("1. Name Ascending ");
            Console.WriteLine("2. Name Descending");
            Console.WriteLine("3. Due Date Ascending");
            Console.WriteLine("4. Due Date Descending");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int sortOption)) {
                    Console.WriteLine("Invalid input! Please enter a valid integer");
                    return;
                }

            taskManager.SortTasks(sortOption);
        }

    }
