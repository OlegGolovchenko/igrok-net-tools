using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace org.igrok.validator.test
{
    [TestFixture]
    public class VatTest
    {

        [OneTimeSetUp]
        public void SetupTestRuns()
        {
            VatValidator.Activate("igntest@igrok-net.org", "02317-7C8A2-98981-00007-DB1B8");
        }

        [TestCase(null, TestName = "WhenVatNumberIsNull")]
        [TestCase("", TestName = "WhenVatNumberIsEmpty")]
        public void WhenVatNumberIsNullOrEmpty(string vat)
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync(vat));
        }

        [Test]
        public void WhenAustrianVatDoesNotHaveUCharacter()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("at056875695"));
        }

        [Test]
        public void WhenAustrianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756"));
        }

        [Test]
        public void WhenAustrianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756956"));
        }

        [Test]
        public void WhenAustrianVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("atu56875695"));
        }

        [Test]
        public void WhenBelgianVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("beu56875695"));
        }

        [Test]
        public void WhenBelgianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be0568756"));
        }

        [Test]
        public void WhenBelgianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be056875695665"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith9Digits()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be056875695"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith10Digits()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be0568756958"));
        }

        [Test]
        public void WhenBulgarianVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bgu56875695"));
        }

        [Test]
        public void WhenBulgarianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg0568756"));
        }

        [Test]
        public void WhenBulgarianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg056875695665"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith9Digits()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg056875695"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith10Digits()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg0568756958"));
        }

        [Test]
        public void WhenCroatianVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hru56875695"));
        }

        [Test]
        public void WhenCroatianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756"));
        }

        [Test]
        public void WhenCroatianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756956656565"));
        }

        [Test]
        public void WhenCroatianVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("hr05687569556"));
        }

        [Test]
        public void WhenCyprusVatHaveCharactersInInvalidPosition()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cyu56875695"));
        }

        [Test]
        public void WhenCyprusVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756"));
        }

        [Test]
        public void WhenCyprusVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756956656565"));
        }

        [Test]
        public void WhenCyprusVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cy05687569A"));
        }

        [Test]
        public void WhenCzechVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("czu56875695"));
        }

        [Test]
        public void WhenCzechVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756"));
        }

        [Test]
        public void WhenCzechVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756956656565"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectButTooLong()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz05687569581"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz0568756958"));
        }

        [Test]
        public void WhenDenmarkVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dku56875695"));
        }

        [Test]
        public void WhenDenmarkVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756"));
        }

        [Test]
        public void WhenDenmarkVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756956656565"));
        }

        [Test]
        public void WhenDenmarkVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("dk05687569"));
        }

        [Test]
        public void WhenEstonianVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("eeu56875695"));
        }

        [Test]
        public void WhenEstonianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756"));
        }

        [Test]
        public void WhenEstonianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756956656565"));
        }

        [Test]
        public void WhenEstonianVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("ee056875690"));
        }

        [Test]
        public void WhenFinninshVatHaveCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fiu56875695"));
        }

        [Test]
        public void WhenFinnishVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756"));
        }

        [Test]
        public void WhenFinnishVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756956656565"));
        }

        [Test]
        public void WhenFinnishVatNumberIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("fi05687569"));
        }
        [Test]
        public void WhenFrenchVatHaveInvalidCharacters()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FROI023587691"));
        }

        [Test]
        public void WhenFrenchVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB2586978612"));
        }

        [Test]
        public void WhenFrenchVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB02536897"));
        }

        [Test]
        public void WhenFrenchVatHasCharactersAtWrongPosition()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FR25AV2368971"));
        }

        [Test]
        public void WhenFrenchVatHasOnlyOneLetter()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FR0F253684911"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FRF0253684911"));
        }

        [Test]
        public void WhenFrenchVatHasTwoValidLetters()
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
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("HU01A354897"));
        }

        [Test]
        public void WhenHungarianVatIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("HU12345678"));
        }

        [Test]
        public void WhenIerlandVatIsCorrect()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE01234567A"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE0123456AA"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE0A234567A"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE0123456A"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE012345AA"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IE0A23456A"));
        }

        [Test]
        public void WhenIerlandVatIsNotCorrect()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE01A34567A"));
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE01A3456AA"));
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE0AA34567A"));
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE01A3456A"));
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE01A345AA"));
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE0AA3456A"));
        }

        [Test]
        public void WhenIerlandVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE0AA3456A222"));
        }

        [Test]
        public void WhenIerlandVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IE0AA56A"));
        }

        [Test]
        public void WhenItalianVatIsNumeric()
        {
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("IT01234567890"));
        }

        [Test]
        public void WhenItalianVatIsAlphanumericNumeric()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IT0123456789A"));
        }

        [Test]
        public void WhenItalianVatIsTooLong()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IT01234567890000"));
        }

        [Test]
        public void WhenItalianVatIsTooShort()
        {
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("IT0123456789"));
        }
    }
}
