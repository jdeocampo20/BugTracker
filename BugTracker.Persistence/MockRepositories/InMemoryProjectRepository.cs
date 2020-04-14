using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<Project> AllProjects => projects.AsQueryable();

        public async Task<Project> AddProjectAsync(Project project)
        {
            await Task.Run(() =>
            {
                project.Id = projects.Max(p => p.Id) + 1;
                projects.Add(project);
            });
            return project;
        }

        public Task<int> CommitAsync()
        {
            return Task.Run(() => 0);
        }

        public async Task<Project> DeleteProjectAsync(int projectId)
        {
            var project = await Task.Run(() => projects.SingleOrDefault(p => p.Id == projectId));

            if (project != null)
            {
                await Task.Run(() => projects.Remove(project));
            }

            return project;
        }

        public Task<Project> GetProjectByIdAsync(int projectId)
        {
            return Task.Run(() => projects.SingleOrDefault(p => p.Id == projectId));
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
