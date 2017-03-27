using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCustomRendererSamples.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(NumericEntryRenderer))]
namespace XamarinCustomRendererSamples.iOS
{
	public class NumericEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			try
			{
				if (e.NewElement != null && e.NewElement.Keyboard == Keyboard.Numeric)
				{
					var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

					toolbar.Items = new[]
					{
						new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
						new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
					};

					this.Control.InputAccessoryView = toolbar;
				}
			}
			catch (Exception) { }
		}
	}
}
