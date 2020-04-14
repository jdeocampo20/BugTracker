using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface IProjectRepository
    {
        IQueryable<Project> AllProjects { get; }

        Task<Project> AddProjectAsync(Project project);

        Task<Project> DeleteProjectAsync(int projectId);

        Task<Project> GetProjectByIdAsync(int projectId);

        Project UpdateProject(Project project);

        Task<int> CommitAsync();
    }
}
