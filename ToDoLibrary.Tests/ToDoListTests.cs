using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ToDoLibrary.Tests
{
    
    public class ToDoListTests
    {
        ToDoList _uutList = new ToDoList();
        
        [Fact]
        public void ShouldAddNewItemsToList()
        {
            //Arrange
            int index = 3;
            List<ToDoItem> expectedList = PopulateList(5);
            ToDoItem insertion = new ToDoItem("INSERTION", "INSERTRION");
            //Act
            BulkAddItems(_uutList, expectedList);
            _uutList.AddItemByIndex(insertion, index);
            expectedList.Insert(index, insertion);
            List<ToDoItem> actualList = GetAllItemsFromList(_uutList);
            //Assert
            Assert.Equal(expectedList, actualList);
        }
        
        [Fact]
        public void ShouldRemoveItemFromList()
        {
            //Arrange
            _uutList.AddItem(PopulateList(1)[0]);
            //Act
            _uutList.RemoveItem(0);
            //Assert
            Assert.Equal(0, (int)GetAllItemsFromList(_uutList).Count);
        }

        [Fact]
        public void ShouldGetItemsFromList()
        {
            //Arrange 
            List<ToDoItem> expectedItems = PopulateList(2);
            //Arrange
            BulkAddItems(_uutList, expectedItems);
            //Act
            List<ToDoItem> actualItems = GetAllItemsFromList(_uutList);
            //Assert
            Assert.Equal(expectedItems, actualItems);
        }

        [Fact]
        public void ShouldBeSameInstance()
        {
            //Arrange
            ToDoItem expected = GetNewItem();
            _uutList.AddItem(expected);
            //Act
            ToDoItem actual = _uutList.GetItem(0);
            //Assert
            Assert.Same(expected,actual);
        }

        [Fact]
        public void ShouldHaveCorrectItemsAfterDeletion()
        {
            //Arrange
            int index = 1;
            List<ToDoItem> expectedItems = PopulateList(3);
            BulkAddItems(_uutList, expectedItems);
            //Act
            _uutList.RemoveItem(index);
            expectedItems.RemoveAt(index);
            List<ToDoItem> actualItems = GetAllItemsFromList(_uutList);
            //Assert
            Assert.Equal(expectedItems, actualItems);
        }

        [Fact]
        public void ShouldReturnEntireList()
        {
            //Arrange
            List<ToDoItem> expectedItems = PopulateList(5);
            BulkAddItems(_uutList, expectedItems);
            //Act
            List<ToDoItem> actualItems = _uutList.GetEntireList();
            //Assert
            Assert.Equal(expectedItems,actualItems);
        }


        // Methods 
        private static ToDoItem GetNewItem(int index = 0)
        {
            return new ToDoItem($"Test Title{index}", "Test description.");
        }

        private static List<ToDoItem> PopulateList(int size)
        {
            List<ToDoItem> list = new List<ToDoItem>();
            for (int i = 0; i < size; i++)
            {
                list.Add(GetNewItem(i));
            }
            return list;
        }

        private static List<ToDoItem> GetAllItemsFromList(ToDoList list)
        {
            List<ToDoItem> allItems = new List<ToDoItem>();
            for (int i = 0; i < list.Count; i++)
            {
                allItems.Add(list.GetItem(i));
            }
            return allItems;
        }

        private static void BulkAddItems(ToDoList target, List<ToDoItem> input)
        {
            foreach (var item in input)
            {
                target.AddItem(item);
            }
        }
    }
}