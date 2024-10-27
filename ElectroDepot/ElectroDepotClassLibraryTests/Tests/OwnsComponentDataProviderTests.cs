using ElectroDepotClassLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests.Tests
{
    public class OwnsComponentDataProviderTests : BaseDataProviderTest
    {
        public OwnsComponentDataProviderTests(ITestOutputHelper output) : base(output)
        {
        }
        public async Task Create()
        {
            try
            {
                CreateOwnsComponentDTO ownsComponentDTO = new CreateOwnsComponentDTO(1, 1, 1);

                bool wasCreated = await OwnsComponentDP.CreateOwnComponentRelation(ownsComponentDTO);
                Assert.True(wasCreated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
