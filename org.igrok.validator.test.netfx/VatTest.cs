using NUnit.Framework;
using System;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class VatTest
    {
        [OneTimeSetUp]
        public void SetupTestRuns()
        {
            VatValidator.Activate("igrok_be@hotmail.com");
        }

        [TestCase(null)]
        [TestCase("")]
        public void WhenVatNumberIsNullOrEmptyAsync(string vat)
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync(vat));
        }

        [Test]
        public void WhenAustrianVatDoesNotHaveUCharacterAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("at056875695"));
        }

        [Test]
        public void WhenAustrianVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756"));
        }

        [Test]
        public void WhenAustrianVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756956"));
        }

        [Test]
        public void WhenAustrianVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("atu56875695"));
        }

        [Test]
        public void WhenBelgianVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("beu56875695"));
        }

        [Test]
        public void WhenBelgianVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be0568756"));
        }

        [Test]
        public void WhenBelgianVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be056875695665"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith9DigitsAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be056875695"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith10DigitsAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be0568756958"));
        }

        [Test]
        public void WhenBulgarianVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bgu56875695"));
        }

        [Test]
        public void WhenBulgarianVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg0568756"));
        }

        [Test]
        public void WhenBulgarianVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg056875695665"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith9DigitsAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg056875695"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith10DigitsAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg0568756958"));
        }

        [Test]
        public void WhenCroatianVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hru56875695"));
        }

        [Test]
        public void WhenCroatianVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756"));
        }

        [Test]
        public void WhenCroatianVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756956656565"));
        }

        [Test]
        public void WhenCroatianVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("hr05687569556"));
        }

        [Test]
        public void WhenCyprusVatHaveCharactersInInvalidPositionAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cyu56875695"));
        }

        [Test]
        public void WhenCyprusVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756"));
        }

        [Test]
        public void WhenCyprusVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756956656565"));
        }

        [Test]
        public void WhenCyprusVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cy05687569A"));
        }

        [Test]
        public void WhenCzechVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("czu56875695"));
        }

        [Test]
        public void WhenCzechVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756"));
        }

        [Test]
        public void WhenCzechVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756956656565"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectButTooLongAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz05687569581"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz0568756958"));
        }

        [Test]
        public void WhenDenmarkVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dku56875695"));
        }

        [Test]
        public void WhenDenmarkVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756"));
        }

        [Test]
        public void WhenDenmarkVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756956656565"));
        }

        [Test]
        public void WhenDenmarkVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("dk05687569"));
        }

        [Test]
        public void WhenEstonianVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("eeu56875695"));
        }

        [Test]
        public void WhenEstonianVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756"));
        }

        [Test]
        public void WhenEstonianVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756956656565"));
        }

        [Test]
        public void WhenEstonianVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("ee056875690"));
        }

        [Test]
        public void WhenFinninshVatHaveCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fiu56875695"));
        }

        [Test]
        public void WhenFinnishVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756"));
        }

        [Test]
        public void WhenFinnishVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756956656565"));
        }

        [Test]
        public void WhenFinnishVatNumberIsCorrectAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("fi05687569"));
        }
        [Test]
        public void WhenFrenchVatHaveInvalidCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FROI023587691"));
        }

        [Test]
        public void WhenFrenchVatIsTooLongAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB2586978612"));
        }

        [Test]
        public void WhenFrenchVatIsTooShortAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB02536897"));
        }

        [Test]
        public void WhenFrenchVatHasCharactersAtWrongPositionAsync()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FR25AV2368971"));
        }

        [Test]
        public void WhenFrenchVatHasOnlyOneLetterAsync()
        {Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FR0F253684911"));
        }

        [Test]
        public void WhenFrenchVatHasTwoValidLettersAsync()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FRFF253684911"));
        }

        [Test]
        public void WhenGermanVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("DE0123548972"));
        }


        [Test]
        public void WhenGermanVatHasInvalidCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("DE01A3548972"));
        }

        [Test]
        public void WhenGermanVatIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("DE012345678"));
        }

        [Test]
        public void WhenGreekVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("EL0123548972"));
        }


        [Test]
        public void WhenGreekVatHasInvalidCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("EL01A3548972"));
        }

        [Test]
        public void WhenGreekVatIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("EL012345678"));
        }

        [Test]
        public void WhenHungarianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("HU123548972"));
        }


        [Test]
        public void WhenHungarianVatHasInvalidCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("HU1A3548972"));
        }

        [Test]
        public void WhenHungarianVatIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("HU12345678"));
        }
    }
}
