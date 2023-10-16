using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Languages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DynamicLanguageResource dynamicLanguageResource = new DynamicLanguageResource();
            Resources.Add("DynamicLanguageResource", dynamicLanguageResource);
        }
    }
}
