using Task2.controller;
using Task2.model;
using Task2.view;

MoviePriceService moviePriceService = new();
AppMenuView appView = new();
AppMenuController app = new(appView, moviePriceService);
app.StartMainMenu();
