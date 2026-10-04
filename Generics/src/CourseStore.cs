using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
 
        public class CourseStore
        {
            private readonly List<Course> courses = new();
            public void Add(Course course)
            {
                courses.Add(course);
            }
            public Course? GetById(int id)
            {
                foreach (var course in courses)
                {
                    if (course.Id == id)
                    {
                        return course;
                    }
                }

                return null;
            }

            public List<Course> GetAll()
            {
                return courses;
            }
            public bool Remove(int id)
            {
                var course = GetById(id);
                if (course != null)
                {
                    return courses.Remove(course);
                }
                return false;
            }
        }
    

}

