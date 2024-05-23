using Task2.controller;
using Task2.factory;

/// <summary>
/// Task 2 console application entry point.
/// </summary>

MainMenuFactory factory = new();
AppMenuController app = factory.CreateDefaultMainMenu();
app.StartMainMenu();
