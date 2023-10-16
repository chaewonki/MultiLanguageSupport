using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using WpfApp1.Languages;

namespace WpfApp1
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private DynamicLanguageResource? _dr;

        public MainWindowViewModel()
        {
            _dr = Application.Current.Resources["DynamicLanguageResource"] as DynamicLanguageResource;
        }

        [RelayCommand]
        private void LanguageChange(string language)
        {
            switch (language)
            {
                case "english":
                    _dr!.ChangeLanguage("en-US");
                    break;
                case "korean":
                    _dr!.ChangeLanguage("ko-kr");
                    break;
            }
        }
    }
}
