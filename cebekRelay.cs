/// <copyright file="cebekRelay.cs" company="DVMsoft">
/// Script in C# to activate the two relay outputs, wait one second and deactivate the two outputs.
/// Copyright (C) 2015  Miguel Jimenez - DVMsoft - http://www.dvmsoft.es
/// 
/// This program is free software; you can redistribute it and/or
/// modify it under the terms of the GNU General Public License
/// as published by the Free Software Foundation; either version 2
/// of the License, or (at your option) any later version.
/// 
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
/// 
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
/// </copyright>
/// <author>Miguel Jimenez</author>
/// <email>miguel@dvmsoft.es</email>
/// <date>2015-09-23</date>
/// <summary>Script to active the two relay outputs, wait one second and deactivate the two outputs</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cebek_DLL_T100;
using System.Threading;

namespace Cebek_DLL_T100
{
    class Program
    {
        private static T100_dll instance;
        private static bool active = (bool) true;

        static void Main(string[] args)
        {
            instance = new Cebek_DLL_T100.T100_dll();

            instance.PortName = "COM4"; //Change to your port
            instance.BaudRate = 115200;
            instance.DataBits = 8;
            instance.Connect();

            //First deactivate two outputs
            instance.Reset();

            //Active the two outputs
            instance.WriteOutput_1(ref active);
            instance.WriteOutput_2(ref active);

            //Wait one second with the outputs active
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);

            //Deactivate two outputs and disconect
            instance.Reset();
            instance.Disconnect();
        }
    }
}
