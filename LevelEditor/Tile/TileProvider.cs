using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LevelEditor.Tile
{
    public class TileProvider : ITileProvider
    {
        private const int TileWidth = 16;

        private static readonly BitmapSource BitmapSource =
            CreateBitmapSource(new Uri(@"pack://application:,,,/Assets/tileset.png"));

        private static CroppedBitmap GetTile(int x, int y) => new CroppedBitmap(BitmapSource, new Int32Rect(x * TileWidth, y * TileWidth, TileWidth, TileWidth));

        private static BitmapSource CreateBitmapSource(Uri path)
        {
            var image = new BitmapImage();
            using (var stream = Application.GetResourceStream(path)?.Stream)
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.UriSource = path;
                image.EndInit();
                image.Freeze();
            }
            return image;
        }

        private TileProvider() { }

        private static TileProvider _instance;
        public static TileProvider Instance => _instance ?? (_instance = new TileProvider());

        private const CroppedBitmap Void = null;
        private static readonly CroppedBitmap Grass = GetTile(3, 7);
        private static readonly CroppedBitmap Flowers = GetTile(3, 5);
        private static readonly CroppedBitmap Water = GetTile(2, 1);
        private static readonly CroppedBitmap Soil = GetTile(3, 13);

        public CroppedBitmap Get(TileType type)
        {
            switch (type)
            {
                case TileType.Void: return Void;
                case TileType.Water: return Water;
                case TileType.Grass: return Grass;
                case TileType.Flowers: return Flowers;
                case TileType.Soil: return Soil;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, @"This tile type has not been assigned yet.");
            }
        }
    }
}
