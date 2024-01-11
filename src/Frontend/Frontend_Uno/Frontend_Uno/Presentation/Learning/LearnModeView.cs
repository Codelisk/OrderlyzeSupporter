using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesFrontendModule;
using Frontend_Uno.Presentation.Asking;
using Supporter.Foundation.Dtos;

namespace Frontend_Uno.Presentation.Learning;
public partial class LearnModeView : RegionBasePage
{
    public LearnModeView()
    {
        this.SetupPage<LearnModeViewModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new StackPanel()
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Spacing(20)
            .Children(
                new Grid().Children(
                    new Grid().ColumnSpacing(50).ColumnDefinitions(
                        new ColumnDefinition[]
                        { new ColumnDefinition { Width = GridLength.Auto }
                        , new ColumnDefinition { Width = GridLength.Auto }}).Children(
                new StackPanel().Spacing(20).Children(
                new TextBox()
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .Width(500)
                .Height(100)
                .PlaceholderText("Frage vom Kunden ...")
                    .Text(x => x.Bind(() => vm.Question).TwoWay()),
                new TextBox()
                .Width(500)
                .Height(100)
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .PlaceholderText("Korrekte Antwort")
                    .Text(x => x.Bind(() => vm.Answer).TwoWay()),
                new Button().Content("Speichern").Command(() => vm.SendCommand)
            ), new ListView().Header("Journal").Grid(1).ItemsSource(x=>x.Bind(() => vm.Conversations)).ItemTemplate<BaseConversationPart>(
                item => new StackPanel().BorderBrush("#000000").BorderThickness(1).Children(
            new TextBlock().Text(x => x.Bind(() => item.Question)), 
            new TextBlock().Text(x => x.Bind(() => item.Answer))))),
                new ProgressRing().Width(100).Height(100).Visibility(x => x.Bind(() => vm.IsBusy).Convert((x) => x ? Visibility.Visible : Visibility.Collapsed))))));
    }
}
