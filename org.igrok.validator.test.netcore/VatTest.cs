using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace org.igrok.validator.test
{
    [TestFixture]
    public class VatTest
    {
        [TestCase(null)]
        [TestCase("")]
        public async Task WhenVatNumberIsNullOrEmptyAsync(string vat)
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync(vat));
        }

        [Test]
        public async Task WhenAustrianVatDoesNotHaveUCharacterAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("at056875695"));
        }

        [Test]
        public async Task WhenAustrianVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("atu568756"));
        }

        [Test]
        public async Task WhenAustrianVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("atu568756956"));
        }

        [Test]
        public async Task WhenAustrianVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("atu56875695"));
        }

        [Test]
        public async Task WhenBelgianVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("beu56875695"));
        }

        [Test]
        public async Task WhenBelgianVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("be0568756"));
        }

        [Test]
        public async Task WhenBelgianVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("be056875695665"));
        }

        [Test]
        public async Task WhenBelgianVatNumberIsCorrectWith9DigitsAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("be056875695"));
        }

        [Test]
        public async Task WhenBelgianVatNumberIsCorrectWith10DigitsAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("be0568756958"));
        }

        [Test]
        public async Task WhenBulgarianVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("bgu56875695"));
        }

        [Test]
        public async Task WhenBulgarianVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("bg0568756"));
        }

        [Test]
        public async Task WhenBulgarianVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("bg056875695665"));
        }

        [Test]
        public async Task WhenBulgarianVatNumberIsCorrectWith9DigitsAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("bg056875695"));
        }

        [Test]
        public async Task WhenBulgarianVatNumberIsCorrectWith10DigitsAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("bg0568756958"));
        }

        [Test]
        public async Task WhenCroatianVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("hru56875695"));
        }

        [Test]
        public async Task WhenCroatianVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("hr0568756"));
        }

        [Test]
        public async Task WhenCroatianVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("hr0568756956656565"));
        }

        [Test]
        public async Task WhenCroatianVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("hr05687569556"));
        }

        [Test]
        public async Task WhenCyprusVatHaveCharactersInInvalidPositionAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("cyu56875695"));
        }

        [Test]
        public async Task WhenCyprusVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("cy0568756"));
        }

        [Test]
        public async Task WhenCyprusVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("cy0568756956656565"));
        }

        [Test]
        public async Task WhenCyprusVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("cy05687569A"));
        }

        [Test]
        public async Task WhenCzechVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("czu56875695"));
        }

        [Test]
        public async Task WhenCzechVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("cz0568756"));
        }

        [Test]
        public async Task WhenCzechVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("cz0568756956656565"));
        }

        [Test]
        public async Task WhenCzechVatNumberIsCorrectButTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("cz05687569581"));
        }

        [Test]
        public async Task WhenCzechVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("cz0568756958"));
        }

        [Test]
        public async Task WhenDenmarkVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("dku56875695"));
        }

        [Test]
        public async Task WhenDenmarkVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("dk0568756"));
        }

        [Test]
        public async Task WhenDenmarkVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("dk0568756956656565"));
        }

        [Test]
        public async Task WhenDenmarkVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("dk05687569"));
        }

        [Test]
        public async Task WhenEstonianVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("eeu56875695"));
        }

        [Test]
        public async Task WhenEstonianVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("ee0568756"));
        }

        [Test]
        public async Task WhenEstonianVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("ee0568756956656565"));
        }

        [Test]
        public async Task WhenEstonianVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("ee056875690"));
        }

        [Test]
        public async Task WhenFinninshVatHaveCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("fiu56875695"));
        }

        [Test]
        public async Task WhenFinnishVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("fi0568756"));
        }

        [Test]
        public async Task WhenFinnishVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("fi0568756956656565"));
        }

        [Test]
        public async Task WhenFinnishVatNumberIsCorrectAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("fi05687569"));
        }
        [Test]
        public async Task WhenFrenchVatHaveInvalidCharactersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("FROI023587691"));
        }

        [Test]
        public async Task WhenFrenchVatIsTooLongAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("FRAB2586978612"));
        }

        [Test]
        public async Task WhenFrenchVatIsTooShortAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("FRAB02536897"));
        }

        [Test]
        public async Task WhenFrenchVatHasCharactersAtWrongPositionAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await VatValidator.ValidateVatAsync("FR25AV2368971"));
        }

        [Test]
        public async Task WhenFrenchVatHasOnlyOneLetterAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("FR0F253684911"));
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("FRF0253684911"));
        }

        [Test]
        public async Task WhenFrenchVatHasTwoValidLettersAsync()
        {
            await VatValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.DoesNotThrowAsync(async () => await VatValidator.ValidateVatAsync("FRFF253684911"));
        }
    }
}
