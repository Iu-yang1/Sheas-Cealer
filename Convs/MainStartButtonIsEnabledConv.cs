﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using Sheas_Cealer.Consts;

namespace Sheas_Cealer.Convs;

internal class MainStartButtonIsEnabledConv : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        string browserPath = (string)values[0];
        string extraArgs = (string)values[1];

        return File.Exists(browserPath) && Path.GetFileName(browserPath).ToLowerInvariant().EndsWith(".exe") && MainConst.ExtraArgsRegex().IsMatch(extraArgs);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}