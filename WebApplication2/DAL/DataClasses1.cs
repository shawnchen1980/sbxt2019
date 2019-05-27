namespace WebApplication2.DAL
{
    partial class CourseInstructor
    {
    }

    partial class Person 
    {
        public Person(Person np)
        {
            this.FirstName = np.FirstName;
            this.LastName = np.LastName;
            this.HireDate = np.HireDate;
            this.EnrollmentDate = np.EnrollmentDate;
            this.PersonID = np.PersonID;
            
        }
    }
}

