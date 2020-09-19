using Shared.Models;

namespace Shared.Protocol.Response.Game
{
    public class OnEconomyResponse : BaseResponse
    {
        public CurrencyDto Currency;
        
        public OnEconomyResponse()
        {
            Type = ResponseType.OnEconomyResponse;
        }
    }
}