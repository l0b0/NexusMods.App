using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using ReactiveUI;

namespace NexusMods.App.UI.Controls.Spine.Buttons.Image;

public partial class ImageButton : ReactiveUserControl<IImageButtonViewModel>
{
    private Avalonia.Controls.Image? _image;

    public ImageButton()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.WhenAnyValue(vm => vm.ViewModel!.IsActive)
                .StartWith(false)
                .SubscribeWithErrorLogging(logger: default, SetClasses)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.Click, v => v.Button)
                .DisposeWith(d);

            _image = this.FindDescendantOfType<Avalonia.Controls.Image>();
            this.OneWayBind(ViewModel, vm => vm.Image, v => v._image!.Source)
                .DisposeWith(d);

            this.OneWayBind(ViewModel, vm => vm.Name, v => v.ToolTipTextBlock.Text)
                .DisposeWith(d);
        });
    }

    private void SetClasses(bool isActive)
    {
        if (isActive)
        {
            Button.Classes.Add("Active");
            Button.Classes.Remove("Inactive");
        }
        else
        {
            Button.Classes.Remove("Active");
            Button.Classes.Add("Inactive");
        }
    }

}
