namespace sim_cs_practicals
{
    class Practical4
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

            /*
             * This method will take input from user for getting the marks of subject and will return nothing.
             */
            public void GetMarksFromUser()
            {
                for (int i = 0; i < this.Marks.Length; i++)
                {
                    Console.Write($"Enter the marks for Subject {i + 1}: ");
                    this.Marks[i] = Convert.ToDecimal(Console.ReadLine());
                }
            }


            /*
             * This method will return a decimal value that will be aggregate / average marks of the student.
             */
            public decimal CalculateAverageMarks()
            {
                return this.Marks.Sum() / this.Marks.Length;
            }


            /*
             * This method will return a single character value which will be grade of the student.
             */
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
            string? name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                Console.Write("Enter total number of subjects: ");

                if (int.TryParse(Console.ReadLine(), out int noOfSub))
                {
                    Console.WriteLine();
                    Student stu = new Student(name, noOfSub);
                    stu.GetMarksFromUser();

                    Console.Write("\n1. Aggregate Marks\n2. MinMark\n3. Maximum Mark\n4. Grade\n5. Exit\nEnter your choice from above menu (enter only numbers from 1 to 4): ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine();

                        switch ((Options)choice)
                        {
                            case Options.Aggregate:
                                Console.WriteLine($"Aggregate marks of student {stu.Name} are {stu.CalculateAverageMarks()}");
                                break;

                            case Options.MinMark:
                                Console.WriteLine($"Minimum marks of student {stu.Name} are {stu.Marks.Min()}");
                                break;

                            case Options.MaximumMark:
                                Console.WriteLine($"Maximum marks of student {stu.Name} are {stu.Marks.Max()}");
                                break;

                            case Options.Grade:
                                Console.WriteLine($"Grade of student {stu.Name} is {stu.CalculateGrade()} with aggregate marks {stu.CalculateAverageMarks()}");
                                break;

                            default:
                                Console.WriteLine("Invalid input.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter only numbers from 1 to 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter only total number of subject.");
                }
            }
            else
            {
                Console.WriteLine("Name is required, it can not be empty.");
            }
        }
    }
}
