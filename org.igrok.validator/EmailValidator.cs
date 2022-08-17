//###########################################################################################################
//    Igrok-Net validators
//    Copyright(C) 2017  Oleg Golovchenko
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//###########################################################################################################
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
        private static bool _activated;
        /// <summary>
        /// Activates product to be used.
        /// Disclaimer! We are not collecting your data without your consent, your e-mail is the only personal data used in our system.
        /// </summary>
        /// <param name="email">email used to identify your activation</param>
        /// <param name="key">key used for offline activation</param>
        public static void Activate(string email, string key = null)
        {
            _activationMail = email;
            if (_client == null)
            {
                _client = new ActivationClient();
                _client.Init(_activationMail, key);
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                _client.Register((ushort)ProductsEnum.IGNValidator);
            }
            _activated = _client.IsRegistered((ushort)ProductsEnum.IGNValidator);
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
        public static void ValidateEmailAsync(string mail)
        {
            if (_client != null && !_activated)
            {
                throw new InvalidOperationException("Please call activate before using product");
            }
            ValidateEmailNoActivation(mail);
        }
    }
}
