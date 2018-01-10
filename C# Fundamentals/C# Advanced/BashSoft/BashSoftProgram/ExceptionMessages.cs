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

        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist";

        public const string UnauthorizedAccessException = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch";

        public const string ForbiddenSymbolIsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string UnableToGoHigherInPartitionHierarchy = "It is not possible to go higher in the partition hierarchy";

        public const string UnableToParseNumber = "The sequence you've written is not a valid number";
    }
}
