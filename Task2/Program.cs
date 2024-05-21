using Task2.controller;
using Task2.view;

AppMenuView appView = new();
AppMenuController app = new(appView);
app.StartMainMenu();
