using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;
using WpfApp1.Languages.Strings;

namespace WpfApp1.Languages
{
    public class DynamicLanguageResource : DynamicObject
    {
        private readonly ResourceManager? _resourceManager;
        protected CultureInfo _cultureInfo = new("");

        public DynamicLanguageResource()
        {
            _resourceManager = new ResourceManager(typeof(LanguageResource));
        }

        public string this[string id]
        {
            get
            {
                if (string.IsNullOrEmpty(id)) return null;
                string value = _resourceManager!.GetString(id, _cultureInfo)!;
                if (string.IsNullOrEmpty(value))
                {
                    value = id;
                }
                return value;
            }
        }

        public void ChangeLanguage(string languageCode)
        {
            _cultureInfo = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = _cultureInfo;
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            foreach (Window window in Application.Current.Windows.Cast<Window>())
            {
                if (!window.AllowsTransparency)
                {
                    window.Language = XmlLanguage.GetLanguage(_cultureInfo.Name);
                }
            }
        }

    }
}
