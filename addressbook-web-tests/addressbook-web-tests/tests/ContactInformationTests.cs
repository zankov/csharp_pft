using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class ContactInformationTests : SessionBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(0);
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
