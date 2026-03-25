namespace sim_cs_practicals.practical4
{
    class Program
    {
        public static void Main(String[] args)
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

                    Console.Write("\n1. Aggregate Marks\n2. MinMark\n3. Maximum Mark\n4. Grade\nEnter your choice from above menu (enter only numbers from 1 to 4): ");

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
