namespace BashSoftProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message";

        public const string DataAlreadyInitializedExeption = "Data is already initialized";

        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make operations with it";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase = "The username for the student you are trying to get does not exist in the data base!";
    }
}
