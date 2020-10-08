﻿// Copyright (C) 2013 Lex Li
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

/*
 * Created by SharpDevelop.
 * User: Lex
 * Date: 3/3/2013
 * Time: 11:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Net.NetworkInformation;
using Lextm.SharpSnmpLib;
using NooN.SnmpEngine.Pipeline;

namespace NooN.SnmpEngine
{
    /// <summary>
    /// ifSpeed.
    /// </summary>
    internal sealed class IfSpeed : ScalarObject
    {
        private readonly NetworkInterface _networkInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfSpeed"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="networkInterface">The network interface.</param>
        public IfSpeed(int index, NetworkInterface networkInterface)
            : base("1.3.6.1.2.1.2.2.1.5.{0}", index)
        {
            _networkInterface = networkInterface;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        /// <exception cref="AccessFailureException"></exception>
        public override ISnmpData Data
        {
            get
            {
                try
                {
                    return new Gauge32(_networkInterface.Speed);
                }
                catch (PlatformNotSupportedException)
                {
                    return new Gauge32(0);
                }
            }

            set
            { throw new AccessFailureException(); }
        }
    }
}