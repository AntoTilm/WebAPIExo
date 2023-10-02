using Demo_01.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo_01.DAL.Repositories
{
    public class CourseRepository
    {
        #region Fake "DB" -> A remplacer par des vrais accès DB
        private static List<Course> _course = new List<Course>{
            new Course
            {
                Id = 1,
                Name = "C#",
                Description = "Cour C#",
            },
             new Course
            {
                Id = 2,
                Name = "Angular",
                Description = "Cour Angular",
            },
              new Course
            {
                Id = 3,
                Name = "Web API",
                Description = "Cour Web API",
            }
        };
        private static int NextId = 4;
        #endregion

        //CRUD :

        // CREATE
        public Course Create(Course course)
        {
            // Création du nouveau Cour à ajouter avec Id incrémenté par nous (à ne pas faire si vraie DB)
            Course courseToCreate = new Course
            {
                Id = NextId++,
                Name = course.Name,
                Description = course.Description
            };

            // Ajout dans la liste
            _course.Add(courseToCreate);

            // Renvoie du Cours
            return courseToCreate;
        }
        // READ
        public IEnumerable<Course> GetAll()
        {
            return _course.AsEnumerable(); //Pour transformer en IEnumerable la liste, on pourra la parcourir mais pas la modifier
        }

        public Course? GetById(int courseId)
        {
            // On renvoie le cour qui correspond à l'id / ! \ Peut être null si mauvais id
            return _course.SingleOrDefault(course => course.Id == courseId);
        }

        // UPDATE
        public bool Update(int courseId, Course course)
        {
            // On vérifie si le cour est présent 
            Course? courseToUpdate = _course.SingleOrDefault(course => course.Id == courseId);

            // Si pas -> Ca dégage
            if (courseToUpdate is null)
            {
                return false;
            }

            // Si présent, on le modifie et ouip
            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;

            return true;

        }

        // DELETE
        public bool Delete(int courseId)
        {
            // Voir si le cour est dans la liste
            Course? courseToDelete = _course.SingleOrDefault(course => course.Id == courseId);

            // Si pas de cours trouvé, on renvoie nope
            if (courseToDelete is null)
            {
                return false;
            }

            // Si cours Trouvé, on le dégage et on renvoie ouip
            _course.Remove(courseToDelete);
            return true;
        }


    }
}
