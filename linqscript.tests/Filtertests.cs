using linqscript.lib;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqscript.tests
{
    public class Filtertests
    {
        [Test]
        public void TestFilter()
        {
            Data data = Substitute.ForPartsOf<Data>();
            SubstituteExtensions.Returns<List<dynamic>>(data.GetDynamic(Arg.Is("test")), new List<dynamic> { 1, 2, 3, 4 });
            //data.GetDynamic(Arg.Is("test")).Returns(new List<dynamic> { 1,2,3,4});

            data.GetDynamic("test");
            var r = data.Filter("Rows.Where(r=>r % 2 == 0");
            Assert.That(r.Count() == 2);
        }
    }
}
