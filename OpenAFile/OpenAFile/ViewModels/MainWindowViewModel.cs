using OpenAFile.Logic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace OpenAFile.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand OpenFile { get; }
        public ICommand OpenFiles { get; }

        [Reactive]
        public string FilePath { get; private set; }

        [Reactive]
        public IEnumerable<string> FilePaths { get; private set; }

        public MainWindowViewModel()
        {
            var openFileAdapter = new FileDialogAdapter();

            OpenFile = ReactiveCommand.Create(() => FilePath = openFileAdapter.OpenFile());
            OpenFiles = ReactiveCommand.Create(() => FilePaths = openFileAdapter.OpenFiles());

            FilePath = string.Empty;
            FilePaths = Enumerable.Empty<string>();
        }
    }
}
