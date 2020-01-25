using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using SampleApp.Infrastructure;
using SampleApp.ViewModels;

namespace SampleApp
{
    public class SectionIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Section s)
            {
                Symbol symbol = Symbol.Clear;

                if (s.ViewModelType == typeof(SampleSectionViewModel))
                {
                    return symbol == Symbol.Home;
                }

                return new SymbolIcon(symbol);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}