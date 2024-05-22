using Task2.IO;

namespace Task2.view;

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
        console.WriteLine($"\n⚠️ {msg}", IO.ConsoleColor.RED);
    }
}
