using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gitserverdotnet.Test.MembershipTests.EFTests
{
    /// <summary>
    /// EF Membership tests using in-memory Sqlite
    /// </summary>
    [TestClass]
    public class EFSqliteMembershipServiceTest : EFMembershipServiceTest
    {
        [TestInitialize]
        public void Initialize()
        {
            _connection = new SqliteTestConnection();
            InitialiseTestObjects();
        }
    }
}