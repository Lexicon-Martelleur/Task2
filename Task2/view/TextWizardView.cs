using Task2.IO;

namespace Task2.view;

/// <summary>
/// A UI class for reading and writing text wizard related tasks.
/// </summary>
/// <param name="console">
/// A <see cref="AppConsole"/> for IO console operations.
/// </param>
internal class TextWizardView(AppConsole console)
{
    internal string ReadTextFromUser()
    {
        console.Write("\n➡️ Enter text: ");
        return console.ReadLine();
    }

    internal void WriteOkTextLine(string text)
    {
        console.WriteLine($"\n✅ {text}");
    }

    internal void WriteGetThirdWordFailure(string msg)
    {
        console.WriteLine($"\n⚠️ {msg}", IO.ColorPalette.RED);
    }
}
