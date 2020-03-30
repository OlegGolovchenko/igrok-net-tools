using NUnit.Framework;
using org.igrok.validator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace org.igrok.validator.test
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        public async Task WhenEmailIsEmptyAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await EmailValidator.ValidateEmailAsync(""));
        }

        [Test]
        public async Task WhenEmailIsNullAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await EmailValidator.ValidateEmailAsync(null));
        }

        [Test]
        public async Task WhenEmailIsTooLongAsync()
        {
            string longmail = "a";
            for (int i = 0; i < 256; i++)
            {
                longmail += "a";
            }
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await EmailValidator.ValidateEmailAsync(longmail));
        }

        [Test]
        public async Task WhenEmailDoesNotHaveAtCharacterAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("plainaddress"));
        }

        [Test]
        public async Task WhenEmailDomainPartNotContainDotAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email@example"));
        }

        [Test]
        public async Task WhenEmailDomainPartStartsWithInvalidCharacterAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email@-example.com"));
        }

        [Test]
        public async Task WhenEmailDomainPartContainsSpaceAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email@example.com (Joe Smith)"));
        }

        [Test]
        public async Task WhenEmailDomainPartContainsGraterThanAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("Joe Smith <email@example.com>"));
        }

        [Test]
        public async Task WhenEmailDomainPartIsInvalidIpAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email@111.222.333.44444"));
        }

        [Test]
        public async Task WhenEmailConsistsOfInvalidCharactersAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("#@%^%#$@#$@#.com"));
        }

        [Test]
        public async Task WhenEmailAddressIsNullAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await EmailValidator.ValidateEmailAsync("@example.com"));
        }

        [Test]
        public async Task WhenEmailContainsDomainOnlyAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email.example.com"));
        }

        [Test]
        public async Task WhenEmailContainsAtInAddressAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email@example@example.com"));
        }

        [Test]
        public async Task WhenEmailContainsDoubleDotInAddressAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("email..email@example.com"));
        }

        [Test]
        public async Task WhenEmailContainsInvalidCharactersInAddressAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.ThrowsAsync<ArgumentException>(async () => await EmailValidator.ValidateEmailAsync("あいうえお@example.com"));
        }


        [Test]
        public async Task WhenEmailsAreCorrectAsync()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            List<string> emails = new List<string>()
            {
                "email@example.com",
                "firstname.lastname@example.com",
                "email@subdomain.example.com",
                "firstname+lastname@example.com",
                "email@123.123.123.123",
                "email@[123.123.123.123]",
                "“email”@example.com",
                "1234567890@example.com",
                "email@example-one.com",
                "_______@example.com",
                "email@example.name",
                "email@example.museum",
                "email@example.co.jp",
                "firstname-lastname@example.com"
            };

            foreach (string item in emails)
            {
                Assert.DoesNotThrowAsync(async () => await EmailValidator.ValidateEmailAsync(item));
            }
        }
    }
}
