using System;

namespace sim_cs_practicals
{
    class Practical4
    {      
        class Student
        {
            public decimal[] Marks;
            public string Name { get; set; }

            public static decimal AverageMarks;

            public Student(string name, uint subjectCount)
            {
                this.Name = name;
                this.Marks = new decimal[subjectCount];
            }

            public void GetMarksFromUser()
            {
                for(int i = 0; i < this.Marks.Length; i++)
                {
                    Console.Write($"Enter the marks for Subject ${i + 1}: ");
                    this.Marks[i] = Convert.ToDecimal(Console.ReadLine());
                }
            }

            public decimal CalculateAverageMarks()
            {
                return this.Marks.Sum() / this.Marks.Length;
            }
            
            public char CalculateGrade()
            {
                decimal avg = this.CalculateAverageMarks();
                if (avg > 90)
                    return 'A';
                else if (avg > 80 && avg <= 90)
                    return 'B';
                else if (avg > 70 && avg <= 80)
                    return 'C';
                else
                    return 'D';
            }
        }

        enum Options
        {
            Aggregate = 1,
            MinMark = 2,
            MaximumMark = 3,
            Grade = 4
        }

        public static void main(String[] args)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            if(name != null)
            {
                Console.Write("Enter number of subjects: ");
                uint noOfSub = Convert.ToUInt16(Console.ReadLine());

                Student stu = new Student(name, noOfSub);
                stu.GetMarksFromUser();
            }
            else{
                Console.WriteLine("Name is required, it can not be empty.");
            }
        }
    }
}
