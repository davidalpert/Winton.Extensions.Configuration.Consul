// Copyright (c) Winton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.IO;

namespace Winton.Extensions.Configuration.Consul.Parsers
{
    /// <summary>
    ///     Defines how the configuration loaded from Consul should be parsed.
    /// </summary>
    public interface IConfigurationParser
    {
        /// <summary>
        ///     Parse the <see cref="Stream" /> into a dictionary.
        /// </summary>
        /// <param name="baseKey">The base configuration key at which this <paramref name="valueStream"/> was read.</param>
        /// <param name="valueStream">A stream representing the value to parse.</param>
        /// <returns>A dictionary representing the configuration in a flattened form.</returns>
        IDictionary<string, string> Parse(string baseKey, Stream valueStream);
    }
}