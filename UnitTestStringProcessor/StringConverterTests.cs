#region Using Statements

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringProcessorLib;

#endregion

namespace UnitTestStringProcessor
{
    [TestClass]
    public class StringConverterTests
    {
        #region Test Methods

        [TestMethod]
        public void EmptyList_Returns_EmptyList()
        {
            // Arrange
            List<string> inputStrings = new List<string>();
            IStringConverter converter = new StringConverter();

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.IsNotNull(outputStrings, "Output list is null.");
            Assert.IsTrue(outputStrings.Count == 0, "Output list count != 0");
        }

        [TestMethod]
        public void NullList_Returns_EmptyList()
        {
            // Arrange
            IStringConverter converter = new StringConverter();

            // Act
            List<string> outputStrings = converter.ConvertStrings(null);

            // Assert
            Assert.IsNotNull(outputStrings, "Output list is null.");
            Assert.IsTrue(outputStrings.Count == 0, "Output list count != 0");
        }

        [TestMethod]
        public void EmptyStrings_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("abcde");
            inputStrings.Add("");
            inputStrings.Add("fghij");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.IsTrue(outputStrings.Count == 2, "Output list count != 2");
            Assert.AreEqual("abcde", outputStrings[0], "Unexpected string returned.");
            Assert.AreEqual("fghij", outputStrings[1], "Unexpected string returned.");
        }

        [TestMethod]
        public void NullStrings_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("abcde");
            inputStrings.Add(null);
            inputStrings.Add("fghij");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.IsTrue(outputStrings.Count == 2, "Output list count != 2");
            Assert.AreEqual("abcde", outputStrings[0], "Unexpected string returned.");
            Assert.AreEqual("fghij", outputStrings[1], "Unexpected string returned.");
        }

        [TestMethod]
        public void Whitespaces_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add(" abcde efghi ");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("abcdefghi", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Strings_Truncate_To15()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("abcde12356efghi6789");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("abcde12356efghi", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Dollars_ReplacedBy_Pounds()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("AbCdE$fGhIj$");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("AbCdE£fGhIj£", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Fours_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("AbCdE4fGhIj4");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("AbCdEfGhIj", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Underscores_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("__AbCdE_fGhIj__");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("AbCdEfGhIj", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Removing_Chars_Doesnt_Create_Empty_String()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("__4444__");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.IsNotNull(outputStrings, "Output list is null.");
            Assert.IsTrue(outputStrings.Count == 0, "Output list count != 0");
        }

        [TestMethod]
        public void Contiguous_Duplicates_Removed()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("AA@@aabcdeEeFF");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("A@abcdeEeF", outputStrings[0], "Unexpected string returned.");
        }

        [TestMethod]
        public void Example_String_1()
        {
            // Arrange
            IStringConverter converter = new StringConverter();
            List<string> inputStrings = new List<string>();
            inputStrings.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");

            // Act
            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            // Assert
            Assert.AreEqual("Ac91%cWwWkLq£1c", outputStrings[0], "Unexpected string returned.");
        }

        #endregion
    }
}