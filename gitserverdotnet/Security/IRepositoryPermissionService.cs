using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gitserverdotnet.Models;

namespace gitserverdotnet.Security
{
    public enum RepositoryAccessLevel
    {
        /// <summary>
        /// User can read or clone a repository
        /// </summary>
        Pull,
        /// <summary>
        /// User can push to a repository
        /// </summary>
        Push,
        /// <summary>
        /// User can change repository settings
        /// </summary>
        Administer
    }

    public interface IRepositoryPermissionService
    {
        // Used by gitserver.net
        bool HasPermission(Guid userId, Guid repositoryId, RepositoryAccessLevel requiredLevel);
        bool HasCreatePermission(Guid userId);
        IEnumerable<RepositoryModel> GetAllPermittedRepositories(Guid userId, RepositoryAccessLevel requiredLevel);

        // Used by git clients as they don't have the GUID of the project
        bool HasPermission(Guid userId, string repositoryName, RepositoryAccessLevel requiredLevel);
    }
}