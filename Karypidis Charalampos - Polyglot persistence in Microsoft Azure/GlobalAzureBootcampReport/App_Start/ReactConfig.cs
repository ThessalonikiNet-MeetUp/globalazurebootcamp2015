using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GlobalAzureBootcampReport.ReactConfig), "Configure")]

namespace GlobalAzureBootcampReport
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			// ES6 features are enabled by default. Uncomment the below line to disable them.
			// See http://reactjs.net/guides/es6.html for more information.
			ReactSiteConfiguration.Configuration.SetUseHarmony(true).SetReuseJavaScriptEngines(true);

			// Uncomment the below line if you are using Flow
			// See http://reactjs.net/guides/flow.html for more information.
			//ReactSiteConfiguration.Configuration.SetStripTypes(true);

			// If you want to use server-side rendering of React components, 
			// add all the necessary JavaScript files here. This includes 
			// your components as well as all of their dependencies.
			// See http://reactjs.net/ for more information. Example:
			ReactSiteConfiguration.Configuration
				.AddScriptWithoutTransform("~/Scripts/react-bootstrap.min.js")
				.AddScriptWithoutTransform("~/Scripts/build/server.bundle.js");
		}

	}
}