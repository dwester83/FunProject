using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for GeneralControl.xaml
    /// </summary>
    public partial class GeneralControl : UserControl
    {
        private static ServiceHost host;

        public GeneralControl()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            if (host == null)
            {
                // Start the service
                Uri epAddress = new Uri("http://localhost:9001/Game/Message");
                Uri[] uris = new Uri[] { epAddress };

                // Will move this to the App.Config after finalizing stuff.
                MessageService service = new MessageService();
                host = new ServiceHost(service, uris);
                host.AddServiceEndpoint(typeof(IMessageService), new WSHttpBinding(), "Game/Message");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();

                listBox.Items.Add("MessageService has started.");
                startBtn.Content = "Stop Services";
            }
            else
            {
                // End the service
                host.Close();
                host = null;

                listBox.Items.Add("MessageService has ended.");
                startBtn.Content = "Start Services";
            }
        }

    }
}
