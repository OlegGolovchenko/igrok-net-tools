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

        [OneTimeSetUp]
        public async Task SetupTestRuns()
        {
            await EmailValidator.ActivateAsync("igrok_be@hotmail.com");
        }

        [Test]
        public void WhenEmailIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync(""));
        }

        [Test]
        public void WhenEmailIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync(null));
        }

        [Test]
        public void WhenEmailIsTooLong()
        {
            string longmail = "a";
            for (int i = 0; i < 256; i++)
            {
                longmail += "a";
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => EmailValidator.ValidateEmailAsync(longmail));
        }

        [Test]
        public void WhenEmailDoesNotHaveAtCharacter()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("plainaddress"));
        }

        [Test]
        public void WhenEmailDomainPartNotContainDot()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example"));
        }

        [Test]
        public void WhenEmailDomainPartStartsWithInvalidCharacter()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@-example.com"));
        }

        [Test]
        public void WhenEmailDomainPartContainsSpace()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example.com (Joe Smith)"));
        }

        [Test]
        public void WhenEmailDomainPartContainsGraterThan()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("Joe Smith <email@example.com>"));
        }

        [Test]
        public void WhenEmailDomainPartIsInvalidIp()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@111.222.333.44444"));
        }

        [Test]
        public void WhenEmailConsistsOfInvalidCharacters()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("#@%^%#$@#$@#.com"));
        }

        [Test]
        public void WhenEmailAddressIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidator.ValidateEmailAsync("@example.com"));
        }

        [Test]
        public void WhenEmailContainsDomainOnly()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email.example.com"));
        }

        [Test]
        public void WhenEmailContainsAtInAddress()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email@example@example.com"));
        }

        [Test]
        public void WhenEmailContainsDoubleDotInAddress()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("email..email@example.com"));
        }

        [Test]
        public void WhenEmailContainsInvalidCharactersInAddress()
        {
            Assert.Throws<ArgumentException>(() => EmailValidator.ValidateEmailAsync("あいうえお@example.com"));
        }


        [Test]
        public void WhenEmailsAreCorrect()
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
