﻿// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace McMaster.Extensions.CommandLineUtils.Abstractions
{
    using System;
    using System.Globalization;

    internal class Int32ValueParser : IValueParser
    {
        private Int32ValueParser()
        { }

        public static Int32ValueParser Singleton { get; } = new Int32ValueParser();

        public Type TargetType { get; } = typeof(int);

        public object Parse(string argName, string value, CultureInfo culture)
        {
            if (!int.TryParse(value, NumberStyles.Integer, culture.NumberFormat, out var result))
            {
                throw new FormatException($"Invalid value specified for {argName}. '{value}' is not a valid number.");
            }

            return result;
        }
    }
}
