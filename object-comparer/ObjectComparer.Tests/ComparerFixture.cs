using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        List<Student> studentS1 = new List<Student>();
        List<Student> studentS2 = new List<Student>();
        List<string> strings1 = new List<string>() { "new", "old" };
        List<string> strings2 = new List<string>() { "new", "old" };
        Student s1; Student s2; Student s3;

        public ComparerFixture()
        {
            Initialse();
        }
        public void Initialse()
        {
              s1 = new Student
            {
                Id = 1,
                Name = "Roger",
                Marks = new[] { 50, 40, 80 }
            };
             s2 = new Student
            {
                Id = 2,
                Name = "John",
                Marks = new[] { 10, 40, 90 }
            };
             s3 = new Student
            {
                Id = 1,
                Name = "Roger",
                Marks = new[] { 50, 80, 40 }
            };
            studentS1.Add(s1);
            studentS1.Add(s2);

            studentS2.Add(s1);
            studentS2.Add(s2);
        }

        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null;
            string second = null;
            
            Assert.IsTrue(Comparer.AreSimilar(first, second));           
        }
        [TestMethod]
        public void int_values_are_similar_test()
        {          

            int first = 8, second = 8,third = 9;
          
            Assert.IsTrue(Comparer.AreSimilar(first, second));
            Assert.IsFalse(Comparer.AreSimilar(first, third));
        }
        [TestMethod]
        public void string_values_are_similar_test()
        {

            string first = "Roger", second = "Roger", third = "John";

            Assert.IsTrue(Comparer.AreSimilar(first, second));
            Assert.IsFalse(Comparer.AreSimilar(first, third));
        }
        [TestMethod]
        public void Object_values_are_similar_test()
        {
            Assert.IsFalse(Comparer.AreSimilar(s1, s2));
            Assert.IsTrue(Comparer.AreSimilar(s1, s3));
            Assert.IsTrue(Comparer.AreSimilar(studentS1, studentS2));
            Assert.IsTrue(Comparer.AreSimilar(strings1, strings2));
        }
    }
}
