﻿using System;
using System.Collections.Generic;
using DavWebCreator.Client.Models.Browser.Elements.Events;
using DavWebCreator.Client.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Client.Models.Browser.Elements.Controls
{
    public class BrowserButton : IBrowserElementWithEvent, IBrowserFont
    {
        public Guid Id { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        public BrowserElementType Type { get; set; }
        public BrowserElementAnimationType AnimationType { get; set; }
        public Position Position { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public string BorderWidth { get; set; }
        public string BorderColor { get; set; }
        public BrowserFlexDirection FlexDirection { get; set; }
        public BrowserContentAlign ItemAlignment { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool ScrollBarY { get; set; }
        public bool ScrollBarX { get; set; }
        public bool LoadingIndicator { get; set; }
        public string StyleClass { get; set; }
        public int OrderIndex { get; set; }
        public string RemoteEvent { get; set; }
        public bool Enabled { get; set; }
        public List<BrowserRemoteReturnObject> ReturnObjects { get; set; }
        public string Text { get; set; }
        public string Cursor { get; set; }
        public string Margin { get; set; }
        public string Padding { get; set; }
        public string BackgroundColor { get; set; }
        public string Opacity { get; set; }
        public int Row { get; set; }
    }
}
