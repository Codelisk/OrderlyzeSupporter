using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesFrontendModule;
using Frontend_Uno.Presentation.Learning;

namespace Frontend_Uno.Presentation.Asking;
public class AskingModeView : RegionBasePage
{
    public AskingModeView()
    {
        this.SetupPage<AskingModeViewModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Children(
                new ScrollViewer().Content(
                new StackPanel().Spacing(20).Orientation(Orientation.Horizontal).Children(
                    new StackPanel().Spacing(20).Children(
                new TextBox()
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .Width(500)
                .InputScope(new InputScope()
                {
                    Names = { new InputScopeName() { NameValue = InputScopeNameValue.ChatWithoutEmoji } }
                })
                .VerticalContentAlignment(VerticalAlignment.Stretch)
                .PlaceholderText("Frage vom Kunden ...")
                    .Text(x => x.Bind(() => vm.Question).TwoWay()),
                new Button().Content("Fragen").Command(() => vm.AskCommand)),
                    new StackPanel().Spacing(20).Children(
                new TextBox()
                .PlaceholderText("Antwort vom Experten ...")
                .InputScope(new InputScope()
                {
                    Names = { new InputScopeName() { NameValue = InputScopeNameValue.AlphanumericFullWidth } }
                })
                .Width(500)
                .Height(500)
                .VerticalContentAlignment(VerticalAlignment.Stretch)
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .PlaceholderText("Korrekte Antwort")
                    .Text(x => x.Bind(() => vm.Answer).TwoWay()),
                new Button().Content("Speichern").Command(() => vm.SaveCommand))
            )),
                new ProgressRing().Width(100).Height(100).Visibility(x => x.Bind(() => vm.IsBusy).Convert((x) => x ? Visibility.Visible : Visibility.Collapsed)))));
    }
}
