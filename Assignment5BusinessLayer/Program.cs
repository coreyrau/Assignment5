using System;
using Assignment5;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5BusinessLayer
{
    public class Program
    {
        public static BusinessLayer bl = new BusinessLayer();

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("\n-----Menu-----\nEnter 1 to Display all Courses\nEnter 2 to Display all Teachers\nEnter 3 to Display a Teacher with their classes\nEnter 4 to add a Course" +
                              "\nEnter 5 to add a Teacher\nEnter 6 to delete a Course\nEnter 7 to delete a Teacher\nEnter 8 to update a Course" +
                              "\nEnter 9 to update a Teacher");
            string entry = Console.ReadLine();

            switch (entry)
            {
                case "1":
                    DisplayCourses();
                    Menu();
                    break;
                case "2":
                    DisplayTeachers();
                    Menu();
                    break;
                case "3":
                    DisplayTeachersWithCourses();
                    break;
                case "4":
                    AddCourse();
                    Menu();
                    break;
                case "5":
                    AddTeacher();
                    Menu();
                    break;
                case "6":
                    RemoveCourse();
                    Menu();
                    break;
                case "7":
                    RemoveTeacher();
                    Menu();
                    break;
                case "8":
                    UpdateCourse();
                    Menu();
                    break;
                case "9":
                    UpdateTeacher();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Error Invalid Input");
                    Menu();
                    break;

            }
                
        }

        public static void DisplayCourses()
        {
            Console.WriteLine("\nDisplaying Courses ...");

            var clist = bl.GetAllCourses();
            foreach (var course in clist)
            {
                Console.Write("\n" + course.CourseId + " " + course.CourseName + " ");
                if (course.Teacher != null)
                {
                    Console.Write("\n\t"+course.Teacher.TeacherName + "\n");
                }
            }
        }

        public static void DisplayTeachers()
        {
            Console.WriteLine("\nDisplaying Teachers ...");

            var tlist = bl.GetAllTeachers();
            foreach (Teacher teach in tlist)
            {
                Console.Write("\n" + teach.TeacherId + " " + teach.TeacherName);
                var teachercourses = teach.Courses.ToList();
                foreach (var c in teachercourses)
                {
                    Console.Write("\n\t" + c.CourseName + "\n");
                }
            }
        }

        public static void DisplayTeachersWithCourses()
        {
            Console.WriteLine("Please enter the name or id of the Teacher or 'exit': ");
            string input = Console.ReadLine();
            int idnum = 0;
            try
            {
                idnum = Convert.ToInt32(input);
            }
            catch (Exception e)
            {
                //nothing
            }

            if (input == "exit")
            {
                Menu();
            }
            else if (idnum != 0)
            {
                if (bl.GetTeacherByID(idnum) != null)
                {
                    Teacher teach = bl.GetTeacherByID(idnum);
                    Console.WriteLine("\n" + teach.TeacherName + " " + teach.TeacherId);
                    foreach (var course in teach.Courses)
                    {
                        Console.WriteLine("\n\t" + course.CourseName + " " + course.CourseId);
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Teacher Does not Exist");
                }
            }
            else
            {
                if (bl.GetTeacherByName(input) != null)
                {
                    int num = bl.GetTeacherByName(input).TeacherId;
                    Teacher teach = bl.GetTeacherByID(num);
                    Console.WriteLine("\n" + teach.TeacherName + " " + teach.TeacherId);
                    foreach (var course in teach.Courses)
                    {
                        Console.WriteLine("\n\t" + course.CourseName + " " + course.CourseId);
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Teacher Does not Exist");
                }
            }
            Menu();
        }

        public static void AddCourse()
        {
            //add validation
            Console.WriteLine("\nEnter the name of the course you would like to add or enter 'exit':");
            string cname = Console.ReadLine();
            if (cname != null && cname!= "exit")
            {
                Course newcourse = new Course
                {
                    CourseName = cname,
                };

                bl.AddCourse(newcourse);
            }
            else if (cname == "exit")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Error: Null input");
                AddCourse();
            }
        }

        public static void RemoveCourse()
        {
            Console.WriteLine("\nEnter in the name or id of the course you wish to remove or enter 'exit':");
            string userinput = Console.ReadLine();
            int num = 0;

            try
            {
                num = Convert.ToInt32(userinput);
            }
            catch (Exception e)
            {
                //nothin
            }

            if (userinput == "exit")
            {
                Menu();
            }
            else if (num!= 0)
            {
                if (bl.GetCourseByID(num) != null)
                {
                    bl.RemoveCourse(bl.GetCourseByID(num));
                }
                else
                {
                    Console.WriteLine("\nError: Course Does Not Exist");
                    RemoveCourse();
                }
            }
            else
            {
                if (bl.GetCourseByName(userinput)!= null)
                {
                    int id = bl.GetCourseByName(userinput).CourseId;
                    bl.RemoveCourse(bl.GetCourseByID(id));
                }
                else
                {
                    Console.WriteLine("\nError: Course Does Not Exist");
                    RemoveCourse();
                }
            }

        }

        public static void UpdateCourse()
        {
            Console.WriteLine("\nEnter the name or id of the Course you wish to update or enter 'exit': ");
            string userinput = Console.ReadLine();
            int num = 0;

            try
            {
                num = Convert.ToInt32(userinput);
            }
            catch (Exception e)
            {
                //do nothin
            }

            if (userinput == "exit")
            {
                Menu();
            }
            else if (num != 0)
            {
                if (bl.GetCourseByID(num) != null)
                {
                    Console.WriteLine("\nEnter the Course's new name value: ");
                    string newname = Console.ReadLine();
                    bl.GetCourseByID(num).CourseName = newname;
                    bl.UpdateCourse(bl.GetCourseByID(num));
                }
                else
                {
                    Console.WriteLine("\nError: Course Does Not Exist");
                    UpdateCourse();
                }

            }
            else
            {
                if (bl.GetCourseByName(userinput) != null)
                {
                    Console.WriteLine("\nEnter the Teacher's new name value: ");
                    string newname = Console.ReadLine();
                    int id = bl.GetCourseByName(userinput).CourseId;
                    bl.GetCourseByID(id).CourseName = newname;
                    bl.UpdateCourse(bl.GetCourseByID(id));
                }
                else
                {
                    Console.WriteLine("\nError: Course Does Not Exist");
                    UpdateCourse();
                }
            }
        }

        public static void AddTeacher()
        {
            Console.WriteLine("\nEnter in the name of teacher you wish to add or 'exit': ");
            string tname = Console.ReadLine();
            if (tname != null && tname!= "exit")
            {
                Teacher newteach = new Teacher
                {
                    TeacherName = tname
                };
                bl.AddTeacher(newteach);
            }
            else if (tname == "exit")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Error: Null Input");
                AddTeacher();
            }
        }

        public static void RemoveTeacher()
        {
            Console.WriteLine("\nEnter in the name or id of the teacher you wish to remove or enter 'exit':");
            string userinput = Console.ReadLine();
            int num = 0;

            try
            {
                num = Convert.ToInt32(userinput);
            }
            catch (Exception e)
            {
                //do nothing
            }

            if (userinput == "exit")
            {
                Menu();
            }
            else if (num!=0)
            {
                if (bl.GetTeacherByID(num) != null)
                {
                    bl.RemoveTeacher(bl.GetTeacherByID(num));
                }
                else
                {
                    Console.WriteLine("\nError: Teacher Does Not Exist");
                    RemoveTeacher();
                }
            }
            else
            {
                if (bl.GetTeacherByName(userinput) != null)
                {
                    int id = bl.GetTeacherByName(userinput).TeacherId;
                    bl.RemoveTeacher(bl.GetTeacherByID(id));
                }
                else
                {
                    Console.WriteLine("\nError: Teacher Does Not Exist");
                    RemoveTeacher();
                }
            }
        }

        public static void UpdateTeacher()
        {
            Console.WriteLine("\nEnter the name or id of the Teacher you wish to update or enter 'exit': ");
            string userinput = Console.ReadLine();

            int num = 0;

            try
            {
                num = Convert.ToInt32(userinput);
            }
            catch (Exception e)
            {
                //nothin
            }

            if (userinput == "exit")
            {
                Menu();
            }

            else if (num != 0 && bl.GetTeacherByID(num) != null)
            {
                Console.WriteLine("\nEnter 1 to change the Teacher's name\nEnter 2 to add a new Course to Teacher\nEnter 3 to add an existing Course to Teacher");
                string secondinput = Console.ReadLine();

                if (secondinput == "1")
                {
                    Console.WriteLine("\nEnter the Teacher's new name value: ");
                    string newname = Console.ReadLine();
                    bl.GetTeacherByID(num).TeacherName = newname;
                    bl.UpdateTeacher(bl.GetTeacherByID(num));
                }
                else if (secondinput == "2")
                {
                    Console.WriteLine("Enter the name of the new course:");
                    string name = Console.ReadLine();
                    if (name != null && name != "exit")
                    {
                        Course temp = new Course
                        {
                            CourseName = name,
                        };
                        bl.GetTeacherByID(num).Courses.Add(temp);
                        bl.UpdateTeacher(bl.GetTeacherByID(num));
                    }
                    else if (name == "exit")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Error Invalid Input");
                        UpdateTeacher();
                    }
                }
                else if (secondinput == "3")
                {
                    Console.WriteLine("Enter the name or id of the existing course:");
                    string name = Console.ReadLine();
                    int idnum = 0;

                    try
                    {
                        idnum = Convert.ToInt32(name);
                    }
                    catch (Exception e)
                    {
                        //do nothin
                    }

                    if (idnum != 0 && bl.GetCourseByID(idnum) != null)
                    {
                        bl.GetTeacherByID(num).Courses.Add(bl.GetCourseByID(idnum));
                        bl.UpdateTeacher(bl.GetTeacherByID(num));

                    }
                    else if (name == "exit")
                    {
                        Menu();
                    }
                    else if (name != null && name != "exit" && bl.GetCourseByName(name) != null)
                    {
                        bl.GetTeacherByID(num).Courses.Add(bl.GetCourseByID(bl.GetCourseByName(name).CourseId));
                        bl.UpdateTeacher(bl.GetTeacherByID(num));
                    }
                    else
                    {
                        Console.WriteLine("Error Invalid Input");
                        UpdateTeacher();
                    }
                }
                else
                {
                    Console.WriteLine("Error Invalid Input");
                    UpdateTeacher();
                }
            }

            else if(bl.GetTeacherByName(userinput) != null)
            {

                Console.WriteLine("\nEnter 1 to change the Teacher's name\nEnter 2 to add a new Course to Teacher\nEnter 3 to add an existing Course to Teacher");
                string secondinput = Console.ReadLine();

                if (secondinput == "1")
                {
                    Console.WriteLine("\nEnter the Teacher's new name value: ");
                    string newname = Console.ReadLine();
                    int id = bl.GetTeacherByName(userinput).TeacherId;
                    bl.GetTeacherByID(id).TeacherName = newname;
                    bl.UpdateTeacher(bl.GetTeacherByID(num));
                }
                else if (secondinput == "2")
                {
                    Console.WriteLine("Enter the name of the new course:");
                    string name = Console.ReadLine();
                    if (name != null && name != "exit")
                    {
                        Course temp = new Course
                        {
                            CourseName = name,
                        };
                        int id = bl.GetTeacherByName(userinput).TeacherId;
                        bl.GetTeacherByID(id).Courses.Add(temp);
                        bl.UpdateTeacher(bl.GetTeacherByID(id));
                    }
                    else if (name == "exit")
                    {
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Error Invalid Input");
                        UpdateTeacher();
                    }
                }
                else if (secondinput == "3")
                {
                    Console.WriteLine("Enter the name or id of the existing course:");
                    string name = Console.ReadLine();
                    int idnum = 0;

                    try
                    {
                        idnum = Convert.ToInt32(name);
                    }
                    catch (Exception e)
                    {
                        //do nothin
                    }

                    if (idnum != 0 && bl.GetTeacherByName(userinput) != null)
                    {
                        int id = bl.GetTeacherByName(userinput).TeacherId;
                        bl.GetTeacherByID(id).Courses.Add(bl.GetCourseByID(idnum));
                        bl.UpdateTeacher(bl.GetTeacherByID(id));
                    }
                    else if (name == "exit")
                    {
                        Menu();
                    }
                    else if (name != null && name != "exit" && bl.GetTeacherByName(userinput) != null)
                    {
                        int id = bl.GetTeacherByName(userinput).TeacherId;
                        bl.GetTeacherByID(id).Courses.Add(bl.GetCourseByID(bl.GetCourseByName(name).CourseId));
                        bl.UpdateTeacher(bl.GetTeacherByID(id));
                    }
                    else
                    {
                        Console.WriteLine("Error Invalid Input");
                        UpdateTeacher();
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Invalid Input");
                    UpdateTeacher();
                }
            }
            else
            {
                Console.WriteLine("\nError: Teacher Does Not Exist");
                UpdateTeacher();
            }
            
        }
    }
}