using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src
{
    public class StudentStore
    {
       private readonly  List<Student> students =new();
       public void Add(Student student)
       {
            students.Add(student);
       }
        public Student? GetById(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student; 
                }
            }

            return null; 
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public bool Remove(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                return students.Remove(student); 
            }
            return false;
        }
    }
}
