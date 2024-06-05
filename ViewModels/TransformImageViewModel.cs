using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using MR.Gestures;
using Microsoft.Maui.Controls;

namespace ImageZoom.ViewModels
{
    public class TransformImageViewModel : TransformViewModel, INotifyPropertyChanged
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

        public TransformImageViewModel()
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
            //            base.OnPanning(e);

            double newTranslationX = ImageTranslationX + e.DeltaDistance.X;
            double newTranslationY = ImageTranslationY + e.DeltaDistance.Y;

            // Apply constraints to allow panning up to 80% off the screen
            double maxTranslationX = (ImageWidth * ImageScale - ImageWidth) * 0.8;
            double maxTranslationY = (ImageHeight * ImageScale - ImageHeight) * 0.8;

            Console.WriteLine($"ImageWidth: {ImageWidth}, ImageHeight: {ImageHeight}, ImageScale: {ImageScale}");
            Console.WriteLine($"maxTranslationX: {maxTranslationX}, maxTranslationY: {maxTranslationY}");
            Console.WriteLine($"Before Constraint: newTranslationX={newTranslationX}, newTranslationY={newTranslationY}");

            ImageTranslationX = Math.Max(-maxTranslationX, Math.Min(maxTranslationX, newTranslationX));
            ImageTranslationY = Math.Max(-maxTranslationY, Math.Min(maxTranslationY, newTranslationY));

            Console.WriteLine($"After Constraint: ImageTranslationX={ImageTranslationX}, ImageTranslationY={ImageTranslationY}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
