using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using MR.Gestures;
using Microsoft.Maui.Controls;

namespace ImageZoom.ViewModels
{
    public class TransformImageViewModelImageTest : TransformViewModel, INotifyPropertyChanged
    {
        protected string[] images = new[] { "https://www.nhc.noaa.gov/xgtwo/two_atl_2d0.png" };
        protected int currentImage = 0;
        private double imageScale = 1.0;
        private double imageTranslationX = 0.0;
        private double imageTranslationY = 0.0;
        private double imageWidth;
        private double imageHeight;

        public ICommand DoubleTappedCommand { get; }

        public string ImageSource
        {
            get { return ImagePath + images[currentImage]; }
        }

        public double ImageScale
        {
            get { return imageScale; }
            set
            {
                if (imageScale != value)
                {
                    imageScale = value;
                    NotifyPropertyChanged(nameof(ImageScale));
                }
            }
        }

        public double ImageTranslationX
        {
            get { return imageTranslationX; }
            set
            {
                if (imageTranslationX != value)
                {
                    imageTranslationX = value;
                    NotifyPropertyChanged(nameof(ImageTranslationX));
                }
            }
        }

        public double ImageTranslationY
        {
            get { return imageTranslationY; }
            set
            {
                if (imageTranslationY != value)
                {
                    imageTranslationY = value;
                    NotifyPropertyChanged(nameof(ImageTranslationY));
                }
            }
        }

        public double ImageWidth
        {
            get { return imageWidth; }
            set
            {
                if (imageWidth != value)
                {
                    imageWidth = value;
                    NotifyPropertyChanged(nameof(ImageWidth));
                }
            }
        }

        public double ImageHeight
        {
            get { return imageHeight; }
            set
            {
                if (imageHeight != value)
                {
                    imageHeight = value;
                    NotifyPropertyChanged(nameof(ImageHeight));
                }
            }
        }

        public TransformImageViewModelImageTest()
            : base()
        {
            DoubleTappedCommand = new Command(OnDoubleTapped);
        }

        private async void OnDoubleTapped()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        protected override void OnPinching(PinchEventArgs e)
        {
            //            base.OnPinching(e);
            ImageScale = e.TotalScale;
        }

        protected override void OnPanning(PanEventArgs e)
        {
            Console.WriteLine($"OnPanning called with DeltaDistance: {e.DeltaDistance.X}, {e.DeltaDistance.Y}");

            ImageTranslationX += e.DeltaDistance.X;
            ImageTranslationY += e.DeltaDistance.Y;

            Console.WriteLine($"After Panning: ImageTranslationX={ImageTranslationX}, ImageTranslationY={ImageTranslationY}");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
