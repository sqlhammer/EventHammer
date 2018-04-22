using Microsoft.VisualStudio.TestTools.UnitTesting;
using DKK_App;
using DKK_App.Entities;
using DKK_App.Enums;

namespace DKK_App_Test
{
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void MatchTypeDisplayName_Short_SpecialConsideration()
        {
            // arrange  
            MatchType mt = new MatchType
            {
                IsSpecialConsideration = true,
                MatchTypeId = 1,
                MatchTypeName = "Weapons Kata"
            };
            LengthType len = LengthType.Short;
            string expected = "Weapons Kata*";

            // act  
            string actual = Global.GetMatchTypeDisplayName(mt, len);

            // assert  
            Assert.AreEqual(expected, actual, false, "Match type did not display correctly for a special consideration with the short length type.");
        }

        [TestMethod]
        public void MatchTypeDisplayName_Long_SpecialConsideration()
        {
            // arrange  
            MatchType mt = new MatchType
            {
                IsSpecialConsideration = true,
                MatchTypeId = 1,
                MatchTypeName = "Weapons Kata"
            };
            LengthType len = LengthType.Long;
            string expected = "Weapons Kata (Special Consideration)";

            // act  
            string actual = Global.GetMatchTypeDisplayName(mt, len);

            // assert  
            Assert.AreEqual(expected, actual, false, "Match type did not display correctly for a special consideration with the long length type.");
        }

        [TestMethod]
        public void MatchTypeDisplayName_NonSpecialConsideration()
        {
            // arrange  
            MatchType mt = new MatchType
            {
                IsSpecialConsideration = false,
                MatchTypeId = 1,
                MatchTypeName = "Weapons Kata"
            };
            LengthType len = LengthType.Long;
            string expected = "Weapons Kata";

            // act  
            string actual = Global.GetMatchTypeDisplayName(mt, len);

            // assert  
            Assert.AreEqual(expected, actual, false, "Match type did not display correctly for a non-special consideration type.");
        }
    }
}
