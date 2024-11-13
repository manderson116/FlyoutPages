namespace FlyoutPages;

public partial class MorseTap : ContentPage
{
	public MorseTap()
	{
		InitializeComponent();
    }

    private static string[] codes = new string[] { ".-", "-...", "-.-.", "-..",
            ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.",
            "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "" };
    private static char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F',
            'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z', '_'};

    public static char MorseCoder(string code)
    {
        char result = '?';
        for (int i = 0; i < codes.Length; i++)
        {
            if (codes[i].Equals(code))
            {
                result = letters[i];
                break;
            }
        }
        return result;
    }

    string MorseCharacter1 = "";
    string MorseMessage1 = "";
    string MorseCharacter2 = "";
    string MorseMessage2 = "";

    private void OnDotBtn1Clicked(object sender, EventArgs e)
    {
        MorseCharacter1 += ".";
        MorseCharacterLabel1.Text = MorseCharacter1 + " (" + MorseCoder(MorseCharacter1) + ")";
    }
    private void OnDashBtn1Clicked(object sender, EventArgs e)
    {
        MorseCharacter1 += "-";
        MorseCharacterLabel1.Text = MorseCharacter1 + " (" + MorseCoder(MorseCharacter1) + ")";
    }
    private void OnBackBtn1Clicked(object sender, EventArgs e)
    {
        if (MorseCharacter1 == "" && MorseMessage1 != "")
        {
            MorseMessage1 = MorseMessage1.Remove(MorseMessage1.Length - 1);
            if (MorseMessage1 == "")
                MorseMessageLabel1.Text = "Tap message...";
            else
                MorseMessageLabel1.Text = MorseMessage1;
        }
        else
        {
            MorseCharacter1 = "";
            MorseCharacterLabel1.Text = "Tap character...";
        }
    }
    private void OnSpaceBtn1Clicked(object sender, EventArgs e)
    {
        MorseMessage1 += MorseCoder(MorseCharacter1);

        if (MorseMessage1 == "")
            MorseMessageLabel1.Text = "Tap message...";
        else
            MorseMessageLabel1.Text = MorseMessage1;

        MorseCharacter1 = "";
        MorseCharacterLabel1.Text = "Tap character...";
    }

    private void OnDotBtn2Clicked(object sender, EventArgs e)
    {
        MorseCharacter2 += ".";
        MorseCharacterLabel2.Text = MorseCharacter2 + " (" + MorseCoder(MorseCharacter2) + ")";
    }
    private void OnDashBtn2Clicked(object sender, EventArgs e)
    {
        MorseCharacter2 += "-";
        MorseCharacterLabel2.Text = MorseCharacter2 + " (" + MorseCoder(MorseCharacter2) + ")";
    }
    private void OnBackBtn2Clicked(object sender, EventArgs e)
    {
        if (MorseCharacter2 == "" && MorseMessage2 != "")
        {
            MorseMessage2 = MorseMessage2.Remove(MorseMessage2.Length - 1);
            if (MorseMessage2 == "")
                MorseMessageLabel2.Text = "Tap message...";
            else
                MorseMessageLabel2.Text = MorseMessage2;
        }
        else
        {
            MorseCharacter2 = "";
            MorseCharacterLabel2.Text = "Tap character...";
        }
    }
    private void OnSpaceBtn2Clicked(object sender, EventArgs e)
    {
        MorseMessage2 += MorseCoder(MorseCharacter2);

        if (MorseMessage2 == "")
            MorseMessageLabel2.Text = "Tap message...";
        else
            MorseMessageLabel2.Text = MorseMessage2;

        MorseCharacter2 = "";
        MorseCharacterLabel2.Text = "Tap character...";
    }
}