namespace ToDoLibrary
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public ToDoItem(string title, string description, int priority = 500)
        {
            Title = title;
            Description = description;
            Priority = priority;

        }
        
    }
}