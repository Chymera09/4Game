using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Game
{
    static class ColorPalette
    {
        public const byte alpha = 0xFF;
        public static readonly byte[,] color = new byte[30, 3] { { 0xFF, 0xFF, 0xFF }, { 0x39, 0xE6, 0x00 }, { 0xFF, 0xEA, 0x00 }, { 0x1A, 0x1A, 0xFF }, { 0xFF, 0x00, 0x00 },
                                                                  { 0x7F, 0x8C, 0x8D }, { 0x7D, 0x3C, 0x98 }, { 0x23, 0x9B, 0x56 }, { 0xF1, 0xC4, 0x0F }, { 0x2E, 0x86, 0xC1 }, 
                                                                  { 0xCB, 0x43, 0x35 }, { 0x42, 0x49, 0x49 }, { 0x4A, 0x23, 0x5A }, { 0x14, 0x5A, 0x32 }, { 0xF3, 0x9C, 0x12 },
                                                                  { 0x34, 0x49, 0x5E }, { 0x92, 0x2B, 0x21 }, { 0x29, 0x29, 0x29 }, { 0x3A, 0x0A, 0x4E }, { 0x15, 0x4B, 0x0C },
                                                                  { 0x73, 0x4D, 0x03 }, { 0x07, 0x0F, 0x4F }, { 0x56, 0x0C, 0x01 }, { 0x00, 0x00, 0x00 }, { 0x26, 0x0A, 0x32 },
                                                                  { 0xBD, 0xF6, 0xA8 }, { 0xF9, 0xFA, 0xA5 }, { 0xA5, 0xFA, 0xF0 }, { 0xFA, 0x88, 0x9D }, { 0xCD, 0x88, 0xFA }};

        public static readonly string[] colors = new string[] {"#FFFFFF", "#39E600", "#FFEA00", "#1A1AFF", "#FF0000",
                                                               "#7F8C8D", "#7D3C98", "#239B56", "#F1C40F", "#2E86C1",
                                                               "#CB4335", "#424949", "#4A235A", "#145A32", "#F39C12",
                                                               "#34495E", "#922B21", "#292929", "#3A0A4E", "#154B0C",
                                                               "#734D03", "#070F4F", "#560C01", "#000000", "#260A32",
                                                               "#BDF6A8", "#F9FAA5", "#A5FAF0", "#FA889D", "#CD88FA"};
    };
        //public ColorPalette()
        //{
        //    //fehér
        //    colors[0, 0] = 0xFF;
        //    colors[0, 1] = 0xFF;
        //    colors[0, 2] = 0xFF;

        //    //zöld
        //    colors[1, 0] = 0x33;
        //    colors[1, 1] = 0xCC;
        //    colors[1, 2] = 0x33;

        //    //Sárga
        //    colors[2, 0] = 0xFF;
        //    colors[2, 1] = 0xE4;
        //    colors[2, 2] = 0x1A;

        //    //kék
        //    colors[0, 0] = 0x1A;
        //    colors[0, 1] = 0x1A;
        //    colors[0, 2] = 0xFF;

        //    //piros
        //    colors[0, 0] = 0xFF;
        //    colors[0, 1] = 0x00;
        //    colors[0, 2] = 0x00;


        //}

        //btn.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0));
        //#AARRGGBB
        //Alpha channel értékek
        //100% — FF
        //95% — F2
        //90% — E6
        //85% — D9
        //80% — CC
        //75% — BF
        //70% — B3
        //65% — A6
        //60% — 99
        //55% — 8C
        //50% — 80
        //45% — 73
        //40% — 66
        //35% — 59
        //30% — 4D
        //25% — 40
        //20% — 33
        //15% — 26
        //10% — 1A
        //5% — 0D
        //0% — 00
    
}
