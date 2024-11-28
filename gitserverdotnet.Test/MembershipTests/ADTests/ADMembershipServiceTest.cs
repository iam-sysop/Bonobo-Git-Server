using gitserverdotnet.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace gitserverdotnet.Test.MembershipTests.ADTests
{
    [TestClass]
    public class ADMembershipServiceTest : MembershipServiceTestBase
    {
        private ADTestSupport _testSupport;

        [TestInitialize]
        public void Initialize()
        {
            _testSupport = new ADTestSupport();
            _service = new ADMembershipServiceTestFacade(new ADMembershipService(), _testSupport);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testSupport.Dispose();
        }
    }
}