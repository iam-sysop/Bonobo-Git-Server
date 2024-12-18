﻿using gitserverdotnet.Configuration;
using gitserverdotnet.Models;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace gitserverdotnet.Data.Update
{
    public class RepositorySynchronizer
    {
        IRepositoryRepository _repositoryRepository = DependencyResolver.Current.GetService<IRepositoryRepository>();

        public virtual void Run()
        {
            CheckForNewRepositories();
        }

        private void CheckForNewRepositories()
        {
            if (!Directory.Exists(UserConfiguration.Current.Repositories))
            {
                // We don't want an exception if the repo dir no longer exists, 
                // as this would make it impossible to start the server
                return;
            }
            IEnumerable<string> directories = Directory.EnumerateDirectories(UserConfiguration.Current.Repositories);
            foreach (string directory in directories)
            {
                string name = Path.GetFileName(directory);

                RepositoryModel repository = _repositoryRepository.GetRepository(name);
                if (repository == null)
                {
                    if (LibGit2Sharp.Repository.IsValid(directory))
                    {
                        repository = new RepositoryModel();
                        repository.Id = Guid.NewGuid();
                        repository.Description = "Discovered in file system.";
                        repository.Name = name;
                        repository.AnonymousAccess = false;
                        repository.Users = new UserModel[0];
                        repository.Teams = new TeamModel[0];
                        repository.Administrators = new UserModel[0];
                        if (repository.NameIsValid)
                        {
                            _repositoryRepository.Create(repository);
                        }
                    }
                }
            }
        }
    }
}
