using NUnit.Framework;
using System;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class VatTest
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenVatNumberIsNullOrEmpty(string vat)
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync(vat); });
        }

        [Test]
        public void WhenAustrianVatDoesNotHaveUCharacter()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("at056875695"); });
        }

        [Test]
        public void WhenAustrianVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("atu568756"); });
        }

        [Test]
        public void WhenAustrianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("atu568756956"); });
        }

        [Test]
        public void WhenAustrianVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("atu56875695"); });
        }

        [Test]
        public void WhenBelgianVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("beu56875695"); });
        }

        [Test]
        public void WhenBelgianVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("be0568756"); });
        }

        [Test]
        public void WhenBelgianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("be056875695665"); });
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith9Digits()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("be056875695"); });
        }

        [Test]
        public void WhenBelgianVatNumberIsCorrectWith10Digits()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("be0568756958"); });
        }

        [Test]
        public void WhenBulgarianVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("bgu56875695"); });
        }

        [Test]
        public void WhenBulgarianVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("bg0568756"); });
        }

        [Test]
        public void WhenBulgarianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("bg056875695665"); });
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith9Digits()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("bg056875695"); });
        }

        [Test]
        public void WhenBulgarianVatNumberIsCorrectWith10Digits()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("bg0568756958"); });
        }

        [Test]
        public void WhenCroatianVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("hru56875695"); });
        }

        [Test]
        public void WhenCroatianVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("hr0568756"); });
        }

        [Test]
        public void WhenCroatianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("hr0568756956656565"); });
        }

        [Test]
        public void WhenCroatianVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("hr05687569556"); });
        }

        [Test]
        public void WhenCyprusVatHaveCharactersInInvalidPosition()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("cyu56875695"); });
        }

        [Test]
        public void WhenCyprusVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("cy0568756"); });
        }

        [Test]
        public void WhenCyprusVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("cy0568756956656565"); });
        }

        [Test]
        public void WhenCyprusVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("cy05687569A"); });
        }

        [Test]
        public void WhenCzechVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("czu56875695"); });
        }

        [Test]
        public void WhenCzechVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("cz0568756"); });
        }

        [Test]
        public void WhenCzechVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("cz0568756956656565"); });
        }

        [Test]
        public void WhenCzechVatNumberIsCorrectButTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("cz05687569581"); });
        }

        [Test]
        public void WhenCzechVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("cz0568756958"); });
        }

        [Test]
        public void WhenDenmarkVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("dku56875695"); });
        }

        [Test]
        public void WhenDenmarkVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("dk0568756"); });
        }

        [Test]
        public void WhenDenmarkVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("dk0568756956656565"); });
        }

        [Test]
        public void WhenDenmarkVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("dk05687569"); });
        }

        [Test]
        public void WhenEstonianVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("eeu56875695"); });
        }

        [Test]
        public void WhenEstonianVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("ee0568756"); });
        }

        [Test]
        public void WhenEstonianVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("ee0568756956656565"); });
        }

        [Test]
        public void WhenEstonianVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("ee056875690"); });
        }

        [Test]
        public void WhenFinninshVatHaveCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("fiu56875695"); });
        }

        [Test]
        public void WhenFinnishVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("fi0568756"); });
        }

        [Test]
        public void WhenFinnishVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("fi0568756956656565"); });
        }

        [Test]
        public void WhenFinnishVatNumberIsCorrect()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("fi05687569"); });
        }
        [Test]
        public void WhenFrenchVatHaveInvalidCharacters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("FROI023587691"); });
        }

        [Test]
        public void WhenFrenchVatIsTooLong()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("FRAB2586978612"); });
        }

        [Test]
        public void WhenFrenchVatIsTooShort()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("FRAB02536897"); });
        }

        [Test]
        public void WhenFrenchVatHasCharactersAtWrongPosition()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { VatValidator.ValidateVatAsync("FR25AV2368971"); });
        }

        [Test]
        public void WhenFrenchVatHasOnlyOneLetter()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("FR0F253684911"); });
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("FRF0253684911"); });
        }

        [Test]
        public void WhenFrenchVatHasTwoValidLetters()
        {
            VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrow(() => { VatValidator.ValidateVatAsync("FRFF253684911"); });
        }
    }
}
