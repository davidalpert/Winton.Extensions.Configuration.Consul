// Copyright (c) Winton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Winton.Extensions.Configuration.Consul.Parsers
{
    /// <inheritdoc />
    /// <summary>
    ///     Implementation of <see cref="IConfigurationParser" /> for parsing JSON Configuration.
    /// </summary>
    public sealed class JsonConfigurationParser : IConfigurationParser
    {
        /// <inheritdoc />
        public IDictionary<string, string> Parse(string baseKey, Stream valueStream)
        {
            return new ConfigurationBuilder()
                .AddJsonStream(valueStream)
                .Build()
                .AsEnumerable()
                .ToDictionary(pair => $"{baseKey}/{pair.Key}", pair => pair.Value);
        }
    }
}