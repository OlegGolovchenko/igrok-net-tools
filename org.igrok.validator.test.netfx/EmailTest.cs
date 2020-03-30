using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace org.igrok.validator.test.netfx
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        public void WhenEmailIsEmpty()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentNullException>(() => { EmailValidator.ValidateEmailAsync(""); });
        }

        [Test]
        public void WhenEmailIsNull()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentNullException>(() => { EmailValidator.ValidateEmailAsync(null); });
        }

        [Test]
        public void WhenEmailIsTooLong()
        {
            string longmail = "a";
            for (int i = 0; i < 256; i++)
            {
                longmail += "a";
            }
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentOutOfRangeException>(() => { EmailValidator.ValidateEmailAsync(longmail); });
        }

        [Test]
        public void WhenEmailDoesNotHaveAtCharacter()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("plainaddress"); });
        }

        [Test]
        public void WhenEmailDomainPartNotContainDot()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email@example"); });
        }

        [Test]
        public void WhenEmailDomainPartStartsWithInvalidCharacter()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email@-example.com"); });
        }

        [Test]
        public void WhenEmailDomainPartContainsSpace()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email@example.com (Joe Smith)"); });
        }

        [Test]
        public void WhenEmailDomainPartContainsGraterThan()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("Joe Smith <email@example.com>"); });
        }

        [Test]
        public void WhenEmailDomainPartIsInvalidIp()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email@111.222.333.44444"); });
        }

        [Test]
        public void WhenEmailConsistsOfInvalidCharacters()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("#@%^%#$@#$@#.com"); });
        }

        [Test]
        public void WhenEmailAddressIsNull()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentNullException>(() => { EmailValidator.ValidateEmailAsync("@example.com"); });
        }

        [Test]
        public void WhenEmailContainsDomainOnly()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email.example.com"); });
        }

        [Test]
        public void WhenEmailContainsAtInAddress()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email@example@example.com"); });
        }

        [Test]
        public void WhenEmailContainsDoubleDotInAddress()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("email..email@example.com"); });
        }

        [Test]
        public void WhenEmailContainsInvalidCharactersInAddress()
        {
            EmailValidator.ActivateAsync("igrok_be@hotmail.com");
            Assert.Throws<ArgumentException>(() => { EmailValidator.ValidateEmailAsync("あいうえお@example.com"); });
        }


        [Test]
        public void WhenEmailsAreCorrect()
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
                Assert.DoesNotThrow(() => { EmailValidator.ValidateEmailAsync(item); });
            }
        }
    }
}
