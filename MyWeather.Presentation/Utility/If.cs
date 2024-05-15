namespace MyWeather.Presentation.Utility;

public class If : ShellItem
{
    public static readonly BindableProperty ConditionProperty =
        BindableProperty.Create(nameof(Condition), typeof(bool), typeof(If), false, propertyChanged: OnContentDependentPropertyChanged);

    public bool Condition
    {
        get => (bool)GetValue(ConditionProperty);
        set => SetValue(ConditionProperty, value);
    }

    public static readonly BindableProperty TrueProperty =
        BindableProperty.Create(nameof(True), typeof(ShellContent), typeof(If), null, propertyChanged: OnContentDependentPropertyChanged);

    public ShellContent True
    {
        get => (ShellContent)GetValue(TrueProperty);
        set => SetValue(TrueProperty, value);
    }

    public static readonly BindableProperty FalseProperty =
        BindableProperty.Create(nameof(False), typeof(ShellContent), typeof(If), null, propertyChanged: OnContentDependentPropertyChanged);

    public ShellContent False
    {
        get => (ShellContent)GetValue(FalseProperty);
        set => SetValue(FalseProperty, value);
    }

    private static void OnContentDependentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        If currentIf = (If)bindable;
        currentIf.UpdateContent();
    }

    private void UpdateContent()
    {
        CurrentItem = Condition ? True : False;
    }
}
