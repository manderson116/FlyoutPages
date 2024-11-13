using Microsoft.Maui;

namespace FlyoutPages;

public partial class BMICalculator : ContentPage
{
	public BMICalculator()
	{
		InitializeComponent();
	}

    private void OnCalcClicked(object sender, EventArgs e)
    {
        double weight = Int32.Parse(EnterWeight.Text);
        double height = Int32.Parse(EnterHeight.Text);
        double result = Math.Round(703.0 * (weight / (height * height)), 1);
        string judgement = "...";

        if (result < 18.5)
            judgement = "That's underweight.";
        else if (result < 25.0)
            judgement = "That's a healthy weight!";
        else if (result < 30.0)
            judgement = "That's overweight...";
        else
            judgement = "That's obese!";

        BMILabel.Text = $"Your BMI is {result}.";
        JudgeLabel.Text = $"{judgement}";

        SemanticScreenReader.Announce(BMILabel.Text + JudgeLabel.Text);
    }
}