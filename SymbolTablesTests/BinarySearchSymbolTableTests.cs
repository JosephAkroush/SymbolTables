using System.Collections.Generic;
using System.Linq;
using Domain;
using SymbolTables.BinarySearch;
using Xunit;

namespace SymbolTablesTests
{
    public class BinarySearchSymbolTableTests
    {
        [Fact]
        public void EmptyBinarySearchSizeShouldReturnZero()
        {
            // Arrange
            int capacity = 10;
            var target = new BinarySearchSymbolTable<SocialSecurityNumber, Person>(capacity);
            int expected = 0;

            // Act
            int actual = target.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddingItemsShouldReflectCorrectSize()
        {
            // Arrange
            int capacity = 10;
            var target = new BinarySearchSymbolTable<SocialSecurityNumber, Person>(capacity);

            SocialSecurityNumber ssn1 = new SocialSecurityNumber("555", "22", "3333");
            SocialSecurityNumber ssn2 = new SocialSecurityNumber("111", "33", "4444");

            Person person1 = new Person("John", "Doe");
            Person person2 = new Person("Jane", "Smith");

            int expected = 2;

            // Act
            target.Put(ssn1, person1);
            target.Put(ssn2, person2);

            int actual = target.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdatingItemShouldNotReturnDifferentSize()
        {
            // Arrange
            int capacity = 10;
            var target = new BinarySearchSymbolTable<SocialSecurityNumber, Person>(capacity);

            SocialSecurityNumber ssn1 = new SocialSecurityNumber("555", "22", "3333");
            SocialSecurityNumber ssn2 = new SocialSecurityNumber("111", "33", "4444");

            Person person1 = new Person("John", "Doe");
            Person person2 = new Person("Jane", "Smith");
            Person person3 = new Person("Tom", "Cruise");

            int expected = 2;

            // Act

            // Insert new items
            target.Put(ssn1, person1);
            target.Put(ssn2, person2);

            // Update ssn2 with a new person.
            target.Put(ssn2, person3);

            int actual = target.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertedItemKeysShouldBeReturnedWhenKeysIsCalled()
        {
            // Arrange
            int capacity = 10;
            var target = new BinarySearchSymbolTable<SocialSecurityNumber, Person>(capacity);

            SocialSecurityNumber ssn1 = new SocialSecurityNumber("555", "22", "3333");
            SocialSecurityNumber ssn2 = new SocialSecurityNumber("111", "33", "4444");
            SocialSecurityNumber ssn3 = new SocialSecurityNumber("456", "12", "7890");

            Person person1 = new Person("John", "Doe");
            Person person2 = new Person("Jane", "Smith");
            Person person3 = new Person("Tom", "Cruise");

            IEnumerable<SocialSecurityNumber> expected = new[] { ssn1, ssn2, ssn3 };
            int expectedSize = 3;

            // Act

            // Insert new items
            target.Put(ssn1, person1);
            target.Put(ssn2, person2);
            target.Put(ssn3, person3);

            IEnumerable<SocialSecurityNumber> actual = target.Keys();
            int actualSize = target.Size();

            // Assert
            Assert.Equal(expectedSize, actualSize);
            Assert.True(actual.Count(x => x.SerialNumber.Equals("3333")) == 1);
            Assert.True(actual.Count(x => x.SerialNumber.Equals("4444")) == 1);
            Assert.True(actual.Count(x => x.SerialNumber.Equals("7890")) == 1);
        }

        [Fact]
        public void DeleteShouldReflectInKeysAndSize()
        {
            // Arrange
            int capacity = 10;
            var target = new BinarySearchSymbolTable<SocialSecurityNumber, Person>(capacity);

            SocialSecurityNumber ssn1 = new SocialSecurityNumber("555", "22", "3333");
            SocialSecurityNumber ssn2 = new SocialSecurityNumber("111", "33", "4444");
            SocialSecurityNumber ssn3 = new SocialSecurityNumber("456", "12", "7890");

            Person person1 = new Person("John", "Doe");
            Person person2 = new Person("Jane", "Smith");
            Person person3 = new Person("Tom", "Cruise");

            int expectedSize = 0;

            // Act

            // Insert new items
            target.Put(ssn1, person1);
            target.Put(ssn2, person2);
            target.Put(ssn3, person3);

            target.Delete(ssn3);
            target.Delete(ssn1);
            target.Delete(ssn2);

            IEnumerable<SocialSecurityNumber> actualKeys = target.Keys();
            int actualSize = target.Size();

            // Assert
            Assert.Null(actualKeys);
            Assert.Equal(expectedSize, actualSize);
        }
    }
}