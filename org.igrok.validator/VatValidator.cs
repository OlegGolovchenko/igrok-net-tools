#if NETFULL
#else
using IGNActivation.Client;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace org.igrok.validator
{
    /// <summary>
    /// Validator for VIES vat numbers of countries Experimental in current version not all validations work
    /// </summary>
    public class VatValidator
    {
#if NETFULL
#else
        private static ActivationClient _client;
#endif
        private static string _activationMail;

        private static List<VatCountry> _countryList = new List<VatCountry>
        {
            new VatCountry
            {
                Code = "AT",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>
                {
                    new VatSpecialCharacter('U',0)
                },
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "BE",
                Lengths = new List<int>{10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "BG",
                Lengths = new List<int>{9,10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "HR",
                Lengths = new List<int>{11},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "CY",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>{new VatAlphaSpecialCharacter(8)},
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "CZ",
                Lengths = new List<int>{8,9,10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "DK",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "EE",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "FI",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "FR",
                Lengths = new List<int>{11},
                SpecialCharacters = new List<IVatSpecialCharacter>{ new VatAlphaSpecialCharacter(0),new VatAlphaSpecialCharacter(1)},
                ExcludedCharacters = "OI"
            },
            new VatCountry
            {
                Code = "DE",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "EL",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "HU",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "IE",
                Lengths = new List<int>{8,9},
                SpecialCharacters = new List<IVatSpecialCharacter>{
                    new VatSpecialCharacter('A',8),
                    new VatSpecialCharacter('A',7),
                    new VatSpecialCharacter('H',8),
                    new VatSpecialCharacter('H',7)
                },
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "IT",
                Lengths = new List<int>{11},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "LV",
                Lengths = new List<int>{11},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "LT",
                Lengths = new List<int>{9,12},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "LU",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "MT",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "NL",
                Lengths = new List<int>{12},
                SpecialCharacters = new List<IVatSpecialCharacter>{
                    new VatSpecialCharacter('B',9),
                    new VatSpecialCharacter('O',10),
                    new VatSpecialCharacter('2',11)
                },
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "NO",
                Lengths = new List<int>{9,12},
                SpecialCharacters = new List<IVatSpecialCharacter>
                {
                    new VatSpecialCharacter('M',9),
                    new VatSpecialCharacter('V',10),
                    new VatSpecialCharacter('A',11),
                    new VatNorwayCalculatedSpecialCharacter(8)
                },
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "PL",
                Lengths = new List<int>{10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "PT",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "RO",
                Lengths = new List<int>{10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "SK",
                Lengths = new List<int>{10},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "SI",
                Lengths = new List<int>{8},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "ES",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>
                {
                    new VatAlphaSpecialCharacter(0),
                    new VatAlphaSpecialCharacter(8)
                },
                ExcludedCharacters = ""
            },
            new VatCountry
            {
                Code = "SE",
                Lengths = new List<int>{12},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "CHE",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "GB",
                Lengths = new List<int>{9},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            }
        };

        internal static void ValidateVatNoActivation(string vat)
        {
            if (string.IsNullOrEmpty(vat))
            {
                throw new ArgumentException("Should not be empty", "vat");
            }

            string country = vat.ToUpper().Substring(0, 2);
            string nbPart = vat.ToUpper().Substring(2);

            if (!_countryList.Any(e => e.Code == country))
            {
                throw new ArgumentException("Vat number doesn't match any format known by library");
            }

            var validator = _countryList.Single(e => e.Code == country);
            if (!validator.ValidateLength(nbPart) && validator.Code == "BE")
            {
                nbPart = "0" + nbPart;
            }

            if (!validator.ValidateLength(nbPart) && validator.Code == "CZ")
            {
                nbPart = nbPart.Substring(3);
            }

            if (!validator.ValidateLength(nbPart) && validator.Code == "CHE")
            {
                var zoneId = nbPart.Substring(9).ToUpperInvariant();
                if (zoneId != "MWST")
                {

                }
                else if (zoneId != "TVA")
                {

                }
                else if (zoneId != "IVA")
                {

                }
                else
                {
                    nbPart = nbPart.Substring(0, 9);
                }
            }

            if (!validator.ValidateLength(nbPart))
            {
                throw new ArgumentException("Invalid Vat length");
            }

            if (!validator.ValidateExcludedCharacters(nbPart))
            {
                throw new ArgumentException("Excluded characters present");
            }

            if (!validator.ValidateSpecialCharacters(nbPart))
            {
                throw new ArgumentException("Special characters not found on correct positions");
            }
            return;
        }

        /// <summary>
        /// Validates Vat number
        /// </summary>
        /// <param name="vat">Vat number to check for correct format</param>
#if NETFULL
        public static void ValidateVatAsync(string vat)
#else
        public static async Task ValidateVatAsync(string vat)
#endif
        {
#if NETFULL
#else
            _client = new ActivationClient(_activationMail);
            await _client.ActivateAsync();
            if (!await _client.IsRegisteredAsync())
            {
                throw new InvalidOperationException("Please call activate before using product");
            }
#endif
            ValidateVatNoActivation(vat);
        }

        /// <summary>
        /// Activates product to be used.
        /// Disclaimer! We are not collecting your data without your consent, your e-mail is the only personal data used in our system.
        /// </summary>
        /// <param name="email">email used to identify your activation</param>
#if NETFULL
        public static void ActivateAsync(string email)
#else
        public static async Task ActivateAsync(string email)
#endif
        {
            _activationMail = email;
#if NETFULL
            //No activation needed because activation client is not compatible with .net 4.0
#else
            _client = new ActivationClient(_activationMail);
            await _client.ActivateAsync();
#endif
        }
    }
}
