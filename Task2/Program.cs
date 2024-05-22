using Task2.controller;
using Task2.IO;
using Task2.model;
using Task2.view;

AppConsole console = new();

const string sweCurrencyName = "kr";
MovieView movieView = new(console);
MovieService movieService = new(sweCurrencyName);
MovieController movieController = new(movieView, movieService);

TextWizardView textWizardView = new(console);
TextWizardService textWizardService = new();
TextWizardController textWizardController = new(textWizardView, textWizardService);

AppMenuView appMenuView = new(console);
AppMenuController appMenuController = new(
    appMenuView,
    movieController,
    textWizardController
);
appMenuController.StartMainMenu();
