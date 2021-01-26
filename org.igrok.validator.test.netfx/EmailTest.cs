using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class EmailTest
    {
        [OneTimeSetUp]
        public void SetupTestRuns()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
        }

        [Test]
        public void WhenEmailIsEmptyAsync()
        {
            Assert.Throws<ArgumentNullException>(()=>EmailValidator.ValidateEmailAsync(""));
        }

        [Test]
        public void WhenEmailIsNullAsync()
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync(null));
        }

        [Test]
        public void WhenEmailIsTooLongAsync()
        {
            string longmail = "a";
            for (int i = 0; i < 256; i++)
            {
                longmail += "a";
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => EmailValidator.ValidateEmailAsync(longmail));
        }

        [Test]
        public void WhenEmailDoesNotHaveAtCharacterAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("plainaddress"));
        }

        [Test]
        public void WhenEmailDomainPartNotContainDotAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example"));
        }

        [Test]
        public void WhenEmailDomainPartStartsWithInvalidCharacterAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@-example.com"));
        }

        [Test]
        public void WhenEmailDomainPartContainsSpaceAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example.com (Joe Smith)"));
        }

        [Test]
        public void WhenEmailDomainPartContainsGraterThanAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("Joe Smith <email@example.com>"));
        }

        [Test]
        public void WhenEmailDomainPartIsInvalidIpAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@111.222.333.44444"));
        }

        [Test]
        public void WhenEmailConsistsOfInvalidCharactersAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("#@%^%#$@#$@#.com"));
        }

        [Test]
        public void WhenEmailAddressIsNullAsync()
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync("@example.com"));
        }

        [Test]
        public void WhenEmailContainsDomainOnlyAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email.example.com"));
        }

        [Test]
        public void WhenEmailContainsAtInAddressAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example@example.com"));
        }

        [Test]
        public void WhenEmailContainsDoubleDotInAddressAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email..email@example.com"));
        }

        [Test]
        public void WhenEmailContainsInvalidCharactersInAddressAsync()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("あいうえお@example.com"));
        }


        [Test]
        public void WhenEmailsAreCorrectAsync()
        {
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
                Assert.DoesNotThrow(() => EmailValidator.ValidateEmailAsync(item));
            }
        }
    }
}
