namespace BashSoftProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Launcher
    {
        public static void Main()
        {
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            IOManager.CreateDirectoryInCurentFolder("pesho");
            IOManager.TraverseDirectory(0);
        }
    }
}
