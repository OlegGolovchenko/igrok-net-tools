using NUnit.Framework;
using System;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class VatTest
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenVatNumberIsNullOrEmptyAsync(string vat)
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync(vat));
        }

        [Test]
        public void WhenAustrianVatDoesNotHaveUCharacterAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("at056875695"));
        }

        [Test]
        public void WhenAustrianVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756"));
        }

        [Test]
        public void WhenAustrianVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("atu568756956"));
        }

        [Test]
        public void WhenAustrianVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("atu56875695"));
        }

        [Test]
        public void WhenBelgianVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("beu56875695"));
        }

        [Test]
        public void WhenBelgianVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be0568756"));
        }

        [Test]
        public void WhenBelgianVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("be056875695665"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith9DigitsAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be056875695"));
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith10DigitsAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("be0568756958"));
        }

        [Test]
        public void WhenBulgarianVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bgu56875695"));
        }

        [Test]
        public void WhenBulgarianVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg0568756"));
        }

        [Test]
        public void WhenBulgarianVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("bg056875695665"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith9DigitsAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg056875695"));
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith10DigitsAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("bg0568756958"));
        }

        [Test]
        public void WhenCroatianVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hru56875695"));
        }

        [Test]
        public void WhenCroatianVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756"));
        }

        [Test]
        public void WhenCroatianVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("hr0568756956656565"));
        }

        [Test]
        public void WhenCroatianVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("hr05687569556"));
        }

        [Test]
        public void WhenCyprusVatHaveCharactersInInvalidPositionAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cyu56875695"));
        }

        [Test]
        public void WhenCyprusVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756"));
        }

        [Test]
        public void WhenCyprusVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cy0568756956656565"));
        }

        [Test]
        public void WhenCyprusVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cy05687569A"));
        }

        [Test]
        public void WhenCzechVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("czu56875695"));
        }

        [Test]
        public void WhenCzechVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756"));
        }

        [Test]
        public void WhenCzechVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("cz0568756956656565"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectButTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz05687569581"));
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("cz0568756958"));
        }

        [Test]
        public void WhenDenmarkVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dku56875695"));
        }

        [Test]
        public void WhenDenmarkVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756"));
        }

        [Test]
        public void WhenDenmarkVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("dk0568756956656565"));
        }

        [Test]
        public void WhenDenmarkVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("dk05687569"));
        }

        [Test]
        public void WhenEstonianVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("eeu56875695"));
        }

        [Test]
        public void WhenEstonianVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756"));
        }

        [Test]
        public void WhenEstonianVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("ee0568756956656565"));
        }

        [Test]
        public void WhenEstonianVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("ee056875690"));
        }

        [Test]
        public void WhenFinninshVatHaveCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fiu56875695"));
        }

        [Test]
        public void WhenFinnishVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756"));
        }

        [Test]
        public void WhenFinnishVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("fi0568756956656565"));
        }

        [Test]
        public void WhenFinnishVatNumberIsCorrectAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("fi05687569"));
        }
        [Test]
        public void WhenFrenchVatHaveInvalidCharactersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FROI023587691"));
        }

        [Test]
        public void WhenFrenchVatIsTooLongAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB2586978612"));
        }

        [Test]
        public void WhenFrenchVatIsTooShortAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FRAB02536897"));
        }

        [Test]
        public void WhenFrenchVatHasCharactersAtWrongPositionAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("FR25AV2368971"));
        }

        [Test]
        public void WhenFrenchVatHasOnlyOneLetterAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FR0F253684911"));
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FRF0253684911"));
        }

        [Test]
        public void WhenFrenchVatHasTwoValidLettersAsync()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("FRFF253684911"));
        }

        [Test]
        public void WhenGermanVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("DE0123548972"));
        }


        [Test]
        public void WhenGermanVatHasInvalidCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("DE01A3548972"));
        }

        [Test]
        public void WhenGermanVatIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("DE012345678"));
        }

        [Test]
        public void WhenGreekVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("EL0123548972"));
        }


        [Test]
        public void WhenGreekVatHasInvalidCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("EL01A3548972"));
        }

        [Test]
        public void WhenGreekVatIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("EL012345678"));
        }

        [Test]
        public void WhenHungarianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("HU123548972"));
        }


        [Test]
        public void WhenHungarianVatHasInvalidCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => VatValidator.ValidateVatAsync("HU1A3548972"));
        }

        [Test]
        public void WhenHungarianVatIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => VatValidator.ValidateVatAsync("HU12345678"));
        }
    }
}
