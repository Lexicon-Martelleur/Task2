using Task2.controller;
using Task2.IO;
using Task2.model;
using Task2.view;

namespace Task2.factory;

/// <summary>
/// Factory class used to create a <see cref="AppMenuController"></see>.
/// </summary>
internal class MainMenuFactory
{
    /// <summary>
    /// Used to create default <see cref="AppMenuController"></see>.
    /// </summary>
    /// <returns></returns>
    internal AppMenuController CreateDefaultMainMenu()
    {
        AppConsole console = new();

        const string sweCurrencyName = "kr";
        MovieView movieView = new(console);
        MovieService movieService = new(sweCurrencyName);
        MovieController movieController = new(movieView, movieService);

        TextWizardView textWizardView = new(console);
        TextWizardService textWizardService = new();
        TextWizardController textWizardController = new(textWizardView, textWizardService);

        AppMenuView appMenuView = new(console);
        return new(
            appMenuView,
            movieController,
            textWizardController
        );
    }
}
