﻿using ElectroDepotClassLibrary.DataProviders;
using Xunit.Abstractions;

namespace ElectroDepotClassLibraryTests
{
    public class BaseDataProviderTest
    {
        public ITestOutputHelper Console { get; }
        public ComponentDataProvider ComponentDP { get; }
        public CategoryDataProvider CategoryDP { get; }
        public UserDataProvider UserDP { get; }
        public OwnsComponentDataProvider OwnsComponentDP{ get; }

        public BaseDataProviderTest(ITestOutputHelper output)
        {
            Console = output;
            ComponentDP = new ComponentDataProvider(Utility.ConnectionURL);
            CategoryDP = new CategoryDataProvider(Utility.ConnectionURL);
            UserDP = new UserDataProvider(Utility.ConnectionURL);
            OwnsComponentDP = new OwnsComponentDataProvider(Utility.ConnectionURL);
        }
    }
}
