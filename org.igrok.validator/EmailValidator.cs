using IGNActivation.Client;
using System;
using System.Text.RegularExpressions;
#if !NET40
using System.Threading.Tasks;
#endif

namespace org.igrok.validator
{
    /// <summary>
    /// Validator class for e-mail address according to RFC 5321
    /// </summary>
    public class EmailValidator
    {
        private static ActivationClient _client;
        private static string _activationMail;
        /// <summary>
        /// Activates product to be used.
        /// Disclaimer! We are not collecting your data without your consent, your e-mail is the only personal data used in our system.
        /// </summary>
        /// <param name="email">email used to identify your activation</param>
#if NET40
        public static void ActivateAsync(string email)
#else
        public static async Task ActivateAsync(string email)
#endif
        {
            _activationMail = email;
            _client = new ActivationClient(_activationMail);
#if NET40
            _client.ActivateAsync();
#else
            await _client.ActivateAsync();
#endif
        }

        /// <summary>
        /// Activates product using offline file with license information
        /// </summary>
        /// <param name="email">email of user to validate</param>
        /// <param name="licenseFilePath">license file with validation info</param>
        public static void ActivateOffline(string email, string licenseFilePath)
        {
            _client = new ActivationClient(email);
            _client.ActivateOffline(licenseFilePath);
        }

        internal static void ValidateEmailNoActivation(string mail)
        {
            if (String.IsNullOrEmpty(mail))
            {
                throw new ArgumentNullException("Email", "Email can't be null or empty");
            }
            if (mail.Length > 254)
            {
                throw new ArgumentOutOfRangeException("Email", "Email is too long to be handled by SMTP");
            }
            if (!mail.Contains("@"))
            {
                throw new ArgumentException("Email does not contain @ character");
            }

            string domain = mail.Split('@')[mail.Split('@').Length - 1];

            if (!domain.Contains("."))
            {
                throw new ArgumentException("Domain part does not contain dot caracter");
            }

            if (domain.StartsWith("-"))
            {
                throw new ArgumentException("Domain part starts with invalid caracter");
            }

            if (!Regex.IsMatch(domain, @"^[A-z0-9-.]+$"))
            {
                throw new ArgumentException("Domain part contains invalid caracter");
            }

            if (domain.Split('.').Length == 4)
            {
                if (Regex.IsMatch(domain, @"^[0-9.]+$"))
                {
                    if (domain.Contains("[") || domain.Contains("]"))
                    {
                        foreach (string item in domain.Split('.'))
                        {
                            if (item.Contains("[") || item.Contains("]"))
                            {
                                if (item.Length > 4)
                                {
                                    throw new ArgumentException("Domain part invalid ip format");
                                }
                            }
                            else
                            {
                                if (item.Length > 3)
                                {
                                    throw new ArgumentException("Domain part invalid ip format");
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string item in domain.Split('.'))
                        {
                            if (item.Length > 3)
                            {
                                throw new ArgumentException("Domain part invalid ip format");
                            }
                        }
                    }
                }
            }

            string address = "";

            if (mail.Split('@').Length > 2)
            {
                for (int i = 0; i < mail.Split('@').Length - 1; i++)
                {
                    address += mail.Split('@')[i] + "@";
                }
            }
            else
            {
                address = mail.Split('@')[0];
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException("address", "Address part of e-mail can not be empty");
            }

            if (!Regex.IsMatch(address, @"^[a-z0-9.!#“”$%&'*+/=?^_`{|}~-]+$"))
            {
                throw new ArgumentException("Address part contains invalid caracters");
            }

            if (address.Contains("@"))
            {
                throw new ArgumentException("Address part contains at caracter");
            }

            if (address.StartsWith(".") || address.EndsWith("."))
            {
                throw new ArgumentException("Address part starts or ends with dot");
            }

            if (address.Contains(".."))
            {
                throw new ArgumentException("Address partcontains double dot");
            }
        }

        /// <summary>
        /// Validates email according to RFC 5321.
        /// Throws ArgumentException, ArgumentNullException, ArgumentOutOfRangeException.
        /// If no exception is thrown e-mail is valid.
        /// </summary>
        /// <param name="mail">email to validate</param>
        /// <remarks>
        /// Throws ArgumentException, ArgumentNullException or ArgumentOutOfRangeException if email is invalid.
        /// </remarks>
#if NET40
        public static void ValidateEmailAsync(string mail)
#else
        public static async Task ValidateEmailAsync(string mail)
#endif
        {
#if NET40
            if (_client != null && !_client.IsRegisteredAsync())
#else
            if (_client != null && !await _client.IsRegisteredAsync())
#endif
            {
                throw new InvalidOperationException("Please call activate before using product");
            }
            ValidateEmailNoActivation(mail);
        }
    }
}
