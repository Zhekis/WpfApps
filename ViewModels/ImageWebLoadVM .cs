using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp1.Ifrastructure;

namespace WpfApp1.ViewModels
{
    internal class ImageWebLoadVM : OnPropertyChangedClass
    {
        static ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        private ImageSource webImage;
        private RelayCommand _loadImageCommand;

        public ImageSource WebImage { get => webImage; set { webImage = value; OnPropertyChanged(); } }
        public RelayCommand LoadImageCommand => _loadImageCommand ?? (_loadImageCommand = new RelayCommand(LoadImageMetod, LoadImageCanMetod));

        /// <summary>Проверка допустимости пути - не реализована.
        /// Стоит "заглушка</summary>
        private bool LoadImageCanMetod(object parameter) => true;

        private void LoadImageMetod(object parameter)
        {
            if (LoadImageCanMetod(parameter))
            {
                WebImage = (ImageSource)imageSourceConverter.ConvertFrom(parameter);
            }
        }
    }
}
