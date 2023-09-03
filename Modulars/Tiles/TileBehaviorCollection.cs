﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Modulars.Tiles
{
    public class TileBehaviorCollection
    {
        internal Tile tile;
        public Tile Tile => tile;
        public int Width { get; }
        public int Height { get; }
        public int Count => _behaviors.Length;
        private TileBehavior[ ] _behaviors;
        public TileBehavior this[int index] => _behaviors[index];
        public TileBehavior this[int x, int y] => _behaviors[x + y * Width];
        public TileBehaviorCollection( int width, int height )
        {
            Width = width;
            Height = height;
            _behaviors = new TileBehavior[width * height];
            for( int count = 0 ; count < _behaviors.Length - 1 ; count++ )
            {
                _behaviors[count] = new TileBehavior( );
            }
        }
        public TileBehaviorCollection( Point size )
        {
            Width = size.X;
            Height = size.Y;
            _behaviors = new TileBehavior[size.X * size.Y];
            for( int count = 0 ; count < _behaviors.Length ; count++ )
            {
                _behaviors[count] = new TileBehavior( );
            }
        }

        public void SetBehavior<T>( int x, int y ) where T : TileBehavior, new()
        {
            _behaviors[x + y * Width] = new T( );
            _behaviors[x + y * Width]._tile = tile;
            T _behavior = _behaviors[x + y * Width] as T;
            _behavior._tile = tile;
            _behavior.coordinateX = x;
            _behavior.coordinateY = y;
            _behavior.id = x + y * Width;
            _behavior.SetDefaults( );
            _behavior.DoRefresh( 1 );
        }

        public void SetBehavior( TileBehavior behavior , int x, int y )
        {
            _behaviors[x + y * Width] = behavior;
            _behaviors[x + y * Width]._tile = tile;
            _behaviors[x + y * Width].coordinateX = x;
            _behaviors[x + y * Width].coordinateY = y;
            _behaviors[x + y * Width].id = x + y * Width;
            _behaviors[x + y * Width].SetDefaults( );
            _behaviors[x + y * Width].DoRefresh( 1 );
        }

        public void SetBehavior( TileBehavior behavior, int index )
        {
            _behaviors[index] = behavior;
            _behaviors[index]._tile = tile;
            _behaviors[index].coordinateX = index % Height;
            _behaviors[index].coordinateY = index / Width;
            _behaviors[index].id = index;
            _behaviors[index].SetDefaults( );
            _behaviors[index].DoRefresh( 1 );
        }

        public void ClearBehavior( int x, int y )
        {
            _behaviors[x + y * Width].DoRefresh( 1 );
            _behaviors[x + y * Width] = new TileBehavior( );
        }
    }
}