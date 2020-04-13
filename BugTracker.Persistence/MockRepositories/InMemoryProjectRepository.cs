using System;
using System.Collections.Generic;
using System.Linq;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;

namespace BugTracker.Persistence
{
    public class InMemoryProjectRepository : IProjectRepository
    {
        public List<Project> projects;

        public InMemoryProjectRepository()
        {
            projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    Description = "Dummy project"
                },
                new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    Description = "Dummy project"
                }
            };
        }

        public IEnumerable<Project> AllProjects => projects;

        public Project AddProject(Project project)
        {
            project.Id = projects.Max(p => p.Id) + 1;
            projects.Add(project);
            return project;
        }

        public int Commit()
        {
            return 0;
        }

        public Project DeleteProject(int projectId)
        {
            var project = projects.SingleOrDefault(p => p.Id == projectId);
            if(project != null)
            {
                projects.Remove(project);
            }

            return project;
        }

        public Project GetProjectById(int projectId)
        {
            return projects.SingleOrDefault(p => p.Id == projectId);
        }

        public Project UpdateProject(Project project)
        {
            var projectToUpdate = projects.SingleOrDefault(p => p.Id == project.Id);
            if (projectToUpdate != null)
            {
                projectToUpdate.Name = project.Name;
                projectToUpdate.Description = project.Description;
            }

            return projectToUpdate;
        }
    }
}
