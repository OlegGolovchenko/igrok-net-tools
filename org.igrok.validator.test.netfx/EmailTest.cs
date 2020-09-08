using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        public void WhenEmailIsEmptyAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentNullException>(()=>EmailValidator.ValidateEmailAsync(""));
        }

        [Test]
        public void WhenEmailIsNullAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
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
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentOutOfRangeException>(() => EmailValidator.ValidateEmailAsync(longmail));
        }

        [Test]
        public void WhenEmailDoesNotHaveAtCharacterAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("plainaddress"));
        }

        [Test]
        public void WhenEmailDomainPartNotContainDotAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example"));
        }

        [Test]
        public void WhenEmailDomainPartStartsWithInvalidCharacterAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@-example.com"));
        }

        [Test]
        public void WhenEmailDomainPartContainsSpaceAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example.com (Joe Smith)"));
        }

        [Test]
        public void WhenEmailDomainPartContainsGraterThanAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("Joe Smith <email@example.com>"));
        }

        [Test]
        public void WhenEmailDomainPartIsInvalidIpAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@111.222.333.44444"));
        }

        [Test]
        public void WhenEmailConsistsOfInvalidCharactersAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("#@%^%#$@#$@#.com"));
        }

        [Test]
        public void WhenEmailAddressIsNullAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync("@example.com"));
        }

        [Test]
        public void WhenEmailContainsDomainOnlyAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email.example.com"));
        }

        [Test]
        public void WhenEmailContainsAtInAddressAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example@example.com"));
        }

        [Test]
        public void WhenEmailContainsDoubleDotInAddressAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email..email@example.com"));
        }

        [Test]
        public void WhenEmailContainsInvalidCharactersInAddressAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("あいうえお@example.com"));
        }


        [Test]
        public void WhenEmailsAreCorrectAsync()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
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
