using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BugTrackerContext context;

        public ProjectRepository(BugTrackerContext context)
        {
            this.context = context;
        }

        public IQueryable<Project> AllProjects => context.Projects;

        public async Task<Project> AddProjectAsync(Project project)
        {
            await context.AddAsync(project);
            return project;
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        public async Task<Project> DeleteProjectAsync(int projectId)
        {
            var project = await context.Projects.SingleOrDefaultAsync(p => p.Id == projectId);
            if (project != null)
            {
                context.Remove(project);
            }
            return project;
        }

        public Task<Project> GetProjectByIdAsync(int projectId)
        {
            return context.Projects.SingleOrDefaultAsync(p => p.Id == projectId);
        }

        public Project UpdateProject(Project project)
        {
            var entity = context.Attach(project);
            entity.State = EntityState.Modified;
            return project;
        }
    }
}
