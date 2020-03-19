﻿using System;
using NetTopologySuite.Geometries;
using NetTopologySuite.Shape.Fractal;

namespace NetTopologySuite.Index.HPRtree
{
    public class HilbertEncoder
    {
        private readonly int _level;
        private readonly double _minx;
        private readonly double _miny;
        private readonly double _strideX;
        private readonly double _strideY;

        public HilbertEncoder(int level, Envelope extent)
        {
            this._level = level;
            int hside = (int)Math.Pow(2, level);

            _minx = extent.MinX;
            double extentX = extent.Width;
            _strideX = extentX / hside;

            _miny = extent.MinX;
            double extentY = extent.Height;
            _strideY = extentY / hside;
        }

        public int Encode(Envelope env)
        {
            double midx = env.Width / 2 + env.MinX;
            int x = (int)((midx - _minx) / _strideX);

            double midy = env.Height / 2 + env.MinY;
            int y = (int)((midy - _miny) / _strideY);

            return HilbertCode.Encode(_level, x, y);
        }

    }
}
