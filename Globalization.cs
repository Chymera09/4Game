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
        public static ResourceDictionary SetLanguage(string language = "hu")
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (language)
            {
                case "en":
                    dictionary.Source = new Uri("/Resources/EngLanguageResource.xaml",
                                  UriKind.Relative);
                    break;
                case "hu":
                    dictionary.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    break;
            }
            return dictionary;
        }
    }
}
