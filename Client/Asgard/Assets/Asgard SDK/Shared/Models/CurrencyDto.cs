using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class CurrencyDto
    {
        public List<CurrencyItemDto> Currencies;
    }

    [Serializable]
    public class CurrencyItemDto
    {
        public string Id;
        public string Key;
        public long Quantity;
    }
}