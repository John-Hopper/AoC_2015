
using System;
using System.Collections.Generic;

namespace Day_02
{
    class Present
    {
        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Side1
        {
            get { return Length * Width; }
            set { }
        }

        public int Side2
        {
            get { return Width * Height; }
            set { }
        }

        public int Side3
        {
            get { return Height * Length; }
            set { }
        }

        public int WrappingSlack
        {
            get { return Math.Min(Side1, Math.Min(Side2, Side3)); }
            set { }
        }

        public int TotalWrapping
        {
            get { return ((Side1 + Side2 + Side3) * 2) + WrappingSlack; }
            set { }
        }

        public int BiggestDimension
        {
            get { return Math.Max(Length, Math.Max(Width, Height)); }
            set { }
        }

        public int PresentRibbonLength
        {
            get { return ((Length + Width + Height) * 2) - (BiggestDimension * 2); }
            set { }
        }

        public int BowRibbonLength
        {
            get { return Length * Width * Height; }
            set { }
        }

        public int TotalRibbon
        {
            get { return PresentRibbonLength + BowRibbonLength; }
            set { }
        }

    }

}
