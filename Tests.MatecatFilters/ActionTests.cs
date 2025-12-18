using Apps.MatecatFilters.Actions;
using Apps.MatecatFilters.Models;
using Tests.MatecatFilters.Base;

namespace Tests.MatecatFilters
{
    [TestClass]
    public class ActionTests : TestBase
    {
        [TestMethod]
        public async Task ConvertToXliff_IsSuccess()
        {
            var action = new Actions(InvocationContext, FileManager);

            var response = await action.ConvertToXliff( new XliffRequest { 
                File= new Blackbird.Applications.Sdk.Common.Files.FileReference {Name = "20251218_MM_Womo-Preisindex_DE_(1).docx" },
            SourceLocale= "de-de",
            TargetLocale= "de-de"
            });

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response));
            Assert.IsNotNull(response);
        }
    }
}
