using System;
using System.Collections.Generic;
using BugTracker.Domain.Entities;

namespace BugTracker.Application.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> AllProjects { get; }

        Project AddProject(Project project);

        Project DeleteProject(int projectId);

        Project GetProjectById(int projectId);

        Project UpdateProject(Project project);

        int Commit();
    }
}
