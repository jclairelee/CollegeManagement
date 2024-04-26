// This C# console application provides a menu-driven interface for managing students, professors, and class enrollments. 
// Users can perform actions such as adding/viewing students or professors, enrolling students in classes, and viewing class enrollments.

using System.Text.RegularExpressions;

namespace CollegeManagementSystem
{   
    // Class representing a course
    public class Course
    {
        // Properties
        public string CourseCode { get; set; } // Code of the course
        public string CourseName { get; set; } // Name of the course
        public string CourseSchedule { get; set; } // Schedule of the course
        public List<Professor> AssignedProfessors { get; } // Professors teaching the course 
        public List<Student> EnrolledStudents { get; } // List of students enrolled in the course

        // Constructor
        public Course(string courseCode, string courseName, string courseSchedule, List<Professor>? professors = null, List<Student>? students = null)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseSchedule = courseSchedule;
            AssignedProfessors = professors ?? new List<Professor>();
            EnrolledStudents = students ?? new List<Student>();
        }

        // Method to enroll a student
        public void AddStu(Student student)
        {
            EnrolledStudents.Add(student);
        }

        // Method to remove a student from enrollment
        public void RemoveStu(Student student)
        {
            EnrolledStudents.Remove(student); 
        }
    
        // Overriding ToString method to provide a string representation of a course
        public override string ToString()
        {
            string enrolledStudentsNames = string.Join(", ", EnrolledStudents.Select(student => student.LastName));
            return $"Course Code: {CourseCode}, Name: {CourseName}, Schedule: {CourseSchedule}, Professor: {AssignedProfessors}, Enrolled Students: {enrolledStudentsNames}";
        }
    }

    // Class representing a student
    public class Student
    {
        // Private fields to store student ID and last assigned student ID
        private int stuID;
        private static int lastStuID = 0;

        // Properties for encapsulation
        public int StuID {get { return stuID; }} // Student ID
        public string FirstName { get; set; } 
        public string LastName { get; set; }    
        public List<string> EnrolledIn { get; } // List of courses enrolled in by course code

        // Constructor
        public Student(string firstName, string lastName)
        {
            stuID = ++lastStuID;
            FirstName = firstName;
            LastName = lastName;
            EnrolledIn = new List<string>();
        }

        // Method to enroll in a class
        public void EnrollClass(string courseCode)
        {
            EnrolledIn.Add(courseCode);
        }

        // Method to remove a class from enrolledClasses
        public void DropClass(string courseCode)
        {
            EnrolledIn.Remove(courseCode);
        }

        // Overriding ToString method to provide a string representation of a student
        public override string ToString()
        {
            string enrolledClasses = string.Join(", ", EnrolledIn);
            string formattedName = char.ToUpper(FirstName[0]) + FirstName.Substring(1).ToLower() + " " + char.ToUpper(LastName[0]) + LastName.Substring(1).ToLower();
            return $"Student ID: {StuID}, Full Name: {formattedName}, Enrolled Classes: {enrolledClasses}";
        }
    }
    public class Professor
{
    private static int lastProfID = 0;
    private int profID;

    // Properties
    public int ProfID { get { return profID; } } 
    public string FirstName { get; set; } 
    public string LastName { get; set; }    
    public List<string> TeachingClasses { get; } // List of course codes taught by the professor

    // Constructor
    public Professor(string firstname, string lastname)
    {
        profID = ++lastProfID;
        FirstName = firstname;
        LastName = lastname;
        TeachingClasses = new List<string>();
    }

    // Method to assign a class to the professor
    public void AssignClass(string courseCode)
    {
        TeachingClasses.Add(courseCode);
    }
    // Method to un-assign a class from the professor
    public void DropClass(string courseCode)
    {
        TeachingClasses.Remove(courseCode);
    }

    // Overriding ToString method to provide a string representation of a professor
    public override string ToString()
    {
        string classes = string.Join(", ", TeachingClasses);
        string formattedName = char.ToUpper(FirstName[0]) + FirstName.Substring(1).ToLower() + " " + char.ToUpper(LastName[0]) + LastName.Substring(1).ToLower();
        return $"Professor ID: {ProfID}, First Name: {formattedName}, Teaching Classes: {classes}";
    }
}

    class Program
    {
        // Array to store students
        public static Student[] students = new Student[3000];

        // Array to store professors
        public static Professor[] professors = new Professor[500];

        // 2D array to store courses
        public static Course[,] courses = new Course[30, 5];


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Group 123's College Management System!");
            // Create default students
            students[0] = new Student("alya", "smith");
            students[1] = new Student("rob", "johnson");
            students[2] = new Student("alexa", "willson");
            students[3] = new Student("ellie", "gomez");
            students[4] = new Student("jiuliana", "hometa");
            students[5] = new Student("sandra", "white");
            students[6] = new Student("jack", "miller");
            students[7] = new Student("lucy", "davis");
            students[8] = new Student("max", "thompson");
            students[9] = new Student("emma", "martinez");
            students[10] = new Student("ryan", "lee");


            // All students enroll in a class using the EnrollStu() method, and then they are added to the enrolledIn list on the student side.
            // Create default professors
            professors[0] = new Professor("ben", "miller");
            professors[1] = new Professor("ali", "chiang");
            professors[2] = new Professor("isabella", "taylor");
            professors[3] = new Professor("jaehee", "kim");
            professors[4] = new Professor("kimberly", "tang");

            // Define and initialize courses

            // Math
            courses[0, 0] = new Course("MAT001", "Mathematics", "Mon/Wed/Fri 9:00 AM - 10:30 AM");
            courses[0, 1] = new Course("MAT002", "Calculus1", "Mon/Wed/Fri 10:45 AM - 12:15 PM");
            courses[0, 2] = new Course("MAT003", "Calculus2", "Tue/Thu 9:00 AM - 10:30 AM");
            courses[0, 3] = new Course("MAT004", "Programming Math", "Tue/Thu 10:45 AM - 12:15 PM");
            // English
            courses[1, 0] = new Course("ENG001", "English", "Mon/Wed/Fri 11:00 AM - 12:30 PM");
            courses[1, 1] = new Course("ENG002", "American Literature", "Tue/Thu 1:00 PM - 2:30 PM");
            courses[1, 2] = new Course("ENG003", "Creative Writing", "Mon/Wed 3:00 PM - 4:30 PM");
            courses[1, 3] = new Course("ENG004", "Shakespeare Studies", "Tue/Thu 9:00 AM - 10:30 AM");
            // Physics
            courses[2, 0] = new Course("PHY001", "Physics", "Tue/Thu 1:00 PM - 2:30 PM");
            courses[2, 1] = new Course("PHY002", "Quantum Mechanics", "Mon/Wed/Fri 9:00 AM - 10:30 AM");
            courses[2, 2] = new Course("PHY003", "Astrophysics", "Tue/Thu 11:00 AM - 12:30 PM");
            courses[2, 3] = new Course("PHY004", "Thermodynamics", "Mon/Wed/Fri 1:00 PM - 2:30 PM");
            // Chemistry
            courses[3, 0] = new Course("CHE001", "Chemistry", "Mon/Wed/Fri 9:00 AM - 10:30 AM");
            courses[3, 1] = new Course("CHE002", "Organic Chemistry", "Tue/Thu 10:45 AM - 12:15 PM");
            courses[3, 2] = new Course("CHE003", "Analytical Chemistry", "Mon/Wed/Fri 11:00 AM - 12:30 PM");
            courses[3, 3] = new Course("CHE004", "Biochemistry", "Tue/Thu 9:00 AM - 10:30 AM");
            // History 
            courses[4, 0] = new Course("HIS001", "History", "Mon/Wed/Fri 11:00 AM - 12:30 PM");
            courses[4, 1] = new Course("HIS002", "World History", "Tue/Thu 1:00 PM - 2:30 PM");
            courses[4, 2] = new Course("HIS003", "Ancient Civilizations", "Mon/Wed/Fri 9:00 AM - 10:30 AM");
            courses[4, 3] = new Course("HIS004", "European History", "Tue/Thu 10:45 AM - 12:15 PM");

            professors[0].AssignClass("MAT001");
            professors[1].AssignClass("ENG001");
            professors[2].AssignClass("PHY001");
            professors[3].AssignClass("HIS002");
            courses[0,0].AddStu(students[0]);
            courses[0,1].AddStu(students[1]);
            courses[0,2].AddStu(students[2]);
            courses[0,2].AddStu(students[3]);
            courses[1,1].AddStu(students[4]);
            courses[2,1].AddStu(students[5]);
            courses[3,2].AddStu(students[6]);
            courses[4,1].AddStu(students[7]);

            IsMainMenu();

            Console.WriteLine("Thank you for using our application. Goodbye!");
        }

        // Main menu
        static void IsMainMenu()
        {
            DisplayMainMenu();
            ProcessMainMenu(GetUserChoice());
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\n >>>>>>>>>>>>>>>>>>> MENU <<<<<<<<<<<<<<<<<< ");
            Console.WriteLine("1) Add New Student");
            Console.WriteLine("2) Add New Professor");
            Console.WriteLine("3) View All Students");
            Console.WriteLine("4) View All Professors");
            Console.WriteLine("5) Enroll Student in a Class");
            Console.WriteLine("6) View Class Enrollment List");
            Console.WriteLine("7) Exit Program");
            Console.WriteLine(" >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ");
            Console.Write("Please enter your choice: ");
        }

        static int GetUserChoice()
        {
            string? userInput = Console.ReadLine();
             // Validate and parse user input
            if (!int.TryParse(userInput, out int choice))
            {
                
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("  You've entered an invalid option. Please enter a valid number.");
                Console.WriteLine("--------------------------------------------------------------------");

                return GetUserChoice();
            }
            // Recursively ask again for user input if invalid
            return choice;
        }

        static void ProcessMainMenu(int menuSelected)
        {
            switch (menuSelected)
            {
                case 1:
                // Execute the method to add a new student
                AddNewStu();        
                IsSubMenu(AddNewStu);
                break;
            case 2:
                // Execute the method to add a new professor
                AddNewProf();
                IsSubMenu(AddNewProf);
                break;
            case 3:
                // Execute the method to view all students
                ViewAllStu();
                
                IsSubMenu(AddNewStu);
                break;
            case 4:
                // Execute the method to view all professors
                ViewAllProf();
                IsSubMenu(AddNewProf);
                break;
            case 5:
                // Execute the method to enroll a student in a class
                EnrollStuInClass();
                IsSubMenu(EnrollStuInClass);
                break;
            case 6:
                // Execute the method to view students in a class
                ViewStuInClass();
                IsSubMenu(EnrollStuInClass);
                break;
            case 7:
                // Exit the program
                Console.WriteLine("Exiting the program..");
                break;
            default:
                // Prompt the user for a valid menu choice if an invalid option is selected
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("  ----- You've selected an invalid option. Please try again. -----");
                Console.WriteLine("---------------------------------------------------------------");

                // Process user input again
                ProcessMainMenu(GetUserChoice());
                break;
            }
        }

        // Method to display a submenu based on the current action2
        static void IsSubMenu(Action current)
        {
            // Prompt the user to enter their choice
            Console.WriteLine("Please enter your choice:");

            // Get the name of the current method
            string currentMethod = current.Method.Name;

            // Check if the method name is at least 3 characters long
            if (currentMethod.Length >= 3)
            {
                // Get the last three characters of the method name
                string lastThreeChars = currentMethod.Substring(currentMethod.Length - 3);

                // Check if the method name ends with "Stu"
                if (lastThreeChars == "Stu")
                {
                    // Display options for adding/viewing students
                    Console.WriteLine("1. Add More Student");
                    Console.WriteLine("2. View All Students");
                }
                // Check if the method name ends with "rof"
                else if (lastThreeChars == "rof")
                {
                    // Display options for adding/viewing professors
                    Console.WriteLine("1. Add More Professor");
                    Console.WriteLine("2. View All Professors");
                }
                else
                {
                    // Display options for enrolling students or viewing class enrollment
                    Console.WriteLine("1. Enroll Student in a Class   → Requires student names and course code.");
                    Console.WriteLine("2. View Class Enrollment List  → Enter course code to see enrolled students.");
                }
            }
            else
            {
                // Inform the user if the method name is too short to determine its purpose
                Console.WriteLine("The function name is too short to determine its ending");
            }

            // Display options to go back to the main menu or end the program
            Console.WriteLine("3. Go back to the main menu");
            Console.WriteLine("4. End the program");

            // Process the user's submenu choice
            int choice = GetUserChoice();
            if (choice == 4)
            {
                // Exit the program if the user chooses option 4
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                // Process the submenu choice
                ProcessSubMenu(choice, current);
            }
        }
 
        static void ProcessSubMenu(int selected, Action current)
        {
            switch (selected)
            {
                case 1:
                    // Execute the current action (e.g., AddNewStu) based on user choice
                    current();
                    // Display the submenu relevant to the current action
                    IsSubMenu(current);
                    break;

                case 2:
                    // Extract the name of the current method being executed
                    string currentMethod = current.Method.Name;

                    // Check if the method name is long enough to determine its type
                    if (currentMethod.Length >= 3)
                    {
                        // Extract the last three characters of the method name
                        string lastThreeChars = currentMethod.Substring(currentMethod.Length - 3);

                        // Check if the method is related to students
                        if (lastThreeChars == "Stu")
                        {
                            // View all students
                            ViewAllStu();
                            // Display the submenu relevant to adding a new student
                            IsSubMenu(AddNewStu);
                        }
                        // Check if the method is related to professors
                        else if (lastThreeChars == "rof")
                        {
                            // View all professors
                            ViewAllProf();
                            // Display the submenu relevant to adding a new professor
                            IsSubMenu(AddNewProf);
                        }
                        // If neither related to students nor professors, assume it's related to class enrollment
                        else
                        {
                            // View students in a class
                            ViewStuInClass();
                            // Display the submenu relevant to enrolling a student in a class
                            IsSubMenu(EnrollStuInClass);
                        }
                    }
                    // If the method name is too short to determine its type
                    else
                    {
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine("  The function name is too short to determine its ending");
                        Console.WriteLine("---------------------------------------------------------------");
                    }
                    break;

                case 3:
                    // Navigate back to the main menu
                    IsMainMenu();
                    break;

                case 4:
                    // Exit the program
                    Console.WriteLine("Exiting the program..");
                    Environment.Exit(0);
                    break;

                default:
                    // If an invalid option is selected, prompt the user to try again
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("  You've selected an invalid option. Please try again.");
                    Console.WriteLine("--------------------------------------------------------");
                    // Process user input again
                    ProcessSubMenu(GetUserChoice(), current);
                    break;
            }
        }

        // Main Menu Option 1: Add New Student
        static void AddNewStu()
        {
            // Prompt the user to enter the student's full name
            Console.WriteLine("Enter the student's first name and last name separated by a space. (e.g., Kaila Lee) ");
            Console.Write("Student Full Name: ");
            string? fullname = Console.ReadLine()?.ToLower();
            if(ValidateInputVal(fullname))
            {
                // Split the full name into first and last names
                string[] nameSplited = fullname.Split(" ");
                string firstN = nameSplited[0];
                string lastN = nameSplited[1];

                // Find the next available index for a student in the students array
                int nextIndex = -1;
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i] == null)
                    {
                        nextIndex = i;
                        break;
                    }
                }

                // Check if there is an available index for adding a new student
                if (nextIndex != -1)
                {   
                    // Create a new student object and add it to the array at the next available index
                    students[nextIndex] = new Student(firstN, lastN);
                    Console.WriteLine();
                    Console.WriteLine("****************************************************");
                    Console.WriteLine($"  ** {fullname} is successfully added as a student. **");
                    Console.WriteLine("****************************************************");
                    Console.WriteLine();
                }
                else
                {
                    // Inform the user that the student list is full and cannot add a new student
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("  The student list is full. Cannot add a new student.");
                    Console.WriteLine("--------------------------------------------------");
                }
                // Ask the user if they want to enroll the student in a class
                Console.WriteLine($"Do you want to enroll {fullname} to a class? (Y/N) ");
                Console.Write($"Your choice: ");
                string? input = Console.ReadLine();
                
                // If the user wants to enroll the student, proceed to enrollment process
                if (input == "Y" || input == "y")
                {
                    EnrollStudentInCourse(FindStudentByName(firstN, lastN));
                }
                else
                {
                    // If the user does not want to enroll the student, provide options to repeat the task or go back to the main menu
                    IsSubMenu(AddNewStu);
                }
            }
 

            
        }
        // Main Menu Option 2
        static void AddNewProf()
        {
            Console.WriteLine("Enter the Professor's first and last name separated by a space (e.g., Jim Smith) ");
            Console.Write("Professor full name:  ");
           
            string? fullname = Console.ReadLine()?.ToLower();
            if(ValidateInputVal(fullname))
            {
                string[] nameSplited = fullname.Split(" ");

                string firstN = nameSplited[0];
                string lastN = nameSplited[1];
            
                if(firstN != null)
                {   
                    // Find the next available index for a student in the students array
                    int nextIndex = -1;
                    for (int i = 0; i < professors.Length; i++)
                    {
                        if (professors[i] == null)
                        {
                            nextIndex = i;
                            break;
                        }
                    }

                    // Check if there is an available index for adding a new student
                    if (nextIndex != -1)
                    {
                        // Create a new student object and add it to the array at the next available index
                        professors[nextIndex] = new Professor(firstN, lastN);
                        Console.WriteLine("*************************************************************");
                        Console.WriteLine($"     ** {firstN} {lastN} is successfully added as a professor.  **");
                        Console.WriteLine("*************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("  The professor list is full. Cannot add a new professor.");
                        Console.WriteLine("--------------------------------------------------------");
                    }
                    List<string> validCodes = new List<string>();
                    string inputTeachingCode;
                    string[] inputCodes;
                    do
                    {
                        Console.Write("Enter the course codes that this professor teaches (separated by comma, space, or semicolon): ");
                        inputTeachingCode = Console.ReadLine().ToUpper();

                        // Split the input string by comma, space, or semicolon
                        inputCodes = inputTeachingCode.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        validCodes.Clear(); // Clear previous invalid codes

                        foreach (string code in inputCodes)
                        {
                            if (ValidateCourseCode(code))
                            {
                                validCodes.Add(code);
                            }
                            else
                            {
                                Console.WriteLine("--------------------------------------------------------");
                                Console.WriteLine("        Invalid input. Please try again. ");
                                Console.WriteLine("--------------------------------------------------------");
                                break; // Break out of the foreach loop and re-prompt for input
                            }
                        }
                    } while (validCodes.Count != inputCodes.Length); // Repeat until all input codes are valid

    
                        // Enroll the student in each course
                        foreach (string code in validCodes)
                        {
                            if (inputTeachingCode != null)
                            {
                            
                                professors[nextIndex].AssignClass(code);
                                int rowIndex = -1;  
                                string department = code.Substring(0,3);
                                switch (department)
                                {
                                    case "MAT":
                                        rowIndex = 0;
                                        break;
                                    case "ENG":
                                        rowIndex = 1;
                                        break;
                                    case "PHY":
                                        rowIndex = 2;
                                        break;
                                    case "CHE":
                                        rowIndex = 3;
                                        break;
                                    case "HIS":
                                        rowIndex = 4;
                                        break;
                                    default:
                                        // Handle invalid department
                                        Console.WriteLine($"Invalid department for course code {code}.");
                                        continue; 
                                }
                                // Get the last three characters of the course code. This represents department that the course offers.
                                string lastThreeCharacters = code.Substring(code.Length - 3); 

                                // Parse the last three characters into an integer
                                int colIndex = int.Parse(lastThreeCharacters);

                                courses[rowIndex, colIndex].AssignedProfessors.Add(professors[nextIndex]);
                                
                                Console.WriteLine("*************************************************************************");
                                Console.WriteLine($"     ** {code} is successfully assigned to the professor {fullname}  **");
                                Console.WriteLine("*************************************************************************");
                            }
                         }
                    
                };
            
                IsSubMenu(AddNewProf);
            }
        }
        // Main Menu Option 3
        static void ViewAllStu()
        {
           Console.WriteLine("                 >>>>>>>>> Students List <<<<<<<<< ");

            foreach (var student in students)
            {
                if (student != null)
                {   
                    Console.WriteLine(student);}
                    
            }
        }
         // Main Menu Option 4
        static void ViewAllProf()
        {
            Console.WriteLine("                 >>>>>>>>> Professor List <<<<<<<<< ");

            foreach (var professor in professors)
            {
                if (professor != null)
                    Console.WriteLine(professor);
            }
        }
            
        static string[] GetCourseCodesFromInput()
        {
            Console.Write("Enter the course codes for the courses that the student is enrolled in (separated by comma, space, or semicolon): ");
            string? inputCode = Console.ReadLine().ToUpper();

            // Split the input string by comma, space, or semicolon
            string[] courseCodes = inputCode.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

            return courseCodes;
        }

        // Method to get student information from user input
        static Student GetStudentInfoFromInput()
        {
            // Prompt the user to enter the student's full name or ID
            Console.Write("Enter the student's full name, with the first name and last name separated by a space Or student ID instead: ");

            // Read user input
            string? userInput = Console.ReadLine();
            string stuName;
            bool isNumber;
            Student? student;

            // Check if the input can be parsed as an integer (student ID)
            if (int.TryParse(userInput, out int stuID))
            {
                isNumber = true;
            }
            else
            {
                isNumber = false;
            }

            // Check if the input is a number (student ID) or a full name
            if (!isNumber && userInput.Contains(' '))
            {
                // Split the full name into first name and last name
                stuName = userInput;

                string[] nameParts = stuName.Split(" ");

                string firstName = nameParts[0];
                string lastName = nameParts[1]; 

                // Find the student by their first name and last name
                student = FindStudentByName(firstName, lastName);
            } 
            else
            {
                // Find the student by their ID
                student = FindStudentByID(stuID);
            }
            
            return student;
        }

        // Method to enroll a student in a course
        static void EnrollStudentInCourse(Student student)
        {
            // Get course codes from user input
            string[] courseCodes = GetCourseCodesFromInput();

            // Enroll the student in each course
            foreach (string code in courseCodes)
            {
                // Find the course by its code
                Course? course = FindCourseByCode(code);
                if (course != null)
                {
                    // Enroll the student in the course
                    student.EnrollClass(code);
                    // Add the student to the list of enrolled students for the course
                    course.EnrolledStudents.Add(student);
                    
                    // Print enrollment confirmation message
                    Console.WriteLine("***************************************************************************************************************");
                    Console.WriteLine($"  ** {student.FirstName} {student.LastName} (ID: {student.StuID}) successfully enrolled in course {code}. **");
                    Console.WriteLine("***************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine($"Course {code} not found.");
                }
            }
        }

        // Method to enroll a student in a class (main menu option)
        static void EnrollStuInClass()
        {
            // Get student information from user input
            Student? student = GetStudentInfoFromInput();

            // Check if the student exists
            if (student == null)
            {
                Console.WriteLine($"Student not found.");
                return;
            }

            // Enroll the student in courses
            EnrollStudentInCourse(student);
        }


        // Main Menu Option 6
        // Method to view students enrolled in a specific class
        static void ViewStuInClass()
        {        
            Console.Write("Enter course code: ");
            string classCode = Console.ReadLine().ToUpper();
            if (classCode != null)
            {
                // Find the course by its code
                Course course = FindCourseByCode(classCode);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                // Display the list of students enrolled in the course
                Console.WriteLine("\n************************************************************");
                //     foreach (var student in course.EnrolledStudents)
                // {
                //     Console.Write($"{student.FirstName} {student.LastName} ");
                // }
                if (course.EnrolledStudents != null)
                {
                    if (course.EnrolledStudents.Count == 1)
                    {
                        // If there is only one student enrolled
                        Console.WriteLine($"\n   ** Only one student enrolled: {course.EnrolledStudents[0].FirstName} {course.EnrolledStudents[0].LastName}");
                    }
                    else if (course.EnrolledStudents.Count > 1)
                    {
                        // If there are more than one students enrolled
                        Console.WriteLine($"   ** {course.EnrolledStudents.Count} students enrolled in {classCode}");
                        foreach (var student in course.EnrolledStudents)
                        {
                            Console.Write($"\nFirst Name: {student.FirstName}, Last Name: {student.LastName} ");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        // If the list is empty         
                        Console.WriteLine($"\n   ** No students currently enrolled in {classCode} ");
                    }
                }
                
                Console.WriteLine("\n**************************************************************");

            
                Console.WriteLine();
            }
        }

        // Method to find a student by their ID
        static Student? FindStudentByID(int studentID)
        {
            foreach (var student in students)
            {
                if (student != null && student.StuID == studentID)
                    return student;
            }
            return null;
        }

        // Method to find a course by its code
        static Course? FindCourseByCode(string courseCode)
        {
            // Iterate through the courses array to find a course with the matching code
            foreach (var course in courses)
            {
                // Check if the current course exists and has the same course code as the one provided
                if (course != null && course.CourseCode == courseCode)
                    return course; // Return the course if found
            }
            return null; // Return null if no course with the provided code is found
        }

        // Method to find a student by their first name and last name
        static Student? FindStudentByName(string firstname, string lastname)
        {
            // Iterate through the students array to find a student with the matching first name and last name
            foreach (Student student in students)
            {
                // Check if the current student exists and has the same first and last name as the ones provided
                if (student != null && student.LastName == lastname && student.FirstName == firstname)
                {
                    return student; // Return the student if found
                }
            }
            return null; // Return null if no student with the provided name is found
        }

        // Method to validate input containing only letters
       static bool ValidateInputVal(string? userInput)
        {
            // Regular expression pattern to match only letters
            string pattern = @"^[a-zA-Z]+ [a-zA-Z]+$";

            // Check if the input string matches the pattern
            bool result = !string.IsNullOrEmpty(userInput) && Regex.IsMatch(userInput, pattern);

            // Print message indicating whether the input is valid or not
            if (result)
            {
                Console.WriteLine($"Input '{userInput}' is valid.");
            }
            else
            {
                // Print error message for invalid input
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("       ----- Invalid input. Please try again. -----");
                Console.WriteLine("--------------------------------------------------------------");
            }

            // Return true if input is valid, false otherwise
            return result;
        }
        static bool ValidateCourseCode(string inputTeachingCode)
        {
            // Regular expression pattern to match three letters followed by three numbers
            string pattern = @"^[A-Za-z]{3}\d{3}$";

            // Check if the input string matches the pattern
            bool isValid = Regex.IsMatch(inputTeachingCode, pattern);

            return isValid;
        }

    }
}