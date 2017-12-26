using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4Game
{
    class Globalization
    {
        private static string language = "hu";

        public static ResourceDictionary SetLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (language)
            {
                case "en":
                    dict.Source = new Uri("/Resources/EngLanguageResource.xaml",
                                  UriKind.Relative);
                    break;
                case "hu":
                    dict.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    break;
            }
            return dict;
            //this.Resources.MergedDictionaries.Add(dict);
        }

        public static string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

    }
}
