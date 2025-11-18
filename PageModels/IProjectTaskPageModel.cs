using CommunityToolkit.Mvvm.Input;
using wsimbanaS6.Models;

namespace wsimbanaS6.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}