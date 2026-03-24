namespace sim_cs_practicals.practical4
{
    class Student
    {
        public decimal[] Marks;
        public string Name { get; set; }

        public static decimal AverageMarks;

        public Student(string name, int subjectCount)
        {
            this.Name = name;
            this.Marks = new decimal[subjectCount];
        }

        /// <summary>
        /// This method will take input from user for getting the marks of subject and will return nothing.
        /// </summary>
        public void GetMarksFromUser()
        {
            for (int i = 0; i < this.Marks.Length; i++)
            {
                Console.Write($"Enter the marks for Subject {i + 1}: ");
                this.Marks[i] = Convert.ToDecimal(Console.ReadLine());
            }
        }


        /// <summary>
        /// This method will return a decimal value that will be aggregate / average marks of the student.
        /// </summary>
        public decimal CalculateAverageMarks()
        {
            return this.Marks.Sum() / this.Marks.Length;
        }


        /// <summary>
        /// This method will return a single character value which will be grade of the student.
        /// </summary>
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
}
