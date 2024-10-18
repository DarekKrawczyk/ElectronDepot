using ElectroDepotClassLibrary.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class BaseDataProviderTest
    {
        public ITestOutputHelper Console { get; }
        public ComponentDataProvider ComponentDP { get; }
        public CategoryDataProvider CategoryDP { get; }

        public BaseDataProviderTest(ITestOutputHelper output)
        {
            Console = output;
            ComponentDP = new ComponentDataProvider(Utility.ConnectionURL);
            CategoryDP = new CategoryDataProvider(Utility.ConnectionURL);
        }
    }
}
