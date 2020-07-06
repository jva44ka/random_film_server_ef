using NUnit.Framework;
using WebApi.Models;

namespace WebApi.Tests
{
    [TestFixture]
    public class FimsDbContextTests
    {
        /// <summary>
        /// ����-���� ����������� �������� �� ����������� � ��
        /// </summary>
        [Test]
        public void TestDBConnection()
        {
            RandomFilmDBContext db = new RandomFilmDBContext();
            if (db.Database.CanConnect() || db.Roles.Local.Count > 0)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
