﻿using Colin.Core.Modulars.UserInterfaces.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Core.Modulars.UserInterfaces.Prefabs
{
    public class Label : Division
    {
        public Label( string name ) : base( name ) { }
        public DivFontRenderer FontRenderer;
        public override void OnInit( )
        {
            if( FontRenderer == null )
                FontRenderer = BindRenderer<DivFontRenderer>( );
            base.OnInit( );
        }
        public void SetText( string text )
        {
            if( FontRenderer == null )
                FontRenderer = BindRenderer<DivFontRenderer>( );
            FontRenderer.Text = text;
        }
    }
}