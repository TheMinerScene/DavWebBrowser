﻿using System;
using System.Collections.Generic;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.Models.Browser.Components;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;
using DavWebCreator.Server.Models.Browser.Elements.Controls;
using DavWebCreator.Server.Models.Browser.Elements.Textboxes;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace DavWebCreator.Server.Models.Browser
{
    [Serializable]
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public List<BrowserText> Texts { get; set; }
        public List<BrowserTextBox> TextBoxes {get; set; }
        public List<BrowserPasswordTextBox> PasswordTextBoxes { get; set; }
        public List<BrowserTitle> Titles { get; set; }
        public List<BrowserButton> Buttons { get; set; }
        public List<BrowserCard> Cards { get; set; }
        public List<BrowserCheckBox> CheckBoxes { get; set; }
        public List<BrowserDropDown> DropDowns { get; set; }
        public BrowserYesNoDialog YesNoDialog { get; private set; }

        private int AddedElements = 0;
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        public Browser()
        {

        }

        public Browser(string title, BrowserType type, Position position, string width, string height)
        {
            this.Id = Guid.NewGuid();
            this.Type = type;
            this.Position = position;
            this.Texts = new List<BrowserText>();
            this.TextBoxes = new List<BrowserTextBox>();
            this.PasswordTextBoxes = new List<BrowserPasswordTextBox>();
            this.Titles = new List<BrowserTitle>();
            this.Buttons = new List<BrowserButton>();
            this.Cards = new List<BrowserCard>();
            this.CheckBoxes = new List<BrowserCheckBox>();
            this.DropDowns = new List<BrowserDropDown>();
            this.Width = width;
            this.Height = height;

            switch (type)
            {
                case BrowserType.Custom:
                    this.Path = $"package://statics/DavWebCreator/Custom/Template.html";
                    break;
                case BrowserType.YesNoDialog:
                    this.Path = $"package://statics/DavWebCreator/Custom/Blank_Template.html";
               
                    break;
            }
        }

        public void AddYesNoDialog(string remoteEvent, string title, string subTitle, string text, string successButtonText, string dismissButtonText)
        {
            BrowserYesNoDialog yesNoDialog = new BrowserYesNoDialog(Position.Mid, remoteEvent, title, subTitle, text, successButtonText, dismissButtonText);
            this.YesNoDialog = yesNoDialog;
        }
        

        public void OpenBrowser(Client player)
        {
            player.TriggerEvent("INITIALIZE_CEF_BROWSER", JsonConvert.SerializeObject(this));
        }

        public void AddElement(BrowserElement element)
        {
            element.OrderIndex = AddedElements++;
            switch (element.Type)
            {
                case BrowserElementType.Button:
                    BrowserButton button = element as BrowserButton;
                    Buttons.Add(button);
                    break;
                case BrowserElementType.Title:
                    BrowserTitle title = element as BrowserTitle;
                    Titles.Add(title);
                    break;
                case BrowserElementType.Text:
                    BrowserText text = element as BrowserText;
                    Texts.Add(text);
                    break;
                case BrowserElementType.TextBox:
                    BrowserTextBox textBox = element as BrowserTextBox;
                    TextBoxes.Add(textBox);
                    break;
                case BrowserElementType.Card:
                    BrowserCard card = element as BrowserCard;
                    Cards.Add(card);
                    break;
                case BrowserElementType.Password:
                    BrowserPasswordTextBox passwordTextBox = element as BrowserPasswordTextBox;
                    PasswordTextBoxes.Add(passwordTextBox);
                    break;
                case BrowserElementType.YesNoDialog:
                    BrowserYesNoDialog yesNoDialog = element as BrowserYesNoDialog;
                    YesNoDialog = yesNoDialog;
                    break;
                case BrowserElementType.Checkbox:
                    BrowserCheckBox checkBox = element as BrowserCheckBox;
                    CheckBoxes.Add(checkBox);
                    break;
                case BrowserElementType.DropDown:
                    BrowserDropDown dropDown = element as BrowserDropDown;
                    DropDowns.Add(dropDown);
                    break;
                default:
                    NAPI.Util.ConsoleOutput($"UNKNOWN ELEMENT OF TYPE {element.Type}");
                    break;
            }
          
        }

        public override string ToString()
        {
            return string.Format(this.Id + " | " + this.Path + " | " + this.Position + " | " + this.Type);
        }
    }
}
