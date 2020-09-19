using Fleck;
using Shared.Protocol.Request;
using Shared.Protocol.Response;

namespace Asgard.Commands
{
    public interface IBaseCommand
    {
        void Execute(string id, string request);
    }
}