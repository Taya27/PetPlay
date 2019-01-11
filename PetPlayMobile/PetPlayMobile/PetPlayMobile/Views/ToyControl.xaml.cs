using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetPlayMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToyControl : ContentPage
	{
        RemoteService service = new RemoteService();
	    private int upState, downState, rightState, leftState = 0;

		public ToyControl ()
		{
			InitializeComponent ();
		}

	    async void UpButton_TouchedDown(object sender, EventArgs e)
	    {
	        if (upState == 1) return;
	        var model = new LedQueryInfo
	        {
	            Led = 10
	        };

	        upState = model.State = 1;

	        await service.SetState(model);
        }

        async void UpButton_TouchedUp(object sender, EventArgs e)
	    {
	        if (upState == 0) return;
	        var model = new LedQueryInfo
	        {
	            Led = 10
	        };

	        upState = model.State = 0;

	        await service.SetState(model);
        }

	    private async void DownButton_OnTouchedDown_TouchedDown(object sender, EventArgs e)
	    {
	        if (downState == 1) return;
	        var model = new LedQueryInfo
	        {
	            Led = 5
	        };

	        downState = model.State = 1;

	        await service.SetState(model);
        }

	    private async void DownButton_OnTouchedUp(object sender, EventArgs e)
	    {
	        if (downState == 0) return;
	        var model = new LedQueryInfo
	        {
	            Led = 5
	        };

	        downState = model.State = 0;

	        await service.SetState(model);
        }

	    private async void RightButton_OnTouchedDown(object sender, EventArgs e)
	    {
	        if (rightState == 1) return;
	        var model = new LedQueryInfo
	        {
	            Led = 9
	        };

	        rightState = model.State = 1;

	        await service.SetState(model);
        }

	    private async void RightButton_OnTouchedUp(object sender, EventArgs e)
	    {
	        if (rightState == 0) return;
	        var model = new LedQueryInfo
	        {
	            Led = 9
	        };

	        rightState = model.State = 0;

	        await service.SetState(model);
        }

	    private async void LeftButton_OnTouchedDown(object sender, EventArgs e)
	    {
	        if (leftState == 1) return;
	        var model = new LedQueryInfo
	        {
	            Led = 3
	        };

	        leftState = model.State = 1;

	        await service.SetState(model);
        }

	    private async void LeftButton_OnTouchedUp(object sender, EventArgs e)
	    {
	        if (leftState == 0) return;
	        var model = new LedQueryInfo
	        {
	            Led = 3
	        };

	        leftState = model.State = 0;

	        await service.SetState(model);
        }
	}
}