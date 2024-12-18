using System;
using gitserverdotnet.Data;
using gitserverdotnet.Models;
using gitserverdotnet.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gitserverdotnet.Test.MembershipTests.ADTests
{
    [TestClass]
    public class ADPermissionServiceTest : PermissionServiceTestBase
    {
        private ADTestSupport _testSupport;

        [TestInitialize]
        public void Initialize()
        {
            _testSupport = new ADTestSupport();
            InitialiseTestObjects();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testSupport.Dispose();
        }

        private void InitialiseTestObjects()
        {
            _roles = new ADRoleProvider();
            _teams = new ADTeamRepository();
            _users = new ADMembershipServiceTestFacade(new ADMembershipService(), _testSupport);
            _repos = new ADRepositoryRepository();

            _service = new RepositoryPermissionService
            {
                Repository = _repos, RoleProvider = _roles, TeamRepository = _teams
            };
        }

        protected override TeamModel CreateTeam()
        {
            var newTeam = new TeamModel { Name = "Team1", Id = Guid.NewGuid() };
            newTeam.Members = new UserModel[0];
            ADBackend.Instance.Teams.Add(newTeam);
            return newTeam;
        }

        protected override void UpdateTeam(TeamModel team)
        {
            ADBackend.Instance.Teams.AddOrUpdate(team);
        }
    }
}