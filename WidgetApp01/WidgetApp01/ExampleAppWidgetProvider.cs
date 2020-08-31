using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;

namespace WidgetApp01
{
    [BroadcastReceiver(Label = "HellApp Widget")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/example_appwidget_info")]
    public class ExampleAppWidgetProvider : AppWidgetProvider
    {
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            //base.OnUpdate(context, appWidgetManager, appWidgetIds);
            foreach (var appWidgetId in appWidgetIds)
            {
                Intent intent = new Intent(context, typeof(MainActivity));
                PendingIntent pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0);

                RemoteViews views = new RemoteViews(context.PackageName, Resource.Layout.example_widget);

                views.SetOnClickPendingIntent(Resource.Id.btnWidgetPressMe, pendingIntent);

                appWidgetManager.UpdateAppWidget(appWidgetId, views);

            }
        }
    }
}