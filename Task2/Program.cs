using Task2.controller;
using Task2.model;
using Task2.view;


const string sweCurrencyName = "kr";
MoviePriceService moviePriceService = new(sweCurrencyName);
AppMenuView appMenuView = new();
AppMenuController appMenuController = new(appMenuView, moviePriceService);
appMenuController.StartMainMenu();
