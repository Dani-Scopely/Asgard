using Modules.UI.Manager;

namespace StateMachines
{
    public interface IUIState
    {
        IUIState DoState(ref UIManager uiManager);
    }
}