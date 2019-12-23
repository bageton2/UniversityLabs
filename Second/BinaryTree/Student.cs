using System;
using System.Collections.Generic;
using System.Text;

namespace Practice2_1
{
    class Student : IComparable
    {
        private string Name { get; set; }
        private string TestName { get; set; }
        private DateTime TestDate { get; set; }
        private double TestScore { get; set; }

        public Student(string Name, string TestName, double TestScore, DateTime TestDate)
        {
            this.Name = Name;
            this.TestName = TestName;
            this.TestScore = TestScore;
            this.TestDate = TestDate;
        }
        public int CompareTo(object obj)
        {
            Student student = obj as Student;
            if (student != null)
            {
                return this.TestScore.CompareTo(student.TestScore);
            }
                else throw new Exception("Невозможно сравнить два объекта");
        }
        public override string ToString()
        {
            return Name + " " + TestScore;
        }
    }
}
