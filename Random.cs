using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4Game
{
    class Random
    {
        public static string getRandom()
        {
            WebClient client = new WebClient();
            try
            {
                byte rnd = Convert.ToByte((client.DownloadString("https://www.random.org/integers/?num=1&min=2&max=30&col=1&base=10&format=plain&rnd=new")));
                return rnd.ToString();            
            }
            catch
            {
                System.Random rnd = new System.Random();
                return (rnd.Next(2, 31)).ToString();
            }
        }
    }
}
