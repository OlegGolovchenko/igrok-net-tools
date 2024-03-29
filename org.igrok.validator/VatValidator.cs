﻿//###########################################################################################################
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
using System.Collections.Generic;
using System.Linq;

namespace org.igrok.validator
{
    /// <summary>
    /// Validator for VIES vat numbers of countries Experimental in current version not all validations work
    /// </summary>
    public class VatValidator
    {
        private static ActivationClient _client;
        private static string _activationMail;
        private static bool _activated;

        private static readonly List<VatCountry> _countryList = new List<VatCountry>
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
                    new VatAlphaSpecialCharacter(7, new int[]{ }, 8),
                    new VatAlphaSpecialCharacter(8, new int[]{ }, 9),
                    new VatAlphaSpecialCharacter(7, new int[]{6}, 8),
                    new VatAlphaSpecialCharacter(8, new int[]{7}, 9),
                    new VatAlphaSpecialCharacter(7, new int[]{1}, 8),
                    new VatAlphaSpecialCharacter(8, new int[]{1}, 9)
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
                Lengths = new List<int>{2,3,4,5,6,7,8,9,10},
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
                    new VatAlphaSpecialCharacter(0, new int[]{ }, 9),
                    new VatAlphaSpecialCharacter(8, new int[]{ }, 9),
                    new VatAlphaSpecialCharacter(0, new int[]{ 8 }, 9)
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
                Lengths = new List<int>{9,12},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = "alpha"
            },
            new VatCountry
            {
                Code = "GB",
                Lengths = new List<int>{5},
                SpecialCharacters = new List<IVatSpecialCharacter>(),
                ExcludedCharacters = ""
            }
        };

        /// <summary>
        /// Validates Vat number
        /// </summary>
        /// <param name="vat">Vat number to check for correct format</param>
        public static void ValidateVatAsync(string vat)
        {
            if (_client != null && !_activated)
            {
                throw new InvalidOperationException("Please call activate before using product");
            }

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
            if (country == "GB" && nbPart.Length == 5)
            {
                validator = _countryList.Last(e => e.Code == country);
            }
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
        /// Activates product to be used.
        /// Disclaimer! We are not collecting your data without your consent, your e-mail is the only personal data used in our system.
        /// </summary>
        /// <param name="email">email used to identify your activation</param>
        /// <param name="key">key used for offline activation</param>
        /// <param name="fileLocation">function used to retrieve license file for offline activation if environment varioable is not set</param>
        public static void Activate(string email, string key, Func<string> fileLocation = null)
        {
            _activationMail = email;
            if (_client == null)
            {
                _client = new ActivationClient();
                _client.Init(_activationMail, key);
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                _client.Register((ushort)ProductsEnum.IGNValidator, key);
            }
            else
            {
                if (fileLocation != null)
                {
                    _client.Register((ushort)ProductsEnum.IGNValidator, fileLocation);
                }
            }
            _activated = _client.IsRegistered((ushort)ProductsEnum.IGNValidator);
        }
    }
}
