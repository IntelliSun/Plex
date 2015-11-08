using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntelliSun.Plex.Tests
{
    [TestClass]
    public class ExtendedTypeTest
    {
        [TestMethod]
        public void TestSingularViewType()
        {
            const Plurality plurality = Plurality.Singular;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var viewType = exType.ViewType;

            Assert.AreEqual(clrType, viewType);
        }

        [TestMethod]
        public void TestPluralViewType()
        {
            const Plurality plurality = Plurality.Plural;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var viewType = exType.ViewType;

            Assert.IsTrue(viewType.IsArray);
            Assert.IsTrue(clrType == viewType.GetElementType());
        }

        [TestMethod]
        public void TestOneOrManyViewType()
        {
            const Plurality plurality = Plurality.OneOrMany;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var viewType = exType.ViewType;

            Assert.IsTrue(viewType.IsArray);
            Assert.IsTrue(clrType == viewType.GetElementType());
        }

        [TestMethod]
        public void TestSingularString()
        {
            const Plurality plurality = Plurality.Singular;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var toString = exType.ToString();

            Assert.AreEqual(clrType.ToString(), toString);
        }

        [TestMethod]
        public void TestPluralString()
        {
            const Plurality plurality = Plurality.Plural;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var toString = exType.ToString();

            Assert.AreEqual(clrType + "[]", toString);
        }

        [TestMethod]
        public void TestOneOrManyString()
        {
            const Plurality plurality = Plurality.OneOrMany;

            var clrType = typeof(string);
            var exType = new ExtendedType(clrType, plurality);
            var toString = exType.ToString();

            Assert.AreEqual(clrType + "[+]", toString);
        }
    }
}
