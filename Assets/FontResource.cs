﻿using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace Colin.Core.Assets
{
    public class FontResource : IGameResource
    {
        public static FontSystem Unifont { get; private set; }

        public static FontSystem GlowSans { get; private set; }

        public string Name => "字体资源";

        public float Progress { get; set; }

        private static Dictionary<string, FontSystem> _fonts = new Dictionary<string, FontSystem>( );
        public static Dictionary<string, FontSystem> Fonts => _fonts;

        public void LoadResource( )
        {
            if(!Directory.Exists( string.Concat( EngineInfo.Engine.Content.RootDirectory, "/Fonts" ) ))
                return;
            FontSystem _font;
            string _fileName;
            string[ ] _fontFileNames = Directory.GetFiles( string.Concat( EngineInfo.Engine.Content.RootDirectory, "/Textures" ), "*.xnb*", SearchOption.AllDirectories );
            for(int count = 0 ; count < _fontFileNames.Length ; count++)
            {
                Progress = count / _fontFileNames.Length + 1 / _fontFileNames.Length;
                _font = new FontSystem( );
                _font.AddFont( File.ReadAllBytes( _fontFileNames[count] ));
                _fileName = IGameResource.ArrangementPath( _fontFileNames[count] );
                _fonts.Add( _fileName , _font );
            }
        }
    }
}