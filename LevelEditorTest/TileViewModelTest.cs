using System;
using IO;
using LevelEditor.Tile;
using LevelEditor.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelEditorTest
{
    [TestClass]
    public class TileViewModelTest
    {
        [TestMethod]
        public void TestSerialize()
        {
            const uint width = 10;
            const uint height = width;
            const uint x = 100;
            const uint y = 10;
            const TileType type = TileType.Void;
            var sut = new TileViewModel(x, y, width, height, type, null);
            var expected = new Tile(x / width, y / height, type);
            var actual = sut.Serialize();
            Assert.IsTrue(expected.X == actual.X && expected.Y == actual.Y && expected.Type == actual.Type);
        }
    }
}
