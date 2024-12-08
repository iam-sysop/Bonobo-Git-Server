using System;
using gitserverdotnet.Data;
using gitserverdotnet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gitserverdotnet.Test.MembershipTests.ADTests
{
    [TestClass]
    public class ADRepositoryRepositoryServiceTest : RepositoryRepositoryTestBase
    {
        private ADTestSupport _testSupport;

        [TestInitialize]
        public void Initialize()
        {
            _testSupport = new ADTestSupport();
            _repo = new ADRepositoryRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testSupport.Dispose();
        }

        protected override UserModel AddUserFred()
        {
            return _testSupport.CreateUser("fred", "letmein", "Fred", "Blogs", "fred@aol", Guid.NewGuid());
        }

        protected override TeamModel AddTeam()
        {
            var newTeam = new TeamModel { Name = "Team1", Id = Guid.NewGuid()};
            ADBackend.Instance.Teams.Add(newTeam);
            return newTeam;
        }
    }
}