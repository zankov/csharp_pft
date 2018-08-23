using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : SessionBase
    {
        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData(group.Name, group.Header, group.Footer));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData("a'a"));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.TestDirectory, "groups.csv"));
            foreach (string element in lines)
            {
                string[] parts = element.Split(',');
                groups.Add(new GroupData(parts[0]) {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, "groups.xml")));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "groups.json")));
        }
        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(TestContext.CurrentContext.TestDirectory, "groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData(range.Cells[i, 1].Value)
                {
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }
    }
}