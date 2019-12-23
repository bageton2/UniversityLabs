using NUnit.Framework;
using Practice3_1;
using System;

namespace Practice3_1Tests
{
    public class StudentTests
    {
        Student student1;
        Student student2;

        [SetUp]
        public void Initialize()
        {
            DateTime testDate = DateTime.Today;
            student1 = new Student("Jordan", "Math", 20, testDate);
            student2  = new Student("Jordan", "Math", 10, testDate);
        }

        [Test]
        public void InitializeStudent_WithValidTestData_ShouldNotThrowAnyExeption()
        {
            //arrange

            string studentName = "Jordan";
            string testName = "Math";
            int testScore = 20;
            DateTime testDate = DateTime.Today.AddDays(-2);

            // act

            Student student = new Student(studentName, testName, testScore, testDate);

            //assert

            Assert.Pass("No exeption was thrown!");
        }

        [Test]
        public void InitializeStudent_WithInvalidTestDate_ShouldThrowArgumentExeption()
        {
            //arrange

            string studentName = "Jordan";
            string testName = "Math";
            int testScore = 20;
            DateTime testDate = DateTime.Today.AddDays(1);

            // act

            Assert.Throws<ArgumentException>(() => new Student(studentName, testName, testScore, testDate));
        }

        [Test]
        public void InitializeStudent_WithInvalidTestScore_ShouldThrowArgumentExeption()
        {
            //arrange

            string studentName = "Jordan";
            string testName = "Math";
            int testScore = -20;
            DateTime testDate = DateTime.Today;

            //assert
            Assert.Throws<ArgumentException>(() => new Student(studentName, testName, testScore, testDate));
        }

        [Test]
        public void CompareTo_TwoDifferentStudents_FirstIsGreaterThanSecond()
        {
            //assert

            Assert.Greater(student1, student2);
        }

        [Test]
        public void ToString_Student_ShouldRepresendStudentAsNameAndScore()
        { 
            string studentString = student1.ToString();

            //assert

            Assert.AreEqual(studentString, student1.Name + ' '+ student1.TestScore);
        }
    }
}
