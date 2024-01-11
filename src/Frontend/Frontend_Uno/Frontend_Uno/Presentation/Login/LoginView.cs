using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePagesFrontendModule;

namespace Frontend_Uno.Presentation.Login;
public partial class LoginView : RegionBasePage
{
    public LoginView()
    {
        this.SetupPage<LoginViewModel>((page, vm) => page
            .Background(Theme.Brushes.Background.Default)
            .Content(new StackPanel()
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Spacing(20)
            .Children(
                new TextBox().PlaceholderText("ServerUrl").Text(x => x.Bind(() => vm.RestUrl).TwoWay())
                .Width(500),
                new TextBox()
                .InputScope(new InputScope()
                {
                    Names = { new InputScopeName() { NameValue = InputScopeNameValue.EmailSmtpAddress } }
                })
                .Width(500)
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .PlaceholderText("Email")
                    .Text(x => x.Bind(() => vm.Email).TwoWay()),
                new TextBox()
                .Width(500)
                .AcceptsReturn(true)
                .TextWrapping(TextWrapping.Wrap)
                .InputScope(new InputScope()
                {
                    Names = { new InputScopeName() { NameValue = InputScopeNameValue.Password } }
                })
                .PlaceholderText("Password")
                    .Text(x => x.Bind(() => vm.Password).TwoWay()),
                new Button().Content("Login").Command(() => vm.LoginCommand)
            )));
    }
}
