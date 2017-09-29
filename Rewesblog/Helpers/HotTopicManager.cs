using Rewesblog.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Helpers
{
    public static class HotTopicManager
    {
        public const int SchriftgrößeMin = 10;
        public const int SchriftgrößeMax = 32;

        public static List<Models.HotTopicElement> Styleelements(List<Models.HotTopicElement> elements)
        {
            elements = elements.OrderByDescending(x => x.Wichtung).Take(20).ToList();
            var min = elements[elements.Count - 1].Wichtung;
            var max = elements[0].Wichtung;
            foreach (var element in elements)
            {
                var differenz = max - min;
                var klein = element.Wichtung - min;
                var prozent = (100 * klein) / differenz;
                var schriftdifferenz = SchriftgrößeMax - SchriftgrößeMin;
                var schrift = ((schriftdifferenz * prozent) / 100)+SchriftgrößeMin;
                var rest = schrift % 2;
                element.Schriftgröße = ((int)schrift / 2)*2;
                if(rest >= 1.0)
                {
                    element.Schriftgröße += 2;
                }
                //element.Schriftgröße = (int) Math.Round(schrift);

                //if (prozent<=25)
                //{
                //    element.Schriftfarbe = Color.FromArgb(1, 214, 100, 100);
                //}
                //if (prozent>25 && prozent <= 50)
                //{
                //    element.Schriftfarbe = Color.FromArgb(1, 176, 56, 56);
                //}
                //if (prozent>50 && prozent <= 75)
                //{
                //    element.Schriftfarbe = Color.FromArgb(1, 138, 23, 23);
                //}
                //if (prozent>75 && prozent <= 100)
                //{
                //    element.Schriftfarbe = Color.FromArgb(1, 95, 0, 0);
                //}
                if (prozent <= 25)
                {
                    element.Schriftfarbe = Color.FromArgb(1, 119, 119, 119);
                }
                if (prozent > 25 && prozent <= 50)
                {
                    element.Schriftfarbe = Color.FromArgb(1, 42, 171, 210);
                }
                if (prozent > 50 && prozent <= 75)
                {
                    element.Schriftfarbe = Color.FromArgb(1, 65, 150, 65);
                }
                if (prozent > 75 && prozent <= 100)
                {
                    element.Schriftfarbe = Color.FromArgb(1, 193, 46, 42);
                }
            }
            elements.Shuffle();
            return elements;
        }
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
