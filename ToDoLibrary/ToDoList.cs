using System.Collections.Generic;

namespace ToDoLibrary
{
    public class ToDoList
    {
        public int Count
        {
            get { return _theList.Count; } 
            set { }
        }

        private List<ToDoItem> _theList = new List<ToDoItem>();

        public void AddItem(ToDoItem item)
        {
            _theList.Add(item);
        }

        public void AddItemByIndex(ToDoItem item, int index)
        {
            _theList.Insert(index,item);
        }
 
        public ToDoItem GetItem(int index)
        {
            return _theList[index];
        }

        public void RemoveItem(int index)
        {
            _theList.RemoveAt(index);
        }

        public List<ToDoItem> GetEntireList()
        {
            return _theList;
        }
    }
}