using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4Game
{
    public enum Language
    {
        HUN, ENG
    }
    class Globalization
    {
        private static Language currentLanguage = Language.HUN;
        public static ResourceDictionary SetLanguage()
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (currentLanguage)
            {
                case Language.ENG:
                    dictionary.Source = new Uri("/Resources/EngLanguageResource.xaml",
                                  UriKind.Relative);                    
                    break;
                case Language.HUN:
                    dictionary.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    break;
            }
            return dictionary;
        }

        public static ResourceDictionary SetLanguage(Language language)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (language)
            {
                case Language.ENG:
                    dictionary.Source = new Uri("/Resources/EngLanguageResource.xaml",
                                  UriKind.Relative);
                    currentLanguage = Language.ENG;
                    break;
                case Language.HUN:
                    dictionary.Source = new Uri("/Resources/HunLanguageResource.xaml",
                                      UriKind.Relative);
                    currentLanguage = Language.HUN;
                    break;
            }
            return dictionary;
        }

        public static string getLanguage()
        {
            switch (currentLanguage)
            {
                case Language.ENG:
                    return "ENG";
                    

                case Language.HUN:
                    return "HUN";
                    
                default:
                    return "HUN";
                   
            }
        }
    }
}
