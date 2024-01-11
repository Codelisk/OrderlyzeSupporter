using BasePagesFrontendModule;

namespace Frontend_Uno.Presentation;

public sealed partial class MainPage : RegionBasePage
{
    public MainPage()
    {
        this.SetupPage<MainPageViewModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new StackPanel()
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Spacing(20)
            .Orientation(Orientation.Horizontal)
            .Children(
                new Button().Content("Trainiere das Modell").Command(() => vm.TrainCommand),
                new Button().Content("Frage den Chat").Command(() => vm.AskCommand)
            )));
    }
}
