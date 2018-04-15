namespace BashSoftProgram.Exceptions
{
    using System;

    public class CourseNotFoundException:Exception
    {
        private const string CourseNotFound = "A course with the given name does not exist";

        public CourseNotFoundException()
            :base(CourseNotFound)
        {
        }

        public CourseNotFoundException(string message)
            :base(message)
        {
        }
    }
}
