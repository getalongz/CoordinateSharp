﻿/*
CoordinateSharp is a .NET standard library that is intended to ease geographic coordinate 
format conversions and location based celestial calculations.
https://github.com/Tronald/CoordinateSharp

Many celestial formulas in this library are based on Jean Meeus's 
Astronomical Algorithms (2nd Edition). Comments that reference only a chapter
are referring to this work.

License

Copyright (C) 2019, Signature Group, LLC
  
This program is free software; you can redistribute it and/or modify it under the terms of the GNU Affero General Public License version 3 
as published by the Free Software Foundation with the addition of the following permission added to Section 15 as permitted in Section 7(a): 
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY Signature Group, LLC. Signature Group, LLC DISCLAIMS THE WARRANTY OF 
NON INFRINGEMENT OF THIRD PARTY RIGHTS.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details. You should have received a copy of the GNU 
Affero General Public License along with this program; if not, see http://www.gnu.org/licenses or write to the 
Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA, 02110-1301 USA, or download the license from the following URL:

https://www.gnu.org/licenses/agpl-3.0.html

The interactive user interfaces in modified source and object code versions of this program must display Appropriate Legal Notices, 
as required under Section 5 of the GNU Affero General Public License.

You can be released from the requirements of the license by purchasing a commercial license. Buying such a license is mandatory 
as soon as you develop commercial activities involving the CoordinateSharp software without disclosing the source code of your own applications. 
These activities include: offering paid services to customers as an ASP, on the fly location based calculations in a web application, 
or shipping CoordinateSharp with a closed source product.

For more information, please contact Signature Group, LLC at this address: sales@signatgroup.com
*/
using System;

namespace CoordinateSharp
{
    public partial class Cartesian
    {
        /// <summary>
        /// Create a Cartesian Object
        /// </summary>
        /// <param name="c"></param>
        public Cartesian(Coordinate c)
        {
            //formulas:
            x = Math.Cos(c.Latitude.ToRadians()) * Math.Cos(c.Longitude.ToRadians());
            y = Math.Cos(c.Latitude.ToRadians()) * Math.Sin(c.Longitude.ToRadians());
            z = Math.Sin(c.Latitude.ToRadians());
        }
        /// <summary>
        /// Create a Cartesian Object
        /// </summary>
        /// <param name="xc">X</param>
        /// <param name="yc">Y</param>
        /// <param name="zc">Z</param>
        public Cartesian(double xc, double yc, double zc)
        {
            //formulas:
            x = xc;
            y = yc;
            z = zc;
        }

        /// <summary>
        /// Updates Cartesian Values
        /// </summary>
        /// <param name="c"></param>
        public void ToCartesian(Coordinate c)
        {
            x = Math.Cos(c.Latitude.ToRadians()) * Math.Cos(c.Longitude.ToRadians());
            y = Math.Cos(c.Latitude.ToRadians()) * Math.Sin(c.Longitude.ToRadians());
            z = Math.Sin(c.Latitude.ToRadians());
        }
      
        /// <summary>
        /// Returns a Lat Long Coordinate object based on the provided Cartesian Coordinate
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns></returns>
        public static Coordinate CartesianToLatLong(double x, double y, double z)
        {
            double lon = Math.Atan2(y, x);
            double hyp = Math.Sqrt(x * x + y * y);
            double lat = Math.Atan2(z, hyp);

            double Lat = lat * (180 / Math.PI);
            double Lon = lon * (180 / Math.PI);
            return new Coordinate(Lat, Lon);
        }
        /// <summary>
        /// Returns a Lat Long Coordinate object based on the provided Cartesian Coordinate
        /// </summary>
        /// <param name="cart">Cartesian Coordinate</param>
        /// <returns></returns>
        public static Coordinate CartesianToLatLong(Cartesian cart)
        {
            double x = cart.X;
            double y = cart.Y;
            double z = cart.Z;

            double lon = Math.Atan2(y, x);
            double hyp = Math.Sqrt(x * x + y * y);
            double lat = Math.Atan2(z, hyp);

            double Lat = lat * (180 / Math.PI);
            double Lon = lon * (180 / Math.PI);
            return new Coordinate(Lat, Lon);
        }

        /// <summary>
        /// Cartesian Default String Format
        /// </summary>
        /// <returns>Cartesian Formatted Coordinate String</returns>
        /// <returns>Values rounded to the 8th place</returns>
        public override string ToString()
        {
            return Math.Round(x,8).ToString() + " " + Math.Round(y, 8).ToString() + " " + Math.Round(z, 8).ToString();
        }
    }
}
