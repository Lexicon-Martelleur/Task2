using Task2.controller;
using Task2.IO;
using Task2.model;
using Task2.view;
using Task2.IO;


const string sweCurrencyName = "kr";
MoviePriceService moviePriceService = new(sweCurrencyName);
TextService textService = new();
AppConsole console = new();
AppMenuView appMenuView = new(console);
AppMenuController appMenuController = new(appMenuView, moviePriceService, textService);
appMenuController.StartMainMenu();
