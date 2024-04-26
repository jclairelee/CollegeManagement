# College Management System

**System Overview:**  
This College Management System facilitates the management of students, professors, and courses within a college or educational institution. It provides functionalities for adding, viewing, and managing students and professors, as well as enrolling students in courses.

**Approach:**

- **User Interface:** Implemented a user-friendly menu-driven interface to guide users through various operations.
- **Data Management:** Utilized 2D arrays to organize and manage student, professor, and course data efficiently.
- **Object-Oriented Programming:** Employed classes to represent students, professors, and courses, encapsulating relevant data and behavior.
- **Input Validation:** Implemented input validation to ensure the integrity of user inputs and prevent errors.
- **Error Handling:** Implemented error handling mechanisms to gracefully handle unexpected scenarios and provide informative feedback to users.

**Functionality:**

- Add New Student
- Add New Professor
- View All Students
- View All Professors
- Enroll Student in a Course
- View Students enrolled in a Course

**Compile the Code:**

To run the application, click the "Start" button in the toolbar at the top of the screen. This button is usually represented by a green triangle icon ▶️. Once the triangle button is clicked, you'll see two options:

1. Debug project associated with this file
2. Run project associated with this file

Click "run project associated with this file". Alternatively, you can press `F5` as a shortcut.

Visual Studio will automatically execute the compiled executable of your console application.

**Challenges Encountered and Solutions:**

- **Data Management:** Proper indexing and iteration techniques were employed to efficiently manage data using 2D arrays. Designing a 2D array layout was initially confusing.
- **Data Consistency:**
  The system employs careful logic to ensure seamless data communication across `students`, `courses`, and `professors`. Whenever one side of the record undergoes an update, the corresponding side is automatically synchronized to maintain consistency.

  - `course.EnrolledStudents` and `student.EnrolledIn` are maintained separately. Whenever new data is added to `course.EnrolledStudents`, the system automatically updates `student.EnrolledIn` to reflect the changes, ensuring consistency across records.

  - Both professors and courses are synchronized effortlessly. This is facilitated through `professors.TeachingClasses.Add` (utilizing the method named Assignclass) and `courses.AssignedProfessors.Add` (although no specific method is created). As a result, all data is consistently updated upon addition, providing users with uniform results regardless of the interface used.

** Contribution:**  
Claire Lee:
Developed the entire system, including the user interface, data management, input validation, error handling, functionality implementation, and documentation.
